using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ID3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Dictionary<string, Dictionary<string, int>> listSign = new Dictionary<string, Dictionary<string, int>>();
        List<double> resLog = new List<double>();
        int[,] arrSign;


        private void btnGiveValKey_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> tmp = new Dictionary<string, int>();
            string nameSign = txtbKeyWordChipher.Text;
            for (int i = 0; i < dgvSign.Rows.Count - 1; i++)
                tmp.Add(Convert.ToString(dgvSign.Rows[i].Cells[0].Value), Convert.ToInt32(dgvSign.Rows[i].Cells[1].Value));
            listSign.Add(nameSign, tmp);
            dgvBase.Columns.Add(nameSign, nameSign);
        }

        private void btnSeeKeyWord_Click(object sender, EventArgs e)
        {
            foreach (var el in listSign)
                if (el.Key == txtbKeyWordChipher.Text)
                {
                    int i = 0;
                    while (dgvSign.Rows.Count < el.Value.Count+1)
                        dgvSign.Rows.Add();
                    foreach (var tmp in el.Value)
                    {

                        dgvSign.Rows[i].Cells["Key"].Value = tmp.Key;
                        dgvSign.Rows[i].Cells["Value"].Value = tmp.Value;
                        i++;
                    }
                }
        }

        private void btnDelKeyWord_Click(object sender, EventArgs e)
        {
            foreach (var el in listSign)
                if (el.Key == txtbKeyWordChipher.Text)
                {
                    listSign.Remove(el.Key);
                    dgvBase.Columns.Remove(el.Key);
                    dgvSign.Rows.Clear();
                    return;
                }
        }

        private void btnClearKeyValue_Click(object sender, EventArgs e)
        {
            txtbKeyWordChipher.Text = "";
            dgvSign.Rows.Clear();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            GetSolve();
        }

        void GetNewTable()
        {
            CopyStuctDgv();
            //arrSign = new int[dgvBase.Rows.Count, dgvBase.Columns.Count - 1];
            for (int j = 0; j < dgvBase.Columns.Count; j++)
                for (int i = 0; i < dgvBase.Rows.Count - 1; i++)
                {
                    string colName = dgvBase.Columns[j].Name;
                    var x = listSign[colName];
                    //arrSign[i, j] = x[Convert.ToString(dgvBase.Rows[i].Cells[j].Value)];
                    //dgvBaseInt.Rows[i].Cells[j].Value = arrSign[i, j];
                    dgvBaseInt.Rows[i].Cells[j].Value = x[Convert.ToString(dgvBase.Rows[i].Cells[j].Value)];
                }
        }

        void CopyStuctDgv()
        {
            dgvBaseInt.Rows.Clear();
            dgvBaseInt.Columns.Clear();
            for (int i = 0; i < dgvBase.Columns.Count; i++)
            {
                dgvBaseInt.Columns.Add(dgvBase.Columns[i].Name, dgvBase.Columns[i].Name);
            }
            for (int j = 0; j < dgvBase.Rows.Count - 1; j++)
            {
                dgvBaseInt.Rows.Add();
            }
        }

        void GetSolve()
        {
            GetNewTable();

            Dictionary<string, Dictionary<int, Dictionary<int, int>>> scanAll = new Dictionary<string, Dictionary<int, Dictionary<int, int>>>();
            Dictionary<string, double> arrForMinEl = new Dictionary<string, double>();
            Dictionary<string, string> listOutElement = new Dictionary<string, string>();
            for (int j = 1; j < dgvBaseInt.Columns.Count; j++)
            {
                string colName = dgvBase.Columns[j].Name;
                var x = listSign[colName];
                Dictionary<int, Dictionary<int, int>> scan = new Dictionary<int, Dictionary<int, int>>(); //временный для столбика
                Dictionary<int, int> tmpT = new Dictionary<int, int>();

                foreach (var tmp in x)
                {
                    if (!scan.ContainsKey(tmp.Value))
                        scan.Add(tmp.Value, null);
                    for (int i = 0; i < dgvBaseInt.Rows.Count; i++)
                    {
                        if (tmp.Value == Convert.ToInt32(dgvBaseInt.Rows[i].Cells[j].Value))
                        {
                            tmpT.Add(i, Convert.ToInt32(dgvBaseInt.Rows[i].Cells[0].Value));
                            scan[tmp.Value] = tmpT;

                        }
                    }
                    tmpT = new Dictionary<int, int>();
                }//////////////////
                double minVal = CalcLog(scan, dgvBaseInt.Rows.Count);
                scanAll.Add(colName, scan);
                arrForMinEl.Add(colName, minVal);
            }
            Point ptt = new Point(650, 30);
            double min = FindMinResLog(/*resLog,*/ arrForMinEl, ptt);
            string name = "";
            foreach (var tmp in arrForMinEl)
                if (tmp.Value == min)
                {
                    name = tmp.Key;
                }
            listOutElement = CalcLogForEndPoint(scanAll[name], name);
            string strEndPoint = "";
            foreach (var loe in listOutElement)
            {
                strEndPoint += loe + " ";
            }

            string strMinName = "Минимальный элемент:\r\n" + name + " - " + min + "\r\n\r\n" + strEndPoint;
            //MessageBox.Show("Минимальный элемент:\n" + name + " - " + min);
            Point pt = new Point(650, 100);
            PutLabel(strMinName, pt, 1);
            //posYN += 80;

            List<string> oldName = new List<string>();
            oldName.Add(name);
            //MessageBox.Show(name);
            GetResNextIteration(scanAll[name], oldName, name, ptt);

        }
        bool pointBrake = false;





        void GetResNextIteration(Dictionary<int, Dictionary<int, int>> oldScan, List<string> oldName, string nameV, Point oldPt)
        {
            //CalcLog(oldScan)
           
            foreach (var n in oldScan)
            {
                //MessageBox.Show(oldScan.Count+" " + nameV);
                int count = 0;
                int elTmp = -1;
                int r = 0;
                Dictionary<string, string> listOutElement = new Dictionary<string, string>();
                string nameVet = "";
                foreach (var ltmp in listSign) //определение имени ветки в которой находимся
                {
                    if (ltmp.Key == nameV)
                        foreach (var ltmp1 in ltmp.Value)
                            if (ltmp1.Value == n.Key)
                                nameVet = ltmp1.Key;
                }
               
                if (n.Value != null)
                foreach (var n1 in n.Value) //проверка на то что в данной ветке все признаки одинаковые
                {
                    if (r == 0)
                        elTmp = n1.Value;
                    if (n1.Value == elTmp)
                        count++;
                    //if (count == n.Value.Count)
                    //{
                    //    //MessageBox.Show(n1.Value.ToString());
                    //    listOutElement.Add(n1.Value.ToString());
                    //}
                    r++;
                }
                resLog.Clear(); ///////--------
               
                if (n.Value != null && count != n.Value.Count)
                {
                   
                    //************************************************

                    Dictionary<string, Dictionary<int, Dictionary<int, int>>> scanAll = new Dictionary<string, Dictionary<int, Dictionary<int, int>>>();
                    Dictionary<string, double> arrForMinEl = new Dictionary<string, double>();
                    for (int j = 1; j < dgvBaseInt.Columns.Count; j++)
                    {
                        foreach (var nameNoCol in oldName)
                        {

                            if (j < dgvBaseInt.Columns.Count && dgvBaseInt.Columns[j].Name == nameNoCol) //////////костыль - нужно запоминать по каким столбцам мы прошлись 
                                j++;
                        }
                        if (j >= dgvBaseInt.Columns.Count - 1)
                            continue;
                       

                        string colName = dgvBaseInt.Columns[j].Name;////////////
                        var x = listSign[colName];
                        Dictionary<int, Dictionary<int, int>> scan = new Dictionary<int, Dictionary<int, int>>(); //временный для столбика
                        Dictionary<int, int> tmpT = new Dictionary<int, int>();

                        foreach (var tmp in x)
                        {
                            if (!scan.ContainsKey(tmp.Value))
                                scan.Add(tmp.Value, null);
                            for (int i = 0; i < dgvBaseInt.Rows.Count; i++)
                            {
                                var g = oldScan[n.Key]; 
                                foreach (var el in g)
                                    if (el.Key == i && tmp.Value == Convert.ToInt32(dgvBaseInt.Rows[i].Cells[j].Value))
                                    {
                                        tmpT.Add(i, Convert.ToInt32(dgvBaseInt.Rows[i].Cells[0].Value));
                                        scan[tmp.Value] = tmpT;

                                    }
                            }
                            tmpT = new Dictionary<int, int>();
                        }//////////////////
                     
                        double minVal = CalcLog(scan, oldScan[n.Key].Count);
                        scanAll.Add(colName, scan);
                        arrForMinEl.Add(colName, minVal);
                    }
                    if (!pointBrake)
                    {
                        oldPt.Y += 160;
                        //posY += 160;
                    }
                    else
                        pointBrake = false;
                    Point ptt = new Point(oldPt.X, oldPt.Y);
                    double min = FindMinResLog(/*resLog,*/ arrForMinEl, ptt, nameVet);
                    string name = "";
                    foreach (var tmp in arrForMinEl)
                        if (tmp.Value == min)
                        {
                            name = tmp.Key;
                        }
                    if (name != "")
                    {
                        listOutElement = CalcLogForEndPoint(scanAll[name], name);
                    
                  
                        string strEndPoint = "";
                        foreach (var loe in listOutElement)
                        {
                            strEndPoint += loe + " ";
                        }
                    
                        string strMinName = "Минимальный элемент:\r\n" + name + " - " + min + "\r\n\r\n" + strEndPoint;
                        //MessageBox.Show("Минимальный элемент:\n" + name + " - " + min);

                        Point pt = new Point(oldPt.X, oldPt.Y+70);
                        PutLabel(strMinName, pt, 1);


                        //if (min == 0)
                        //    return;
                        //MessageBox.Show(name);
                        oldName.Add(name);
                        //MessageBox.Show(name);
                        GetResNextIteration(scanAll[name], oldName, name, ptt);
                        oldName.Remove(name);
                        //MessageBox.Show(name + "  D " + oldName.Count);
                    
                        //MessageBox.Show("");
                        //posYN -= 80;
                        //posY -= 80;
                        pointBrake = true;
                        oldPt.X += 220;
                        foreach (Control c in this.Controls)
                        {
                            if (c is TextBox)
                            {
                                if (c.Location == new Point(oldPt.X, oldPt.Y))
                                    oldPt.X += 220;
                            }
                        }
                    }
                    //posX += 220;
                    //GetResNextIteration(scanAll[minEl[min]]);
                    //************************************************
                }
            }
           
            //MessageBox.Show("");
        }
        //int posYN = 100;
        //int posXN = 650;
        //int posY = 30;
        //int posX = 650;



        double CalcLog(Dictionary<int, Dictionary<int, int>> scan, int N)
        {
            double[] resEl = new double[scan.Count];
            int[] countF = new int[listSign[dgvBaseInt.Columns[0].Name].Keys.Count]; //временный на ветке
            double res = 0;
            int j = 0;
            foreach (var f1 in scan) // перебор элементов скана
            {
                int i = 0;
                foreach (var f3 in listSign[dgvBaseInt.Columns[0].Name].Values) // перебор всех возможный состояний функции
                {
                    
                    countF[i] = 0;
                    if (f1.Value != null)
                    foreach (var f2 in f1.Value) // перебор значений значения скана
                    {
                        if (f3 == f2.Value)
                            countF[i] += 1;
                    }
                    i++;
                }
                int count = 0;
                for (int k = 0; k < countF.GetLength(0); k++)
                    count += countF[k];
                for (int k = 0; k < countF.GetLength(0); k++)
                {
                    if (countF[k] != 0)
                        resEl[j] += (Convert.ToDouble(countF[k]) / count) * Math.Log((Convert.ToDouble(countF[k]) / count), 2);
                }
       
                resEl[j] *= (-1)*Convert.ToDouble(count)/N;
                j++;
            }
            for (int k = 0; k < resEl.GetLength(0); k++)
                res += resEl[k];
            resLog.Add(res);
            //MessageBox.Show(res + "");
            return res;
        }

        Dictionary<string, string> CalcLogForEndPoint(Dictionary<int, Dictionary<int, int>> scan, string nameScan)
        {
            int N = 0;
            foreach (var el in scan)
            {
                if (el.Value != null)
                foreach (var el1 in el.Value)
                    N++;
            }
            //MessageBox.Show(N + "");
            Dictionary<string, string> listEndPoint = new Dictionary<string, string>();


            double[] resEl = new double[scan.Count];
            int[] countF = new int[listSign[dgvBaseInt.Columns[0].Name].Keys.Count]; //временный на ветке
            foreach (var f1 in scan) // перебор элементов скана
            {
                int i = 0;
                foreach (var f3 in listSign[dgvBaseInt.Columns[0].Name].Values) // перебор всех возможный состояний функции
                {

                    countF[i] = 0;
                    if (f1.Value != null)
                        foreach (var f2 in f1.Value) // перебор значений значения скана
                        {
                            if (f3 == f2.Value)
                                countF[i] += 1;
                            if (countF[i] == f1.Value.Count())
                            {
                                string nameVet = "";
                                foreach (var ltmp in listSign)
                                {
                                    if (ltmp.Key == nameScan)
                                    foreach (var ltmp1 in ltmp.Value)
                                        if (ltmp1.Value == f1.Key)
                                            nameVet = ltmp1.Key;
                                }

                                foreach (var ltmp in listSign[dgvBaseInt.Columns[0].Name])
                                    if (f2.Value == ltmp.Value)
                                        listEndPoint.Add(nameVet, ltmp.Key);
                            }
                        }
                    i++;
                }
            }
            return listEndPoint;

            //for (int k = 0; k < resEl.GetLength(0); k++)
            //    res += resEl[k];
            //resLog.Add(res);
            ////MessageBox.Show(res + "");
            //return res;
        }



        double FindMinResLog(/*List<double> listLog, */Dictionary<string, double> arrForMinEl, Point pt, string nameCriteri = "")
        {
            double min = 0;
            int i = 0;
            string strMin = "\tИмя ветки: " + nameCriteri + "\r\n";
            foreach (var el in arrForMinEl)
            {
                //MessageBox.Show(nameCriteri + " " + el.Key);
                strMin +=  el.Key + " - " + el.Value + "\r\n";
                if (i == 0)
                    min = el.Value;
                if (min > el.Value)
                    min = el.Value;
                i++;
            }
            //Point pt = new Point(700, posY);
            //posY += 80;
            PutLabel(strMin, pt); ///////////////--------------0
            //MessageBox.Show(strMin);
            return min;
        }

        void PutLabel(string txt, Point pos, int type = 0)
        {
            RichTextBox tb = new RichTextBox();
            tb.Multiline = true;
            tb.Width = 200;
            tb.Height = 70;
            tb.Name = "tmpTb";
            tb.Text = txt;
            tb.Location = pos;
            if (type == 1)
                tb.BackColor = Color.LightBlue;

            //tb.ScrollBars = ScrollBars.Vertical;
            //tb.ScrollBars = ScrollBars.Horizontal;
            //tb.Left = 1000;
            //tb.Top = 50;
            this.Controls.Add(tb);
        }

        void SvOpDicIteration(string fileName, int type = 0)
        {
            if (type == 0) //открытие файла
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    listSign = new Dictionary<string, Dictionary<string, int>>();
                    int countEl = int.Parse(sr.ReadLine());

                    for (int j = 0; j < countEl; j++)
                    {
                        int countInRow = int.Parse(sr.ReadLine());
                        string tmpLine = sr.ReadLine();
                        string nameEl = sr.ReadLine();
                        string[] line = tmpLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Dictionary<string, int> tmp = new Dictionary<string, int>();
                        for (int i = 0; i < countInRow * 2; i += 2)
                        {
                            tmp.Add(line[i], Convert.ToInt32(line[i + 1]));
                        }
                        listSign.Add(nameEl, tmp);
                    }
                }
            }
            else if (type == 1) //сохранение файла
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.WriteLine(listSign.Count);
                    foreach (var el in listSign)
                    {
                        string[] line = new string[el.Value.Count * 2 /*+ 1*/];
                        int j = 0;
                        sw.WriteLine(el.Value.Count.ToString());
                        //line[j] = el.Value.Count.ToString();
                        //j++;
                        foreach (var elin in el.Value)
                        {
                            line[j] = elin.Key;
                            line[j + 1] = elin.Value.ToString();
                            j += 2;
                        }
                        sw.WriteLine(String.Join(" ", line));
                        sw.WriteLine(el.Key);
                    }
                }
            }
        }




        string pathFile = "";
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    pathFile = fbd.SelectedPath;
                }
                else
                    return;
                SvOpDic(pathFile + "/Dic.id3", 1);
                SvOpArr(pathFile + "/Arr.id3", 1);
                MessageBox.Show("Файл успешно сохранен!");
            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                //CleanAll();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    pathFile = fbd.SelectedPath;
                }
                else
                    return;
                SvOpDic(pathFile + "/Dic.id3");
                SvOpArr(pathFile + "/Arr.id3");
            }
        }
        void SvOpArr(string fileName, int type = 0)
        {
            if (type == 0) //открытие файла
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    int row = int.Parse(sr.ReadLine()); //число строк
                    int col = int.Parse(sr.ReadLine()); //число столбцов
                    foreach (var p in listSign)
                    {
                        dgvBase.Columns.Add(p.Key, p.Key);
                    }

                    //for (int i = 0; i < col; i++)
                    //{
                    //    dgvBase.Columns.Add(i+"", i+"");
                    //}
                    for (int i = 0; i < row; i++)
                    {
                        dgvBase.Rows.Add();
                    }

                    //arrB = new int[row, col];
                    for (int i = 0; i < row; i++)
                    {
                        //Считываем очередную строку из файла, в которой хранятся значения столбцов текущей строки
                        //Методом Split разбиваем ее по пробелам и заполняем массив.
                     
                        string temp = sr.ReadLine();
                        string[] line = temp.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < col; j++)
                        {
                            dgvBase.Rows.Add();
                            dgvBase.Rows[i].Cells[j].Value = line[j];
                        }
                    }
                    ClearEmtyRow();
                }
            }
            else if (type == 1) //сохранение файла
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.WriteLine(dgvBase.Rows.Count - 1);
                    sw.WriteLine(dgvBase.Columns.Count);
                    for (int i = 0; i < dgvBase.Rows.Count - 1; i++)
                    {
                        string[] line = new string[dgvBase.Columns.Count];
                        for (int j = 0; j < dgvBase.Columns.Count; j++)
                        {
                            //Cобираем в строковый массив столбцы текущей строки массива
                            line[j] = dgvBase.Rows[i].Cells[j].Value.ToString();
                        }
                        //Метод Join() склеивает элементы массива line в одну строку, разделяя их пробелами
                        sw.WriteLine(String.Join(" ", line));
                    }
                }
            }
        }
        void SvOpDic(string fileName, int type = 0)
        {
            if (type == 0) //открытие файла
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    listSign = new Dictionary<string, Dictionary<string, int>>();
                    int countEl = int.Parse(sr.ReadLine());

                    for (int j = 0; j < countEl; j++)
                    {
                        int countInRow = int.Parse(sr.ReadLine());
                        string tmpLine = sr.ReadLine();
                        string nameEl = sr.ReadLine();
                        string[] line = tmpLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        Dictionary<string, int> tmp = new Dictionary<string, int>();
                        for (int i = 0; i < countInRow * 2; i += 2)
                        {
                            tmp.Add(line[i], Convert.ToInt32(line[i+1]));
                        }
                        listSign.Add(nameEl, tmp);
                    }
                }
            }
            else if (type == 1) //сохранение файла
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.WriteLine(listSign.Count);
                    foreach (var el in listSign)
                    {
                        string[] line = new string[el.Value.Count*2 /*+ 1*/];
                        int j = 0;
                        sw.WriteLine(el.Value.Count.ToString());
                        //line[j] = el.Value.Count.ToString();
                        //j++;
                        foreach (var elin in el.Value)
                        {
                            line[j] = elin.Key;
                            line[j + 1] = elin.Value.ToString();
                            j += 2;
                        }
                        sw.WriteLine(String.Join(" ", line));
                        sw.WriteLine(el.Key);
                    }
                }
            }
        }

        void ClearEmtyRow()
        {
            dgvBase.AllowUserToAddRows = false;
            for (int i = 0; i < dgvBase.Rows.Count; i++)
            {
                int count = 0;
                for (int j = 0; j < dgvBase.Columns.Count; j++)
                {
                    if (dgvBase.Rows[i].Cells[j].Value == null)
                    {
                        count++;
                        if (count == dgvBase.Columns.Count)
                        {
                            dgvBase.Rows.RemoveAt(i);
                            i = 0;
                        }
                    }
                }
            }
            dgvBase.AllowUserToAddRows = true;
        }


    }
}
