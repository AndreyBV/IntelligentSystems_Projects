using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace K_means
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //При запуске программы изначально включается метод k-Means
            rbKmeans.Checked = true;
            typeWork = "KM";
            //Формирование контекстного меню, реализующего удаление строк и столбцов
            dgvBase.ContextMenuStrip = contextMenuStrip1;
        }
        //Количество классов, на которое нужно разбить множество объектов
        int kNumClass = 0;
        //Количество признаков
        int countSign = 0;
        //Список центров классов
        List<List<double>> listCenterPoint = new List<List<double>>();
        //Список растояний объектов до центров классов
        List<List<double>> listLenObjToClass = new List<List<double>>();
        //Список минимального количества наимение зависимых признаков
        KeyValuePair<string, double> listNeedPriz = new KeyValuePair<string, double>();

        #region SaveLoad
        //Путь сохранения
        string pathFile = "";
        //Переменная определяющая текущий метод работы
        string typeWork = "";

        //Кнопка сохранения таблицы "объект-признак" в файл
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        pathFile = fbd.SelectedPath;
                    }
                    else
                        return;
                    if (typeWork == "KM")
                        SvOpArrB(pathFile + "/k-means.km", 1);
                    if (typeWork == "COS")
                        SvOpArrB(pathFile + "/cos.km", 1);
                    MessageBox.Show("Файл успешно сохранен!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Кнопка открытия таблицы "объект-признак" из файла
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    ClearAll();
                    dgvData.Rows.Clear();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        pathFile = fbd.SelectedPath;
                    }
                    else
                        return;
                    if (typeWork == "KM")
                        SvOpArrB(pathFile + "/k-means.km");
                    if (typeWork == "COS")
                        SvOpArrB(pathFile + "/cos.km");
                    countTmp++;
                    tabControl1.SelectedIndex = 0;
                    //btnSolve.Enabled = true;
                    btnWinRegression.Enabled = true;
                    //btnChart.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Функция, реализующая сохранение и открытие таблицы "объект-признак"
        void SvOpArrB(string fileName, int type = 0)
        {
            if (type == 0) //открытие файла
            {
                if (dgvBase.Columns.Count != 0)
                {
                    dgvBase.Rows.Clear();
                    dgvBase.Columns.Clear();
                }
                using (StreamReader sr = new StreamReader(fileName))
                {
                    int row = int.Parse(sr.ReadLine()); //число строк
                    int col = int.Parse(sr.ReadLine()); //число столбцов

                    for (int i = 0; i < row; i++)
                        dgvBase.Columns.Add("", "");
                    for (int j = 0; j < col; j++)
                        dgvBase.Rows.Add();
                    for (int i = 0; i < row; i++)
                    {
                        //Считываем очередную строку из файла, в которой хранятся значения столбцов текущей строки
                        //Методом Split разбиваем ее по пробелам и заполняем массив.
                        string temp = sr.ReadLine();
                        string[] line = temp.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < col; j++)
                        {
                            if (i == 0 && j == 0)
                                dgvBase[i, j].Style.BackColor = Color.Gray;
                            dgvBase[i, j].Value = line[j];
                        }
                    }
                }
            }
            else if (type == 1) //сохранение файла
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    int countColumns = dgvBase.Columns.Count;
                    int countRows = dgvBase.Rows.Count;
                    sw.WriteLine(countColumns);
                    sw.WriteLine(countRows);
                    for (int i = 0; i < countColumns; i++)
                    {
                        string[] line = new string[countRows];
                        for (int j = 0; j < countRows; j++)
                        {
                            //Cобираем в строковый массив столбцы текущей строки массива
                            if (i == 0 && j == 0)
                            {
                                if (typeWork == "KM")
                                    line[j] = "K-MEANS";
                                if (typeWork == "COS")
                                    line[j] = "COS";
                            }
                            else
                                line[j] = dgvBase[i, j].Value.ToString();
                        }
                        sw.WriteLine(String.Join(" ", line));
                    }
                }
            }
        }
        #endregion

        #region Other Action
        //Функция по очистке всех переменных
        void ClearAll()
        {
            listCenterPoint.Clear();
            listLenObjToClass.Clear();
            listNeedPriz = new KeyValuePair<string, double>();
            kNumClass = 0;
            countSign = 0;
            indexNowCol = 0;
            maxPosPoint = 0;
            minPosPoint = 0;
            countTmp = 0;
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();
            BuildDgvData();
            txbStartCenter.Text = "";

            resClasses.Clear();
            listNowElement.Clear();
            listTwoPriznaks.Clear();
            oldIndexRow = 1;
            oldIndexRowForColor = 1;
        }
        //Событие, срабатывающее при нажатии кнопки "Решить"
        bool successSolve = false;
        private void btnSolve_Click(object sender, EventArgs e)
        {
            if (TestEnterData() == false)
                return;
            if (rbKmeans.Checked)
            {
                try
                {
                    if (txbNumClass.Text != "")
                    {
                        tabControl1.SelectedTab = tabPage2;
                        ClearAll();
                        kNumClass = Convert.ToInt32(txbNumClass.Text);
                        countSign = dgvBase.Columns.Count - 1;

                        GetStartPoint();

                        CalcLen();
                        GetNumClass();
                        GetNameObjInClass();
                        CalcNewCenterPoint();
                        successSolve = true;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Введите необходимое число классов!");
                        successSolve = false;
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    successSolve = false;
                }
            }
            if (rbCos.Checked)
            {
                try
                {
                    if (TestObjSign() == false)
                        return;
                    BaseFunctionCos();
                    int oldPosRow = BuildTree();
                    List<KeyValuePair<string, double>> listPriorityOne = GetPriorityOne();
                    List<KeyValuePair<string, double>> listPriorityTwo = GetPriorityTwo();

                    dgvData.Rows[oldPosRow].Cells[4].Value = "Важность осей";
                    dgvData.Rows[oldPosRow].Cells[4].Style.BackColor = Color.LightCoral;
                    dgvData.Rows[oldPosRow].Cells[5].Style.BackColor = Color.LightCoral;

                    oldPosRow = ShowPriorityAsix(listPriorityOne, oldPosRow);
                    oldPosRow = ShowPriorityAsix(listPriorityTwo, oldPosRow);

                    KeyValuePair<string, double> minCountPriz = FindMinCountPriz();
                    oldPosRow++;
                    dgvData.Rows[oldPosRow].Cells[4].Value = "Важные признаки";
                    dgvData.Rows[oldPosRow].Cells[4].Style.BackColor = Color.LightCoral;
                    dgvData.Rows[oldPosRow].Cells[5].Style.BackColor = Color.LightCoral;
                    oldPosRow++;
                    dgvData.Rows[oldPosRow].Cells[4].Value = minCountPriz.Key;
                    dgvData.Rows[oldPosRow].Cells[5].Value = minCountPriz.Value;
                    listNeedPriz = minCountPriz;
                    tabControl1.SelectedTab = tabPage2;
                    MessageBox.Show("Решено!");
                    successSolve = true;
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    successSolve = false;
                }
            }
        }
        //Проверка заоплнеости базовой таблицы ввода изначальных данных
        bool TestEnterData()
        {
            if (dgvBase.Columns.Count < 3 || dgvBase.Rows.Count < 3)
            {
                MessageBox.Show("Количество объектов и признаков\r\nдолжно быть не меньше двух!");
                return false;
            }
            for (int i = 0; i < dgvBase.Rows.Count; i++)
            {
                for (int j = 0; j < dgvBase.Columns.Count; j++)
                {
                    if (i == 0 && j == 0)
                        continue;
                    if (dgvBase.Rows[i].Cells[j].Value == null || dgvBase.Rows[i].Cells[j].Value.ToString() == "")
                    {
                        MessageBox.Show("В исходной таблице данных присутствуют\r\nнезаполненные ячейки!");
                        return false;
                    }
                    if (i > 0 && j > 0)
                    {
                        try
                        {
                            Convert.ToDouble(dgvBase.Rows[i].Cells[j].Value);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("В исходной таблице данынх присутствует\r\nневерный формат данных!");
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        bool TestObjSign()
        {
            int countIdenticalEl = 0;
            for (int i = 1; i < dgvBase.Columns.Count; i++)
            {
                countIdenticalEl = 0;
                for (int j = 2; j < dgvBase.Rows.Count; j++)
                {
                    if (Convert.ToDouble(dgvBase.Rows[j].Cells[i].Value) == Convert.ToDouble(dgvBase.Rows[j - 1].Cells[i].Value))
                        countIdenticalEl++;
                    if (countIdenticalEl == dgvBase.Rows.Count - 2)
                    {
                        MessageBox.Show("Обнаружен признак, имеющий одно\r\nи то же занчение на всем наборе объектов!");
                        return false;
                    }
                }
            }
            for (int i = 1; i < dgvBase.Rows.Count; i++)
            {
                countIdenticalEl = 0;
                for (int j = 2; j < dgvBase.Columns.Count; j++)
                {
                    if (Convert.ToDouble(dgvBase.Rows[i].Cells[j].Value) == Convert.ToDouble(dgvBase.Rows[i].Cells[j - 1].Value))
                        countIdenticalEl++;
                    if (countIdenticalEl == dgvBase.Columns.Count - 2)
                    {
                        MessageBox.Show("Обнаружен объект, имеющий одно\r\nи то же занчение на всем наборе признаков!");
                        return false;
                    }
                }
            }
            return true;
            
        }
        //Событие, срабатывающее при нажатии кнопки "График"
        private void btnChart_Click(object sender, EventArgs e)
        {
            if (successSolve)
            {
                Chart winChart = new Chart();
                winChart.Owner = this;

                Dictionary<string, List<double>> point = new Dictionary<string, List<double>>();


                for (int j = 1; j < dgvBase.Columns.Count; j++)
                {
                    List<double> tmp = new List<double>();
                    for (int i = 1; i < dgvBase.Rows.Count; i++)
                        tmp.Add(Convert.ToDouble(dgvBase.Rows[i].Cells[j].Value));
                    winChart.point.Add(dgvBase.Rows[0].Cells[j].Value.ToString(), tmp);
                }
                foreach (var el in listCenterPoint)
                {
                    List<double> tmp = new List<double>();
                    foreach (var elin in el)
                    {
                        tmp.Add(elin);
                    }
                    winChart.listCenterPoint.Add(tmp);
                }
                for (int i = 1; i < dgvBase.Rows.Count; i++)
                    winChart.classEl.Add(Convert.ToDouble(dgvData.Rows[i].Cells[indexNowCol].Value));




                //winChart.point = point;
                //winChart.listCenterPoint = listCenterPoint;
                //winChart.minAxis = minPosPoint;
                //winChart.maxAxis = maxPosPoint;

                winChart.minAxis = 0;
                winChart.maxAxis = 6;

                winChart.DrawAllProections();
                winChart.Show();
            }
            else
                MessageBox.Show("Получить график не возможно, так как не получено\r\nрешение для текущей конфигурации таблицы или\r\nданные исходной таблицы были изменены!");
        }
        //Событие, срабатывающее при выборе алгоритма решеия
        private void rbKmeans_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKmeans.Checked)
            {
                typeWork = "KM";
                btnChart.Visible = true;
                btnWinRegression.Visible = false;
                ClearAll();
                dgvData.Columns.Clear();
                tabControl1.SelectTab(0);
            }
            if (rbCos.Checked)
            {
                typeWork = "COS";
                btnChart.Visible = false;
                btnWinRegression.Visible = true;
                ClearAll();
                dgvData.Columns.Clear();
                tabControl1.SelectTab(0);
            }
        }
        //Собитыие, срабатывающее при нажатии на кнопку "Очистить"
        private void btnClean_Click(object sender, EventArgs e)
        {
            ClearAll();
            dgvBase.Rows.Clear();
            dgvBase.Columns.Clear();
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();
            //btnSolve.Enabled = false;
            btnWinRegression.Enabled = false;
            //btnChart.Enabled = false;
        }
        //Событие, срабатывающее при нажатии на кнопку "Удалиь строку" в контекстном меню 
        private void cmsRemoveRow_Click(object sender, EventArgs e)
        {
            dgvBase.Rows.Remove(dgvBase.CurrentRow);
        }
        //Событие, срабатывающее при нажатии на кнопку "Удалиь столбец" в контекстном меню 
        private void cmsRemoveCol_Click(object sender, EventArgs e)
        {
            dgvBase.Columns.RemoveAt(dgvBase.CurrentCell.ColumnIndex);
        }
        //Добавление колонки
        private void btnAddCol_Click(object sender, EventArgs e)
        {
            dgvBase.Columns.Add("", "");
            if (dgvBase.Rows.Count == 0)
            {
                dgvBase.Rows.Add();
                dgvBase.Rows[0].Cells[0].Style.BackColor = Color.Gray;
                dgvBase.Rows[0].Cells[0].ReadOnly = true;
            }
            countTmp++;
        }
        //Добавление строки
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            if (dgvBase.Columns.Count > 0)
                dgvBase.Rows.Add();
            else
                MessageBox.Show("Для начала доавьте столбец!");
        }
        //Установить флаг - не решено в случае изменения занчения в исходной таблице
        private void dgvBase_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            successSolve = false;
        }
        #endregion

        #region Regression-Analisis
        //Событие, срабатывающее при нажатии на кнопку "Регрессисонный анализ"
        private void btnWinRegression_Click(object sender, EventArgs e)
        {
            if (successSolve)
            {
                RedgressionAnalisis();
            } else
                MessageBox.Show("Провести регрессионный анализ не возможно, так как не получено\r\nрешение для текущей конфигурации таблицы или\r\nданные исходной таблицы были изменены!!");
        }
        //Функция, реализующая регрессионынй анализ
        void RedgressionAnalisis()
        {
            RegressinoAn ra = new RegressinoAn();

            string[] line = new string[0];
            if (listNeedPriz.Key != null)
                line = listNeedPriz.Key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            else
            {
                MessageBox.Show("Нет данных для проведения регрессионного анализа!");
                return;
            }

            if (line.GetLength(0) == dgvBase.Columns.Count - 1)
            {
                //Добавление только тех признаков, которые являются параметрами
                for (int i = 1; i < dgvBase.Columns.Count; i++)
                {
                    List<double> listVal = new List<double>();
                    for (int j = 0; j < line.GetLength(0); j++)
                    {
                        if (dgvBase.Rows[0].Cells[i].Value.ToString() == line[j].ToString())
                        {
                            for (int k = 1; k < dgvBase.Rows.Count; k++)
                            {
                                listVal.Add(Convert.ToDouble(dgvBase.Rows[k].Cells[i].Value));
                            }
                            ra.listPriz.Insert(0, new KeyValuePair<string, List<double>>(dgvBase.Rows[0].Cells[i].Value.ToString(), listVal));
                            break;
                        }
                        else if (j == line.GetLength(0) - 1)
                        {
                            for (int k = 1; k < dgvBase.Rows.Count; k++)
                            {
                                listVal.Add(Convert.ToDouble(dgvBase.Rows[k].Cells[i].Value));
                            }
                            ra.listPriz.Add(new KeyValuePair<string, List<double>>(dgvBase.Rows[0].Cells[i].Value.ToString(), listVal));
                            break;
                        }
                    }

                }
                ra.countColParametrs = line.GetLength(0);
                ra.countAllPriz = dgvBase.Columns.Count - 1;
                ra.countRowObj = dgvBase.Rows.Count - 1;
                ra.Show();
            }
            else
                MessageBox.Show("Все признаки являются важными!\r\nПолучить зависимости не возможно!");

        }
        #endregion

        #region COS
             
        //Индекс текущей страки в таблице результата
        int oldIndexRow = 1;
        //Индекс текущей строки для формирования цветов
        int oldIndexRowForColor = 1;
        //Список распределения объектов по классам
        List<KeyValuePair<string, double>> resClasses = new List<KeyValuePair<string, double>>();
        //Список для поиска минимальных объектов
        List<KeyValuePair<string, double>> listNowElement = new List<KeyValuePair<string, double>>();
        //Список пар признаков
        List<KeyValuePair<string, double>> listTwoPriznaks = new List<KeyValuePair<string, double>>();

        //Основной расчет
        void BaseFunctionCos()
        {
            ClearAll();
            dgvData.Rows.Clear();
            dgvData.Columns.Clear();
            //-------------------
            //-------------------вычислеине объектов
            //-------------------
            Dictionary<string, List<double>> obj = new Dictionary<string, List<double>>();
            for (int i = 1; i < dgvBase.Rows.Count; i++)
            {
                List<double> tmp = new List<double>();
                for (int j = 1; j < dgvBase.Columns.Count; j++)
                {
                    tmp.Add(Convert.ToDouble(dgvBase.Rows[i].Cells[j].Value));
                }
                obj.Add(dgvBase.Rows[i].Cells[0].Value.ToString(), tmp);
            }

            dgvData.Columns.Add("", "");
            dgvData.Columns.Add("", "");
            dgvData.Rows.Add();
            dgvData.Rows[0].Cells[0].Value = "Объекты";
            dgvData.Rows[0].Cells[0].Style.BackColor = Color.LightCoral;
            dgvData.Rows[0].Cells[1].Style.BackColor = Color.LightCoral;
            //KeyValuePair<string, double> oldMaxEl = new KeyValuePair<string, double>();
            for (int i = 2; i < dgvBase.Rows.Count; i++)
            {
                List<KeyValuePair<string, double>> listResTable = new List<KeyValuePair<string, double>>();
                listResTable = GetAllComboEl(obj, i);
                ShowComboDgv(listResTable, i, 0);

                //поиск максимального элемента
                if (i == 2)
                    listNowElement.Add(FindMaxMinElement(listResTable, 1));

                BuildBackColorMinMaxElement(listResTable, i, 0);

            }
            listNowElement.Clear();
            //-------------------
            //-------------------вычислеине признаков
            //-------------------
            obj = new Dictionary<string, List<double>>();
            for (int j = 1; j < dgvBase.Columns.Count; j++)
            {
                List<double> tmp = new List<double>();

                for (int i = 1; i < dgvBase.Rows.Count; i++)
                {
                    tmp.Add(Convert.ToDouble(dgvBase.Rows[i].Cells[j].Value));
                }
                obj.Add(dgvBase.Rows[0].Cells[j].Value.ToString(), tmp);
            }

            dgvData.Columns.Add("", "");
            dgvData.Columns.Add("", "");
            dgvData.Rows[0].Cells[2].Value = "Признаки";
            dgvData.Rows[0].Cells[2].Style.BackColor = Color.LightCoral;
            dgvData.Rows[0].Cells[3].Style.BackColor = Color.LightCoral;
            oldIndexRow = 1;
            oldIndexRowForColor = 1;
            //for (int i = 2; i < dgvBase.Columns.Count; i++)
            //{
            //    List<KeyValuePair<string, double>> listResTable = new List<KeyValuePair<string, double>>();
            //    listResTable = GetAllComboEl(obj, i);
            //    ShowComboDgv(listResTable, i, 2);
            //    //поиск минимального элемента

            //    if (i == 2)
            //        listNowElement.Add(FindMaxMinElement(listResTable, 0));

            //    BuildBackColorMinMaxElement(listResTable, i, 2);
            //}
            List<KeyValuePair<string, double>> listResTablePr = new List<KeyValuePair<string, double>>();
            listResTablePr = GetAllComboEl(obj, 2);
            ShowComboDgv(listResTablePr, 2, 2);
            listTwoPriznaks = listResTablePr;
            //поиск минимального элемента
            listNowElement.Add(FindMaxMinElement(listResTablePr, 0));
            BuildBackColorMinMaxElement(listResTablePr, 2, 2);
            listNowElement.Clear();
        }
        //Отображение комбинаций объектов
        void ShowComboDgv(List<KeyValuePair<string, double>> listEl, int countCombo, int startColumn)
        {
            if (startColumn != 2)
                for (int i = 0; i < listEl.Count + 1; i++)
                    dgvData.Rows.Add();
            else                                               ///-----------------------------
            {
                if (/*oldIndexRow > dgvData.Rows.Count || */(oldIndexRow + listEl.Count + 1) > dgvData.Rows.Count)
                    for (int i = 0; i < listEl.Count + 1; i++)
                        dgvData.Rows.Add();
            }

            dgvData.Rows[oldIndexRow].Cells[startColumn].Value = "Кортеж " + countCombo + " - к";
            dgvData.Rows[oldIndexRow].Cells[startColumn].Style.BackColor = Color.LightGreen;
            dgvData.Rows[oldIndexRow].Cells[startColumn + 1].Style.BackColor = Color.LightGreen;
            oldIndexRow++;
            for (int i = 0; i < listEl.Count; i++)
            {
                dgvData.Rows[oldIndexRow].Cells[startColumn].Value = listEl[i].Key;
                dgvData.Rows[oldIndexRow].Cells[startColumn + 1].Value = listEl[i].Value;
                oldIndexRow++;
            }
        }
        //Выделение минимальных/максимальных элементов
        void BuildBackColorMinMaxElement(List<KeyValuePair<string, double>> listEl, int countCombo, int startColumn)
        {
            oldIndexRowForColor++;
            int oldIRFCTmp = oldIndexRowForColor;
            List<KeyValuePair<string, double>> tmp = new List<KeyValuePair<string, double>>();
            for (int i = 0; i < listEl.Count; i++)
            {
                foreach (var el in listNowElement)
                if (/*countCombo != 2 && */TestFindOldValueInNewValue(el, listEl[i], countCombo)  /*listEl[i].Key.IndexOf(oldMinMaxEl.Key) > -1 */ /*listEl[i].Key == minMaxEl.Key && listEl[i].Value == minMaxEl.Value*/)
                    tmp.Add(listEl[i]);

                oldIndexRowForColor++;
            }

            listNowElement.Clear();
            foreach (var el in tmp)
                listNowElement.Add(el);
            KeyValuePair<string, double> kvMinMaxEl = new KeyValuePair<string, double>();
            if (startColumn == 0)
                kvMinMaxEl = FindMaxMinElement(listNowElement, 1);
            else if (startColumn == 2)
                kvMinMaxEl = FindMaxMinElement(listNowElement, 0);
            for (int i = 0; i < listEl.Count; i++)
            {
                if (listEl[i].Key == kvMinMaxEl.Key && listEl[i].Value == kvMinMaxEl.Value)
                {
                    if (startColumn == 0) 
                        resClasses.Add(listEl[i]);
                    dgvData.Rows[oldIRFCTmp].Cells[startColumn].Style.BackColor = Color.LightBlue;
                    dgvData.Rows[oldIRFCTmp].Cells[startColumn + 1].Style.BackColor = Color.LightBlue;
                }
                oldIRFCTmp++;
            }
        }
        //Поиск группы объектов в более широком множестве
        bool TestFindOldValueInNewValue(KeyValuePair<string, double> oldV, KeyValuePair<string, double> newV, int countCombo)
        {
            string[] oldSymbols = oldV.Key.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int countEquals = 0;
            for (int i = 0; i < oldSymbols.Count(); i++)
            {
                if (newV.Key.IndexOf(oldSymbols[i]) > -1)
                {
                    countEquals++;
                }
            }
            string[] newSymbols = newV.Key.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //MessageBox.Show((newV.Key.Length / 2) + "  " +  countEquals);
            if (countCombo == 2 && (newSymbols.Count()) == countEquals)
                return true;
            if (countCombo != 2 && (newSymbols.Count() - 1 )== countEquals)
                return true;
            return false;
        }
        //Поиск минимлаьного/максимального элемента (COS)
        KeyValuePair<string, double> FindMaxMinElement(List<KeyValuePair<string, double>> listEl, int type)
        {
            KeyValuePair<string, double> keyValueMinMax = new KeyValuePair<string, double>();

            keyValueMinMax = listEl[0];

            for (int i = 0; i < listEl.Count; i++)
            {
                //поиск минимального элемента
                if (type == 0 && keyValueMinMax.Value > listEl[i].Value)
                {
                    keyValueMinMax = listEl[i];
                }
                //поиск максимального элемента
                else if (type == 1 && keyValueMinMax.Value < listEl[i].Value)
                {
                    keyValueMinMax = listEl[i];
                }
            }
            return keyValueMinMax;
        }     
        //Построение дерева
        int BuildTree()
        {
            dgvData.Columns.Add("", "");
            dgvData.Columns.Add("", "");

            dgvData.Rows[0].Cells[4].Value = "Элементы дерева";
            dgvData.Rows[0].Cells[4].Value = "Уровень дерева";
            dgvData.Rows[0].Cells[4].Style.BackColor = Color.LightCoral;
            dgvData.Rows[0].Cells[5].Style.BackColor = Color.LightCoral;

            if (resClasses.Count > dgvData.Rows.Count)
                for (int i = 0; i < (dgvData.Rows.Count - resClasses.Count); i++)
                    dgvData.Rows.Add();
            int nowPosRow = 1;
            for (int i = resClasses.Count - 1; i >= 0; i--)
            {
                dgvData.Rows[nowPosRow].Cells[4].Value = resClasses[i].Key;
                dgvData.Rows[nowPosRow].Cells[5].Value = resClasses[i].Value;
                nowPosRow++;
            }
            return nowPosRow;

            //for (int i = 0; i < resClasses.Count; i++)
            //{
            //    dgvData.Rows[i + 1].Cells[4].Value = resClasses[i].Key;
            //}


            ////TextBox blockEl = new TextBox();
            ////blockEl.ReadOnly = true;
            //int posXEl = 485;
            //int posYEl = 185;
            //List<KeyValuePair<string, KeyValuePair<double, double>>> listNameElAndPos = new List<KeyValuePair<string, KeyValuePair<double, double>>>();
            //for (int i = 1; i < dgvBase.Rows.Count; i++)
            //{
            //    TextBox blockEl = new TextBox();
            //    blockEl.ReadOnly = true;
            //    blockEl.Text = dgvBase.Rows[i].Cells[0].Value.ToString();
            //    blockEl.Width = 50;
            //    blockEl.Height = 22;
            //    blockEl.Location = new Point(posXEl, posYEl);
            //    listNameElAndPos.Add(new KeyValuePair<string, KeyValuePair<double, double>>(dgvBase.Rows[i].Cells[0].Value.ToString(), new KeyValuePair<double, double>(posXEl, posYEl)));
            //    posXEl += blockEl.Width + 20;
            //    blockEl.BackColor = Color.LightGray;
            //    toolTip1.SetToolTip(blockEl, blockEl.Text);
            //    this.Controls.Add(blockEl);
            //}

            //for (int i = 0; i < resClasses.Count; i++)
            //{
            //    TextBox blockEl = new TextBox();
            //    blockEl.ReadOnly = true;
            //    blockEl.Text = resClasses[i].Key;
            //    blockEl.Width = 50;
            //    blockEl.Height = 22;
            //    string[] line = resClasses[i].Key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            //    for (int j = 0; j < line.GetLength(0); j++)
            //    {


            //        posXEl = () / 2;
            //    }
            //    blockEl.Location = new Point(posXEl, posYEl);
            //    listNameElAndPos.Add(new KeyValuePair<string, KeyValuePair<double, double>>(resClasses[i].Key, new KeyValuePair<double, double>(posXEl, posYEl)));
            //    posYEl += blockEl.Height + 15;
            //    blockEl.BackColor = Color.LightGray;
            //    toolTip1.SetToolTip(blockEl, blockEl.Text);
            //    this.Controls.Add(blockEl);


            //    MessageBox.Show(resClasses[i].Key);

            //}
        }
        //Получение приотритетов (важности) признаков через количество информации (ln)
        List<KeyValuePair<string, double>> GetPriorityOne()
        {
            double countZero = 0;
            double countOne = 0;
            List<KeyValuePair<string, double>> listInfoPriz = new List<KeyValuePair<string, double>>();

            for (int i = 1; i < dgvBase.Columns.Count; i++)
            {
                countZero = 0;
                countOne = 0;
                for (int j = 1; j < dgvBase.Rows.Count; j++)
                {
                    double nowVal = Convert.ToDouble(dgvBase.Rows[j].Cells[i].Value);
                    if (nowVal == 1)
                        countOne++;
                    else if (nowVal == 0)
                        countZero++;
                }
                double countInfo = -( (1 / countOne) * Math.Log(countOne) + (1 / countZero) * Math.Log(countZero));
                listInfoPriz.Add(new KeyValuePair<string, double>(dgvBase.Rows[0].Cells[i].Value.ToString(), countInfo));
            }
            List<KeyValuePair<string, double>> tmpUp = new List<KeyValuePair<string, double>>();

            while (listInfoPriz.Count > 0)
            {
                KeyValuePair<string, double> minElSP = listInfoPriz[0];
                foreach (var el in listInfoPriz)
                {
                    if (el.Value < minElSP.Value)
                        minElSP = el;
                }
                tmpUp.Add(minElSP);
                listInfoPriz.Remove(minElSP);
            }
            return tmpUp;
            //MessageBox.Show(listTwoPriznaks.Count + "");
        }
        //Получение приотритетов (важности) признаков через таблицу косинусов пар признаков 
        List<KeyValuePair<string, double>> GetPriorityTwo()
        {
            List<KeyValuePair<string, double>> listSumPriz = new List<KeyValuePair<string, double>>();
            int countPriz = dgvBase.Columns.Count - 1;
            //double[,] arrTwoPriz = new double[countPriz, countPriz];
            for (int i = 1; i < countPriz + 1; i++)
            {
                KeyValuePair<string, double> elSum = new KeyValuePair<string, double>(dgvBase.Rows[0].Cells[i].Value.ToString(), 1);
                for (int j = 1; j < countPriz + 1; j++)
                {
                    foreach (var el in listTwoPriznaks)
                    {
                        if (dgvBase.Rows[0].Cells[i].Value.ToString() != dgvBase.Rows[0].Cells[j].Value.ToString() && el.Key.IndexOf(dgvBase.Rows[0].Cells[i].Value.ToString()) > -1 && el.Key.IndexOf(dgvBase.Rows[0].Cells[j].Value.ToString()) > -1)
                        {
                            elSum = new KeyValuePair<string, double>(elSum.Key, elSum.Value + el.Value);
                            break;
                        }
                    }                 
                }
                listSumPriz.Add(elSum);
            }
            List<KeyValuePair<string, double>> tmpUp = new List<KeyValuePair<string, double>>();
            
            while (listSumPriz.Count > 0)
            {
                KeyValuePair<string, double> minElSP = listSumPriz[0];
                foreach (var el in listSumPriz)
                {
                    if (el.Value < minElSP.Value)
                        minElSP = el;
                }
                tmpUp.Add(minElSP);
                listSumPriz.Remove(minElSP);
            }
            return tmpUp;  
            //MessageBox.Show(listTwoPriznaks.Count + "");
        }
        //Отображение приоритета признаков
        int ShowPriorityAsix(List<KeyValuePair<string, double>> listPriority, int nowRow)
        {
            string strKey = "";
            string strVal = "";
            nowRow++;
            foreach (var el in listPriority)
            {
                if (listPriority.IndexOf(el) == listPriority.Count - 1)
                    strKey += el.Key;
                else
                    strKey += el.Key + "->";
                strVal += el.Value + "   ";
            }
            dgvData.Rows[nowRow].Cells[4].Value = strKey;
            dgvData.Rows[nowRow].Cells[5].Value = strVal;
            return nowRow;
        }
        //Определение минимального количества признаков, которые однозначно определяют объекты
        KeyValuePair<string, double> FindMinCountPriz()
        {
            KeyValuePair<string, double> minPair = FindMaxMinElement(listTwoPriznaks, 0);
            //Получение всех возможных признаков
            Dictionary<string, List<double>>  obj = new Dictionary<string, List<double>>();
            for (int j = 1; j < dgvBase.Columns.Count; j++)
            {
                List<double> tmp = new List<double>();

                for (int i = 1; i < dgvBase.Rows.Count; i++)
                {
                    tmp.Add(Convert.ToDouble(dgvBase.Rows[i].Cells[j].Value));
                }
                obj.Add(dgvBase.Rows[0].Cells[j].Value.ToString(), tmp);
            }

            for (int i = 3; i < dgvBase.Columns.Count ; i++)
            {
                string[] minPairEl = minPair.Key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                List<int> listIndexCol = new List<int>();
                for (int j = 1; j < dgvBase.Columns.Count; j++)
                {
                    for (int m = 0; m < minPairEl.GetLength(0); m++)
                    {
                        if (dgvBase.Rows[0].Cells[j].Value.ToString() == minPairEl[m])
                        {
                            listIndexCol.Add(j);
                        }
                    }
                }
                int countAllEquals = 0;
                for (int j = 1; j < dgvBase.Rows.Count; j++)
                {
                    for (int f = j + 1; f < dgvBase.Rows.Count; f++)
                    {
                        int countEquals = 0;
                        for (int m = 0; m < listIndexCol.Count; m++)
                        {
                            if (Convert.ToDouble(dgvBase.Rows[j].Cells[listIndexCol[m]].Value) == Convert.ToDouble(dgvBase.Rows[f].Cells[listIndexCol[m]].Value))
                            {
                                countEquals++;
                            }
                            if (countEquals == minPairEl.GetLength(0))
                            {
                                countAllEquals++;
                               
                            }
                        }
                    }
                }
                //Если все точки расставлены однозначно
                if (countAllEquals == 0)
                {
                    //MessageBox.Show(minPair.Key + "  " + minPair.Value);
                    return minPair;
                }

                string[] line = minPair.Key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //Получение всех возможных комбинаций
                List<KeyValuePair<string, double>> listComboPriz = new List<KeyValuePair<string, double>>();
                //Выбор только нужных комбинаций 
                listComboPriz = GetAllComboEl(obj, i);

                List<KeyValuePair<string, double>> needEl = GetNeedCombo(listComboPriz, line);
                //Список итоговых сумм
                List<KeyValuePair<string, double>> listSumNeedEl = new List<KeyValuePair<string, double>>();
                //Поиск двоек в нужной комбинации
                foreach (var el in needEl)
                {
                    string[] arrNamePriz = el.Key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    Dictionary<string, List<double>> listArrNamePriz = new Dictionary<string, List<double>>();
                    for (int k = 0; k < arrNamePriz.GetLength(0); k++)
                    {
                        listArrNamePriz.Add(arrNamePriz[k], null); //------------------
                    }
                    //Выбор только нужных комбинаций
                    listComboPriz = GetAllComboEl(listArrNamePriz, 2);

                    double sumNeedEl = 0;
                    foreach (var lcp in listComboPriz)
                    {
                        string[] lcpEl = lcp.Key.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        List<KeyValuePair<string, double>> getElSum = GetNeedCombo(listTwoPriznaks, lcpEl);
                        sumNeedEl += getElSum[0].Value;
                    }
                    listSumNeedEl.Add(new KeyValuePair<string, double>(el.Key, sumNeedEl));
                }
                //Получение минимальной суммы
                minPair = FindMaxMinElement(listSumNeedEl, 0);
            }
            return new KeyValuePair<string, double>("", 0);
        }
        //Обнаружение нужных признаков
        List<KeyValuePair<string, double>> GetNeedCombo(List<KeyValuePair<string, double>> listCombo, string[] line)
        {
            List<KeyValuePair<string, double>> needEl = new List<KeyValuePair<string, double>>();
            foreach (var el in listCombo)
            {
                //if (el.Key.IndexOf(line[0]) > -1 && el.Key.IndexOf(line[1]) > -1) ;
                int countEquals = 0;
                for (int j = 0; j < line.GetLength(0); j++)
                {
                    if (el.Key.IndexOf(line[j]) > -1)
                    {
                        countEquals++;
                    }
                }
                if (countEquals == line.GetLength(0))
                {
                    needEl.Add(el);
                }
            }
            return needEl;
        }
        //Получение всех не повторяющихся перестановок
        public IEnumerable<IEnumerable<KeyValuePair<string,T>>> GetPowerSet<T>(Dictionary<string,T> list)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                    from i in Enumerable.Range(0, list.Count)
                    where (m & (1 << i)) != 0
                    select list.ElementAt(i);
        }
        //Получение списка всех двоек, троек, четверок и т.д.
        List<KeyValuePair<string, double>> GetAllComboEl(Dictionary<string, List<double>> obj, int numberCombo)
        {
            List<KeyValuePair<string, double>> listResTable = new List<KeyValuePair<string, double>>();
            KeyValuePair<string, double> resCos =  new KeyValuePair<string, double>();
            foreach (var k in GetPowerSet(obj))
            {
                var nowCombo = k.ToList();
                resCos = new KeyValuePair<string, double>();
                if (nowCombo.Count == numberCombo)
                {                 
                    resCos = CalcCos(nowCombo);
                    listResTable.Add(resCos);
                    //MessageBox.Show(resCos.Key + " " + resCos.Value);
                }
            }
            return listResTable;
        }
        //Расчет косинусов
        KeyValuePair<string, double> CalcCos(List<KeyValuePair<string, List<double>>> obj)
        {
            double multiDevidnd = 1;
            //делимое
            double devidend = 0;
            //сумма квадратов
            double sumPow = 0;
            //делитель
            double devider = 1;

            if (obj[0].Value != null)
            {
                for (int i = 0; i < obj[0].Value.Count; i++)
                {
                    multiDevidnd = 1;
                    for (int j = 0; j < obj.Count; j++)
                    {
                        multiDevidnd *= obj[j].Value[i];
                    }
                    devidend += multiDevidnd;
                }

                for (int j = 0; j < obj.Count; j++)
                {
                    sumPow = 0;
                    for (int i = 0; i < obj[0].Value.Count; i++)
                    {
                        sumPow += Math.Pow(obj[j].Value[i], 2);
                    }
                    devider *= Math.Sqrt(sumPow);
                }
            }
            string nameCombo = "";
            foreach (var el in obj)
                nameCombo += el.Key + " ";


            return new KeyValuePair<string, double>(nameCombo, (devidend / devider));
        }
        #endregion
     
        #region K-MEANS
        //Индекс текущей колонки
        int indexNowCol = 0;
        int countTmp = 0; //не нужен
        //Расчет расстояний объектов до центров
        void CalcLen()
        {
            double sumEL = 0;
            double sqrtEl = 0;
            int tmpK = kNumClass;
            //перебор списка центров классов
            foreach (var tmp in listCenterPoint)
            {
                List<double> elLen = new List<double>();
                for (int i = 1; i < dgvBase.Rows.Count; i++)
                {
                    sumEL = 0;
                    for (int j = 1; j < dgvBase.Columns.Count; j++)
                    {
                        sumEL += Math.Pow(Convert.ToDouble(dgvBase.Rows[i].Cells[j].Value) - tmp.ElementAt(j - 1), 2);
                    }
                    sqrtEl = Math.Sqrt(sumEL);
                    elLen.Add(sqrtEl);
                }
                listLenObjToClass.Add(elLen);
            }
            ShowListLenObjToClass();
        }
        //Отображение списка расстояний
        void ShowListLenObjToClass()
        {
            foreach (var tmp in listLenObjToClass)
            {
                int indexNowRow = 1;
                foreach (var el in tmp)
                {
                    dgvData.Rows[indexNowRow].Cells[indexNowCol].Value = el;
                    indexNowRow++;
                }
                dgvData.Columns.Add("","");
                indexNowCol++;
            }
       
        }
        //Распределение объектов по классам (получение номеров классов для каждого объекта)
        void GetNumClass()
        {
            dgvData.Rows[0].Cells[indexNowCol].Value = "#";
            dgvData.Rows[0].Cells[indexNowCol].Style.BackColor = Color.LightGreen;
            int indexMinEl = 0;
            int numClass = 0;
            for (int j = 1; j < dgvBase.Rows.Count; j++)
            {
                double minEl = Convert.ToDouble(dgvData.Rows[j].Cells[indexNowCol - kNumClass].Value);
                indexMinEl = 0;
                numClass = 0;
                for (int i = indexNowCol - kNumClass; i < indexNowCol; i++)
                {
                    dgvData.Rows[0].Cells[i].Value = "Class - " + numClass;
                    dgvData.Rows[0].Cells[i].Style.BackColor = Color.LightBlue;
                    if (minEl > Convert.ToDouble(dgvData.Rows[j].Cells[i].Value))
                    {
                        minEl = Convert.ToDouble(dgvData.Rows[j].Cells[i].Value);
                        indexMinEl = numClass;
                    }
                    numClass++;
                    dgvData.Rows[j].Cells[indexNowCol].Value = indexMinEl;
                    dgvData.Rows[j].Cells[indexNowCol].Style.BackColor = Color.LightGreen;
                }
            }
            //dgvData.Columns.Add("","");
        }
        //Вывод списка объектов принадлежащик тому или иному классу
        void GetNameObjInClass()
        {
            int nowCol = indexNowCol - kNumClass;
           
            for (int j = 0; j < kNumClass; j++)
            {
                for (int i = 1; i < dgvBase.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgvData.Rows[i].Cells[indexNowCol].Value) == j)
                    {
                        dgvData.Rows[dgvBase.Rows.Count].Cells[nowCol].Value += dgvBase.Rows[i].Cells[0].Value + " ";
                        dgvData.Rows[dgvBase.Rows.Count].Cells[nowCol].Style.BackColor = Color.LightBlue;
                    }
                }
                nowCol++;
            }
        }
        //Перерасчет центров классов
        void CalcNewCenterPoint()
        {
            //новая точка
            double resNewPoint = 0;
            int countEl = 0;
            //Список старых центров
            List<List<double>> oldCenter = new List<List<double>>();
            foreach (var el in listCenterPoint)
            {
                oldCenter.Add(el);
            }
            listCenterPoint.Clear();

            for (int j = 0; j < kNumClass; j++)
            {
                List<double> tmp = new List<double>();
                for (int l = 1; l < dgvBase.Columns.Count; l++)
                {
                    countEl = 0;
                    double sumEl = 0;
                    for (int i = 1; i < dgvBase.Rows.Count; i++)
                    {
                        if (Convert.ToInt32(dgvData.Rows[i].Cells[indexNowCol].Value) == j)
                        {
                            countEl++;
                            sumEl += Convert.ToDouble(dgvBase.Rows[i].Cells[l].Value);
                        }
                    }
                    if (countEl != 0)
                    {
                        resNewPoint = sumEl / countEl;
                        tmp.Add(resNewPoint);
                    }
                    else
                    {
                        tmp = oldCenter.ElementAt(j);
                    }
                  
                   
                }
                listCenterPoint.Add(tmp);

            }

            int nowCol = indexNowCol - kNumClass;
            string strNewPoint = "";
            int countAllEl = listCenterPoint.Count * listCenterPoint.ElementAt(0).Count;
            int countSameEl = 0;
            for (int i = 0; i < listCenterPoint.Count; i++)
            {
                strNewPoint = "";
                for (int j = 0; j < listCenterPoint.ElementAt(0).Count; j++)
                {
                    
                    if (j == 0)
                        strNewPoint += "( ";
                    if (j == listCenterPoint.ElementAt(0).Count - 1)
                        strNewPoint += listCenterPoint.ElementAt(i).ElementAt(j) + " )";
                    else
                        strNewPoint += listCenterPoint.ElementAt(i).ElementAt(j) + " ; ";



                    if (listCenterPoint.ElementAt(i).ElementAt(j) == oldCenter.ElementAt(i).ElementAt(j))
                        countSameEl++;

                }
                dgvData.Rows[dgvBase.Rows.Count + 1].Cells[nowCol].Value += strNewPoint;
                dgvData.Rows[dgvBase.Rows.Count + 1].Cells[nowCol].Style.BackColor = Color.LightBlue;
                nowCol++;
            }
            if (countSameEl == countAllEl)
            {
                MessageBox.Show("Решено!");
                return;
            }
            else
            {
                listLenObjToClass.Clear();
                indexNowCol++;
                dgvData.Columns.Add("","");
                CalcLen();
                GetNumClass();
                GetNameObjInClass();
                CalcNewCenterPoint();
            }

        }
        //Формирование строк и столбцов таблицы результатов
        void BuildDgvData()
        {
            dgvData.Columns.Add("","");
            for (int i = 0; i < dgvBase.Rows.Count; i++)
            {
                dgvData.Rows.Add();
            }
            dgvData.Rows.Add();
            dgvData.Rows.Add();
        }
        double maxPosPoint = 0; //не нужны
        double minPosPoint = 0;
        //Получение случайных начальных центров
        void GetStartPoint()
        {
            Random rnd = new Random();
            double rndPos = 0;
            double maxEl = 0;
            double minEl = 0;
            for (int i = kNumClass; i > 0; i--)
            {
                List<double> tmp = new List<double>();
                for (int j = 0; j < countSign; j++)
                {

                    maxEl = GetMaxMinElDgv(j);
                    Thread.Sleep(70);
                    minEl = GetMaxMinElDgv(j, 0);
                    Thread.Sleep(70);
                    rndPos = rnd.NextDouble() * (maxEl - minEl) + minEl;

                    tmp.Add(rndPos);
                }
                listCenterPoint.Add(tmp);

            }

            //List<double> tmp = new List<double>();
            //tmp.Add(1);
            //tmp.Add(1);
            //listCenterPoint.Add(tmp);
            //List<double> tmp1 = new List<double>();
            //tmp1.Add(2);
            //tmp1.Add(1);
            //listCenterPoint.Add(tmp1);


            string strNewPoint = "";
            for (int i = 0; i < listCenterPoint.Count; i++)
            {
               
                for (int j = 0; j < listCenterPoint.ElementAt(0).Count; j++)
                {

                    if (j == 0)
                        strNewPoint += "( ";
                    if (j == listCenterPoint.ElementAt(0).Count - 1)
                        strNewPoint += listCenterPoint.ElementAt(i).ElementAt(j) + " ) ";
                    else
                        strNewPoint += listCenterPoint.ElementAt(i).ElementAt(j) + " ; ";

                }
            }
            txbStartCenter.Text += strNewPoint;
        }
        //Получение максимального и минимального значения для формирования центра
        double GetMaxMinElDgv(int p, int type = 1)
        {
            double el = Convert.ToDouble(dgvBase.Rows[1].Cells[p + 1].Value);
            for (int i = 1; i < dgvBase.Rows.Count; i++)
            {
                if (type == 1)
                {
                    if (Convert.ToDouble(dgvBase.Rows[i].Cells[p + 1].Value) > el)
                        el = Convert.ToDouble(dgvBase.Rows[i].Cells[p + 1].Value);
                }
                else if (type == 0)
                {
                    if (Convert.ToDouble(dgvBase.Rows[i].Cells[p + 1].Value) < el)
                        el = Convert.ToDouble(dgvBase.Rows[i].Cells[p + 1].Value);
                }
            }
            return el;
        }

        #endregion
        
    }
}
