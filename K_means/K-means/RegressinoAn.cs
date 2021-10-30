using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_means
{
    public partial class RegressinoAn : Form
    {
        public RegressinoAn()
        {
            InitializeComponent();
           // BuildDgvRa();
        }


        public List<KeyValuePair<string, List<double>>> listPriz = new List<KeyValuePair<string, List<double>>>();
        public int countColParametrs;
        public int countAllPriz;
        public int countRowObj;
        int indexPow;
        int indexMult;
        List<int> listIndexFV = new List<int>();
        List<double> listDetermination = new List<double>();

        private void RegressinoAn_Shown(object sender, EventArgs e)
        {
            BuildDgvRa();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            GetPowEvenPriz();
            //dgvBaseRa.Rows.Add();
            //Вычисление произведений параметров между собой
            GetPairMultiply();

            //Вычисление произведений параметров на резльтат функции
            GetMultiplyFunPriz();
            //MessageBox.Show(indexPow + " " + indexMult + " " + listIndexFV[1]);
            GetDetermAllMatrix();
        }

        void BuildDgvRa()
        {
            for (int i = 0; i < listPriz.Count; i++)
            {
                dgvBaseRa.Columns.Add("", "");
            }
            for (int i = 0; i < listPriz[0].Value.Count + 1; i++)
            {
                dgvBaseRa.Rows.Add();
            }
            dgvBaseRa.Rows.Add();
            double sum = 0;
            for (int i = 0; i < listPriz.Count; i++)
            {

                for (int j = 0; j < listPriz[0].Value.Count; j++)
                {
                    if (i > countColParametrs - 1)
                    {
                        dgvBaseRa.Rows[j].Cells[i].Style.BackColor = Color.LightGreen;
                        dgvBaseRa.Rows[j + 1].Cells[i].Style.BackColor = Color.LightGreen;
                    }
                    if (j == 0)
                    {
                        dgvBaseRa.Rows[j].Cells[i].Value = listPriz[i].Key;
                    }
                    dgvBaseRa.Rows[j + 1].Cells[i].Value = listPriz[i].Value[j];
                    sum += listPriz[i].Value[j];
                    if (j == listPriz[0].Value.Count - 1)
                    {
                        dgvBaseRa.Rows[dgvBaseRa.Rows.Count - 1].Cells[i].Value = sum;
                        dgvBaseRa.Rows[dgvBaseRa.Rows.Count - 1].Cells[i].Style.BackColor = Color.LightBlue;
                    }
                }
                sum = 0;
            }
        }
        void GetPowEvenPriz()
        {
            for (int i = 0; i < countColParametrs; i++)
            {
                dgvBaseRa.Columns.Add("pow","pow");
            }
            double sum = 0;
            for (int i = 0; i < countColParametrs; i++)
            {
                if (i == 0)
                    indexPow = i + countAllPriz;
                dgvBaseRa.Rows[0].Cells[i + countAllPriz].Value = dgvBaseRa.Rows[0].Cells[i].Value + "^2";
                for (int j = 1; j < dgvBaseRa.Rows.Count - 1; j++)
                {
                    dgvBaseRa.Rows[j].Cells[i + countAllPriz].Value = Math.Pow(Convert.ToDouble(dgvBaseRa.Rows[j].Cells[i].Value), 2);
                    sum += Math.Pow(Convert.ToDouble(dgvBaseRa.Rows[j].Cells[i].Value), 2);
                    if (j == dgvBaseRa.Rows.Count - 1 - 1)
                    {
                        dgvBaseRa.Rows[j + 1].Cells[i + countAllPriz].Value = sum;
                        dgvBaseRa.Rows[j + 1].Cells[i + countAllPriz].Style.BackColor = Color.LightBlue;
                    }
                }
                sum = 0;
            }

        }
        void GetPairMultiply()
        {
            double sum = 0;
            for (int i = 0; i < countColParametrs; i++)
            {
                for (int j = i + 1; j < countColParametrs; j++)
                {
                    if (i == 0 && j == i + 1)
                    {
                        indexMult = dgvBaseRa.Columns.Count - 1;
                        //MessageBox.Show(indexMult+"");
                    }
                    dgvBaseRa.Columns.Add("M","M");
                    dgvBaseRa.Rows[0].Cells[dgvBaseRa.Columns.Count - 1].Value = dgvBaseRa.Rows[0].Cells[i].Value + "*" + dgvBaseRa.Rows[0].Cells[j].Value;
                    for (int k = 1; k < dgvBaseRa.Rows.Count - 1; k++)
                    {
                        dgvBaseRa.Rows[k].Cells[dgvBaseRa.Columns.Count - 1].Value = Convert.ToDouble(dgvBaseRa.Rows[k].Cells[i].Value) * Convert.ToDouble(dgvBaseRa.Rows[k].Cells[j].Value);
                        sum += Convert.ToDouble(dgvBaseRa.Rows[k].Cells[i].Value) * Convert.ToDouble(dgvBaseRa.Rows[k].Cells[j].Value);
                        if (k == dgvBaseRa.Rows.Count - 1 - 1)
                        {
                            dgvBaseRa.Rows[k + 1].Cells[dgvBaseRa.Columns.Count - 1].Value = sum;
                            dgvBaseRa.Rows[k + 1].Cells[dgvBaseRa.Columns.Count - 1].Style.BackColor = Color.LightBlue;
                        }
                    }
                    sum = 0;
                }
            }
        }
        void GetMultiplyFunPriz()
        {

            for (int i = 0; i < countRowObj + 2; i++)
            {
                dgvBaseRa.Rows.Add("");
            }
            double sum = 0;
            int nowCol = 0;
            for (int i = countColParametrs; i < countAllPriz; i++)
            {
                listIndexFV.Add(nowCol);
                for (int j = 0; j < countColParametrs; j++)
                {
                    //
                    dgvBaseRa.Rows[countRowObj + 2].Cells[nowCol].Value = dgvBaseRa.Rows[0].Cells[i].Value + "*" + dgvBaseRa.Rows[0].Cells[j].Value;
                    for (int k = 0; k < countRowObj; k++)
                    {
                        dgvBaseRa.Rows[k + countRowObj + 3].Cells[nowCol].Value = Convert.ToDouble(dgvBaseRa.Rows[k + 1].Cells[i].Value) * Convert.ToDouble(dgvBaseRa.Rows[k + 1].Cells[j].Value);
                        sum += Convert.ToDouble(dgvBaseRa.Rows[k + 1].Cells[i].Value) * Convert.ToDouble(dgvBaseRa.Rows[k + 1].Cells[j].Value);
                        if (k == countRowObj - 1)
                        {
                            dgvBaseRa.Rows[k + countRowObj + 4].Cells[nowCol].Value = sum;
                            dgvBaseRa.Rows[k + countRowObj + 4].Cells[nowCol].Style.BackColor = Color.LightBlue;
                        }
                    }
                    sum = 0;
                    nowCol++;
                    if (nowCol > dgvBaseRa.Columns.Count)
                        dgvBaseRa.Columns.Add("M", "M");
                }
            }
        }
        void GetDetermAllMatrix()
        {
            double[,] matrix = new double[countColParametrs + 1, countColParametrs + 1];
            matrix[0, 0] = countRowObj;
            for (int i = 1; i < countColParametrs + 1; i++)
            {
                matrix[i, i] = Convert.ToDouble(dgvBaseRa.Rows[countRowObj + 1].Cells[indexPow + i - 1].Value);
                matrix[i, 0] = Convert.ToDouble(dgvBaseRa.Rows[countRowObj + 1].Cells[i - 1].Value);
                matrix[0, i] = Convert.ToDouble(dgvBaseRa.Rows[countRowObj + 1].Cells[i - 1].Value);
            }
            int indM = 0;
            //MessageBox.Show(indexMult+"");
            indexMult++;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = i + 1; j < matrix.GetLength(0); j++)
                {
                    matrix[i, j] = Convert.ToDouble(dgvBaseRa.Rows[countRowObj + 1].Cells[indexMult + indM].Value);
                    matrix[j, i] = Convert.ToDouble(dgvBaseRa.Rows[countRowObj + 1].Cells[indexMult + indM].Value);
                    indM++;
                }
            }
            //string mm = "";
            //for (int i = 0; i < matrix.GetLength(0); i++)
            //{
            //    for (int j = 0; j < matrix.GetLength(1); j++)
            //    {
            //        mm += matrix[i, j] + "  ";
            //    }
            //    mm += "\r\n";
            //}
            //MessageBox.Show(mm);

            double resDet = Determ(matrix);
            listDetermination.Add(resDet);

            double[,] matrixTmp = new double[countColParametrs + 1, countColParametrs + 1];
       

            int nowRow = 0;
            int oldPos = 0;
            int countY = countAllPriz - countColParametrs;
            int indexY = countColParametrs;

            while (countAllPriz - 1 - indexY >= 0)
            {
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            matrixTmp[i, j] = matrix[i, j];
                        }
                    }
                    nowRow = oldPos;
                    for (int l = 1; l < matrix.GetLength(1); l++)
                    {
                        matrixTmp[l, k] = Convert.ToDouble(dgvBaseRa.Rows[(countRowObj + 1) * 2 + 1].Cells[nowRow].Value);
                        matrixTmp[0, k] = Convert.ToDouble(dgvBaseRa.Rows[countRowObj + 1].Cells[indexY].Value);
                        nowRow++;
                    }

                    //string str = "";
                    //for (int i = 0; i < matrixTmp.GetLength(0); i++)
                    //{
                    //    for (int j = 0; j < matrixTmp.GetLength(1); j++)
                    //    {
                    //        str += matrixTmp[i, j] + "  ";
                    //    }
                    //    str += "\r\n";
                    //}
                    //MessageBox.Show(str);

                    resDet = Determ(matrixTmp);
                    listDetermination.Add(resDet);

                }
                oldPos += countColParametrs;
                indexY++;
            }


            string res = "";
            int nowDetInList = 1;
            for (int i = countColParametrs; i < countAllPriz; i++)
            {
                res = dgvBaseRa.Rows[0].Cells[i].Value.ToString() + " = ";
                for (int j = 0; j < countColParametrs; j++)
                {
                    res += (listDetermination[nowDetInList] / listDetermination[0]) + "*" + dgvBaseRa.Rows[0].Cells[j].Value.ToString();
                    nowDetInList++;
                    if (listDetermination[nowDetInList] / listDetermination[0] >= 0)
                        res += "+";
                    if (j == countColParametrs - 1)
                    {
                        res += (listDetermination[nowDetInList] / listDetermination[0]);
                        nowDetInList++;
                    }
                }
                rtb.Text += res + "\r\n";
                //MessageBox.Show(res);
            }


            //for (int i = 1; i < listDetermination.Count; i++)
            //{


            //    MessageBox.Show((listDetermination[i] / listDetermination[0]) + "");
                
            //}


            //string tmp = "";
            //for (int i = 0; i < listDetermination.Count; i++)
            //{
            //    tmp += listDetermination[i] + "  " ;

            //}
            //MessageBox.Show(tmp);

        }

      
        //Вычисление определителя
        public static double Determ(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception(" Число строк в матрице не совпадает с числом столбцов");
            double det = 0;
            int Rank = matrix.GetLength(0);
            if (Rank == 1) det = matrix[0, 0];
            if (Rank == 2) det = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            if (Rank > 2)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    det += Math.Pow(-1, 0 + j) * matrix[0, j] * Determ(GetMinor(matrix, 0, j));
                }
            }
            return det;
        }
        public static double[,] GetMinor(double[,] matrix, int row, int column)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1)) throw new Exception(" Число строк в матрице не совпадает с числом столбцов");
            double[,] buf = new double[matrix.GetLength(0) - 1, matrix.GetLength(0) - 1];
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if ((i != row) || (j != column))
                    {
                        if (i > row && j < column) buf[i - 1, j] = matrix[i, j];
                        if (i < row && j > column) buf[i, j - 1] = matrix[i, j];
                        if (i > row && j > column) buf[i - 1, j - 1] = matrix[i, j];
                        if (i < row && j < column) buf[i, j] = matrix[i, j];
                    }
                }
            return buf;
        }

    }
}

