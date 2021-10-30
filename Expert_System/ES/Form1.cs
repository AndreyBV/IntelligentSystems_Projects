using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            step = Convert.ToInt32(nUDStep.Value);
        }
        List<string> listConcept = new List<string>();
        List<string> listClass = new List<string>();
        int[,] arrB = new int[1000, 100];
        int step = 1;
        int countConcept = 0;
        int countClass = 0;
        string pathFile = "";

        private void buttonSv_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    pathFile = fbd.SelectedPath;
                }
                else
                    return;
                SvOpClassConcept(listConcept, pathFile + "/ListConcepts.esi", 1);
                SvOpClassConcept(listClass, pathFile + "/ListClass.esi", 1);
                SvOpArrB(pathFile + "/ArrB.esi", 1);
                MessageBox.Show("Файл успешно сохранен!");
            }
        }

        private void buttonOp_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                CleanAll();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    pathFile = fbd.SelectedPath;
                }
                else
                    return;
                SvOpClassConcept(listConcept, pathFile + "/ListConcepts.esi");
                SvOpClassConcept(listClass, pathFile + "/ListClass.esi");
                SvOpArrB(pathFile + "/ArrB.esi");
            }
        }

        void SvOpArrB(string fileName, int type = 0)
        {
            if (type == 0) //открытие файла
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    int row = int.Parse(sr.ReadLine()); //число строк
                    int col = int.Parse(sr.ReadLine()); //число столбцов
                    //arrB = new int[row, col];
                    for (int i = 0; i < row; i++)
                    {
                        //Считываем очередную строку из файла, в которой хранятся значения столбцов текущей строки
                        //Методом Split разбиваем ее по пробелам и заполняем массив.
                        string temp = sr.ReadLine();
                        string[] line = temp.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < col; j++)
                        {
                            arrB[i, j] = int.Parse(line[j]);
                        }
                    }
                    if (countClass > 0)
                        ShowArrB();
                }
            }
            else if (type == 1) //сохранение файла
            {
                using (StreamWriter sw = new StreamWriter(fileName, false))
                {
                    sw.WriteLine(countConcept);
                    sw.WriteLine(countClass);
                    for (int i = 0; i < countConcept; i++)
                    {
                        string[] line = new string[countClass];
                        for (int j = 0; j < countClass; j++)
                        {
                            //Cобираем в строковый массив столбцы текущей строки массива
                            line[j] = arrB[i, j].ToString();
                        }
                        //Метод Join() склеивает элементы массива line в одну строку, разделяя их пробелами
                        sw.WriteLine(String.Join(" ", line));
                    }
                }
            }
        }
        void SvOpClassConcept(List<string> list, string fileName, int type = 0)
        {
            if (type == 0) //открытие файла
            {
                foreach (string line in File.ReadLines(fileName))
                {
                    if (fileName.Contains("/ListConcepts.esi"))
                    {
                        listConcept.Add(line);
                        countConcept = listConcept.Count;
                        if (countConcept > 0)
                        {
                            ShowListConcept();
                            ShowConceptInDg(dgvLearn);
                            ShowConceptInDg(dgvExp);
                        }
                    }
                    else if (fileName.Contains("/ListClass.esi"))
                    {
                        listClass.Add(line);
                        countClass = listClass.Count;

                        if (countClass > 0)
                        {
                            ShowListClass();
                            ShowListClassComBox();
                        }
                    }
                }
            }
            else if (type == 1) //сохранение файла
            {
                string tmp = "";
                if (fileName.Contains("/ListConcepts.esi"))
                    foreach (string el in listConcept)
                    {
                        tmp += el + "\n";
                    }
                else if (fileName.Contains("/ListClass.esi"))
                    foreach (string el in listClass)
                    {
                        tmp += el + "\n";
                    }
                File.WriteAllText(fileName, tmp, Encoding.UTF8);
            }

        }





        //void FillArrBZero(int index, int type = 0)
        //{
        //    if (type == 0 || type == 3) //добавлен концепт
        //        for (int i = 0; i < countClass; i++)
        //            arrB[arrB.GetLength(1) - 1, i] = 0;
        //    else if (type == 1 || type == 3) //добавлен класс
        //        for (int i = 0; i < countConcept; i++)
        //            arrB[i, arrB.GetLength(0) - 1] = 0;

        //}
        void ReturnValueOnFaceGipercube()
        {
            for (int i = 0; i < countConcept; i++)
                for (int j = 0; j < countClass; j++)
                {
                    if (arrB[i, j] > 1)
                        arrB[i, j] = 1;
                    else if (arrB[i, j] < -1)
                        arrB[i, j] = -1;
                }
        }


        void ShowConceptInDg(DataGridView dg)
        {
            dg.Rows.Clear();
            for (int i = 0; i < listConcept.Count; i++)
            {
                dg.Rows.Add();
                dg.Rows[i].Cells[0].Value = listConcept[i];
            }


        }
        void ShowListConcept()
        {
            lbConcept.Items.Clear();
            foreach (string el in listConcept)
                lbConcept.Items.Add(el);
        }
        void ShowListClass()
        {
            lbClass.Items.Clear();
            foreach (string el in listClass)
                lbClass.Items.Add(el);
        }
        void ShowListClassComBox()
        {
            combClass.Items.Clear();
            foreach (string el in listClass)
                combClass.Items.Add(el);
            if (combClass.Items.Count > 0)
                combClass.SelectedIndex = 0;
        }
        void ShowArrB()
        {
            dgvMatrixB.Rows.Clear();
            dgvMatrixB.Columns.Clear();
            for (int j = 0; j < countClass; j++)
                dgvMatrixB.Columns.Add("", listClass[j]);
            for (int i = 0; i < countConcept; i++)
                dgvMatrixB.Rows.Add();

            for (int i = 0; i < countConcept; i++)
                for (int j = 0; j < countClass; j++)
                    dgvMatrixB.Rows[i].Cells[j].Value = arrB[i, j];

        }

        private void btnSvConcept_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvLearn.Rows.Count - 1; i++)
            {
                if (dgvLearn.Rows[i].Cells[0].Value == null)
                {
                    MessageBox.Show("Обнаружены пустые строки!\nПожалуйста, исправьте!");
                    return;
                }
            }
            for (int i = 0; i < dgvLearn.Rows.Count - 1; i++)
            {
                if (!listConcept.Contains(Convert.ToString(dgvLearn.Rows[i].Cells[0].Value)))
                    listConcept.Add(Convert.ToString(dgvLearn.Rows[i].Cells[0].Value));
            }
            countConcept = listConcept.Count();
            ShowListConcept();
            ShowConceptInDg(dgvExp);
            ShowConceptInDg(dgvExp);
            if (countClass > 0)
                ShowArrB();
        }


        void ResetChange(DataGridView dg)
        {
            for (int i = 0; i < dg.Rows.Count; i++)
                dg.Rows[i].Cells[1].Value = false;
        }
        private void btnResetLearn_Click(object sender, EventArgs e)
        {
            ResetChange(dgvLearn);
        }
        private void btnResetExpert_Click(object sender, EventArgs e)
        {
            ResetChange(dgvExp);
            txbRes.Text = "";
        }

        private void btnAddClass_Click(object sender, EventArgs e)
        {
            if (txbNameClass.Text != "")
            {
                string nameClass = txbNameClass.Text;
                if (!listClass.Contains(nameClass))
                {
                    listClass.Add(nameClass);
                    ShowListClass();
                    ShowListClassComBox();
                    countClass = listClass.Count();
                    //MessageBox.Show(countConcept + "  " + countClass);
                    //TransformArrB(nameClass);
                    ShowArrB();
                    txbNameClass.Text = "";
                }
                else
                    MessageBox.Show("Данный класс уже существует!");
                //{
                //    ShowListClass();
                //    countClass = listClass.Count();
                //    MessageBox.Show(countConcept + "  " + countClass);
                //    TransformArrB(nameClass);
                //    ShowArrB();
                //}


            }
            else
                MessageBox.Show("Введите название класса!");
        }


        void TransformArrB(string nameClass)
        {
            int indexEl = listClass.IndexOf(nameClass);
            for (int i = 0; i < countConcept; i++)
            {
                bool cbVal = Convert.ToBoolean(dgvLearn.Rows[i].Cells[1].Value);
                //for (int j =0; j < countConcept; j++)
                for (int k = 0; k < countClass; k++)
                {

                    if (k == indexEl)
                    {
                        if (cbVal)
                            arrB[i, indexEl] += (1 * Convert.ToInt32(nUDStep.Value));
                        //else
                        //    arrB[i, indexEl] += 0;
                    }
                    else
                    {
                        if (cbVal)
                            arrB[i, k] -= (1 * Convert.ToInt32(nUDStep.Value));
                        //else
                        //    arrB[i, indexEl] -= 0;
                    }
                }
            }
        }

        private void btnLearn_Click(object sender, EventArgs e)
        {
            if (combClass.SelectedItem != null)
            {
                if (TestSelectedConcept(dgvLearn))
                {
                    string nameClass = combClass.SelectedItem.ToString();
                    TransformArrB(nameClass);
                    if (cbOnOffGipercube.Checked)
                        ReturnValueOnFaceGipercube();
                    ShowArrB();
                }
                else
                    MessageBox.Show("Необходимо выбрать хотя бы один призанк!");
            }
            else
                MessageBox.Show("Необходимо выбрать класс!");
        }

        bool TestSelectedConcept(DataGridView dg)
        {
            int countSelect = 0;
            for (int i = 0; i < countConcept; i++)
            {
                if (Convert.ToBoolean(dg.Rows[i].Cells[1].Value))
                    countSelect++;
            }
            if (countSelect == 0)
                return false;
            return true;
        }
        private void btnQustion_Click(object sender, EventArgs e)
        {
            if (listConcept.Count > 0 && listClass.Count > 0)
            {
                if (TestSelectedConcept(dgvExp))
                {
                    int[] resMultiply = MultiplyMatrix();
                    string answer = GetAnswer(resMultiply);
                    txbRes.Text = answer;
                }
                else
                    MessageBox.Show("Необходимо выбрать хотя бы один призанк!");
            }
            else
                MessageBox.Show("Список концептов или классов пуст!");
        }
        int[] GetObjectExpertise()
        {
            int[] res = new int[dgvExp.Rows.Count];
            for (int i = 0; i < dgvExp.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvExp.Rows[i].Cells[1].Value))
                    res[i] = 1;
                //else
                //    res[i] = 0;
            }
            return res;
        }

        int[] MultiplyMatrix()
        {
            int[] newObj = GetObjectExpertise();
            int[] res = new int[countClass];
            for (int i = 0; i < countClass; i++)
                for (int j = 0; j < countConcept; j++)
                    res[i] += newObj[j] * arrB[j, i];
            return res;
        }
        
        string GetAnswer(int[] val)
        {
            string answer = "";
            int max = val[0];
            for (int i = 0; i < val.GetLength(0); i++)
                if (max < val[i])
                    max = val[i];
            List<int> listMaxIndex = new List<int>();
            for (int i = 0; i < val.GetLength(0); i++)
                if (val[i] == max)
                    listMaxIndex.Add(i);
            for (int i = 0; i < listMaxIndex.Count; i++)
                answer += listClass[listMaxIndex[i]].ToString() + " ";
            return answer;
        }

        private void buttonNew_Click(object sender, EventArgs e)
        {
            CleanAll();
        }

        void CleanAll()
        {
            listConcept = new List<string>();
            listClass = new List<string>();
            arrB = new int[1000, 100];
            step = 1;
            countConcept = 0;
            countClass = 0;
            pathFile = "";
            cbOnOffGipercube.Checked = true;
            nUDStep.Value = 1;
            ShowArrB();
            ShowListConcept();
            ShowListClass();
            ShowListClassComBox();
            ShowConceptInDg(dgvExp);
            ShowConceptInDg(dgvLearn);
  
        }

        private void dgvLearn_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //DataGridView dg = sender as DataGridView;
            //dg.Rows[e.RowIndex].HeaderCell.Visible = false;
           
            //dg.Rows[e.RowIndex].HeaderCell.Value =
            //    (e.RowIndex + 1).ToString();

        }

        private void dgvLearn_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Delete)
            {
                int a = dgvLearn.CurrentRow.Index;
       
                dgvLearn.Rows.Remove(dgvLearn.Rows[a]);
            }
        }

        private void buttonCleanMatrixB_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < countClass; i++)
                for (int j = 0; j < countConcept; j++)
                    arrB[j, i] = 0;

            if (countClass > 0)
                ShowArrB();
        }
    }
}
