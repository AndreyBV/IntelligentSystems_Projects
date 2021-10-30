using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            GetStructDG(dgBase);
            GetStructDG(dgTarget);
            GetDG(dgBase);
            GetDG(dgTarget);
            dgBase.Rows[0].Cells[0].Value = 2;
            dgBase.Rows[0].Cells[1].Value = 1;
            dgBase.Rows[0].Cells[2].Value = 6;
            dgBase.Rows[1].Cells[0].Value = 4;
            dgBase.Rows[1].Cells[1].Value = 0;
            dgBase.Rows[1].Cells[2].Value = 8;
            dgBase.Rows[2].Cells[0].Value = 7;
            dgBase.Rows[2].Cells[1].Value = 5;
            dgBase.Rows[2].Cells[2].Value = 3;

            dgTarget.Rows[0].Cells[0].Value = 1;
            dgTarget.Rows[0].Cells[1].Value = 2;
            dgTarget.Rows[0].Cells[2].Value = 3;
            dgTarget.Rows[1].Cells[0].Value = 8;
            dgTarget.Rows[1].Cells[1].Value = 0;
            dgTarget.Rows[1].Cells[2].Value = 4;
            dgTarget.Rows[2].Cells[0].Value = 7;
            dgTarget.Rows[2].Cells[1].Value = 6;
            dgTarget.Rows[2].Cells[2].Value = 5;

            //dgBase.Rows[0].Cells[0].Value = 2;
            //dgBase.Rows[0].Cells[1].Value = 4;
            //dgBase.Rows[0].Cells[2].Value = 3;
            //dgBase.Rows[1].Cells[0].Value = 1;
            //dgBase.Rows[1].Cells[1].Value = 8;
            //dgBase.Rows[1].Cells[2].Value = 5;
            //dgBase.Rows[2].Cells[0].Value = 7;
            //dgBase.Rows[2].Cells[1].Value = 0;
            //dgBase.Rows[2].Cells[2].Value = 6;

            //dgTarget.Rows[0].Cells[0].Value = 1;
            //dgTarget.Rows[0].Cells[1].Value = 2;
            //dgTarget.Rows[0].Cells[2].Value = 3;
            //dgTarget.Rows[1].Cells[0].Value = 4;
            //dgTarget.Rows[1].Cells[1].Value = 5;
            //dgTarget.Rows[1].Cells[2].Value = 6;
            //dgTarget.Rows[2].Cells[0].Value = 7;
            //dgTarget.Rows[2].Cells[1].Value = 8;
            //dgTarget.Rows[2].Cells[2].Value = 0;
            for (int i =0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    baseArr[i, j] = Convert.ToInt32(dgTarget.Rows[i].Cells[j].Value);
                    myArr[i,j] = Convert.ToInt32(dgBase.Rows[i].Cells[j].Value);
                }



      

        }
        DataGridView GetStructDG(DataGridView dg)
        {
            DataTable tmp = new DataTable();
            for (int i = 0; i < 3; i++)
            {
                tmp.Columns.Add();
                tmp.Rows.Add();
            }
            dg.DataSource = tmp;
            return dg;
        }
        DataGridView GetDG(DataGridView dgTmp)
        {
            //DragDropDG d = new DragDropDG();
            //DAD dgTmp = new DAD();
            //Controls.Add(dgTmp);
            //dgTmp.Visible = false;
            dgTmp.BackgroundColor = Color.White;
            dgTmp.ReadOnly = true;
            dgTmp.AllowUserToResizeColumns = false;
            dgTmp.AllowUserToResizeRows = false;
            dgTmp.AllowUserToAddRows = false;
            dgTmp.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgTmp.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;

            dgTmp.RowHeadersVisible = false;
            dgTmp.ColumnHeadersVisible = false;    
            dgTmp.Rows[0].Cells[0].Selected = false;
            return dgTmp;
          
        }

        int[,] baseArr = new int[3, 3];
        int[,] myArr = new int[3, 3];
        List<EG> list = new List<EG>();
        List<DAD> dad = new List<DAD>();
        //int numSelect = 0;
        int nameEl = 0;
        int maxH = -1;
        int countOptima = 0;
        List<EG> elOpt = new List<EG>();
        double A = 7;
        double B = 3;
        double C = 3;
        //List<int[]> testAB = new List<int[]>();

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DAD da in dad)
                Controls.Remove(da);
            dad.Clear();
            A = Convert.ToDouble(textBoxA.Text);
            B = Convert.ToDouble(textBoxB.Text);
            C = Convert.ToDouble(textBoxC.Text);
            list.Clear();
            //numSelect = 0;
            nameEl = 0;
            maxH = -1;
            countOptima = 0;
            elOpt.Clear();

            int[] nullCellParent = { -1, -1 };
            int l = FindN(myArr);
            EG el = new EG(myArr, 7, -1, l, list.Count, 0, 0, -1, nullCellParent, false, A, B, C);
            list.Add(el);
            GetAllMatrix(el);
            FindNextMatrix();

            //Random rnd = new Random();
            //while (true)
            //{
            //    //A = rnd.Next(1, 15);
            //    //Thread.Sleep(30);
            //    //B = rnd.Next(1, 15);
            //    //Thread.Sleep(30);
            //    //C = rnd.Next(1, 15);
            //    //Thread.Sleep(30);

            //    A = rnd.NextDouble() * (15 - 1) + 1; ;
            //    Thread.Sleep(30);
            //    B = rnd.NextDouble() * (15 - 1) + 1;
            //    Thread.Sleep(30);
            //    C = rnd.NextDouble() * (15 - 1) + 1;
            //    Thread.Sleep(30);
            //    //MessageBox.Show(A + " " + B + " " + C);

            //    list.Clear();
            //    numSelect = 0;
            //    nameEl = 0;
            //    maxH = -1;
            //    countOptima = 0;
            //    elOpt.Clear();


            //    nullCellParent[0] = -1;
            //    nullCellParent[1] = -1;
            //    l = FindC(myArr);
            //    r1 = FindDifCol(myArr);
            //    r2 = FindDifRow(myArr);
            //    el = new EG(myArr, 7, -1, l, r1, r2, 0, 0, -1, nullCellParent, false, A, B, C, R1, R2);
            //    list.Add(el);
            //    GetAllMatrix(el);
            //    FindNextMatrix();

            //    if (list.Count < 108)
            //    {
            //        textBoxA.Text = A.ToString();
            //        textBoxB.Text = B.ToString();
            //        textBoxC.Text = C.ToString();
            //        return;
            //    }
            //}


        }
        int FindN(int[,] arr)
        {
            int lenPath = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    int nowEl = arr[i, j];
                    for (int k = 0; k < 3; k++)
                        for (int z = 0; z < 3; z++)
                            if (nowEl == baseArr[k, z])
                                lenPath += Math.Abs(k - i) + Math.Abs(z - j);

                }
            return lenPath;
        }


        //int FindDifCol(int[,] arr)
        //{
        //    int count = 0;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        int k = 0;
        //        for (int j = 0; j < 3; j++)
        //            if (arr[i, j] == baseArr[i, j])
        //                k++;
        //        if (k == 3)
        //            count++;
        //    }
        //    return 3 - count;

        //}
        //int FindDifRow(int[,] arr)
        //{
        //    int count = 0;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        int k = 0;
        //        for (int j = 0; j < 3; j++)
        //            if (arr[j, i] == baseArr[j, i])
        //                k++;
        //        if (k == 3)
        //            count++;
        //    }
        //    return 3 - count;

        //}

        //A += 0.01;
        //B = A/9;
        //if (list.Count < 620)
        //    MessageBox.Show(A + " " + B + "   " + list.Count);
        //button1_Click(sender, e);

        //for (double i = 0.1; i < 3; i += 0.1)
        //{
        //    for (double j = 0.1; j < 5; j += 0.1)
        //    {
        //        list.Clear();
        //        numSelect = 0;
        //        nameEl = 0;
        //        maxH = -1;
        //        countOptima = 0;
        //        elOpt.Clear();

        //        nullCellParent[0] = -1;
        //        nullCellParent[1] = -1;
        //        el = new EG(myArr, 7, -1, 0, 0, -1, nullCellParent, false, A, B);
        //        list.Add(el);
        //        GetAllMatrix(el);
        //        FindNextMatrix();

        //        A += i;
        //        B = A / j;
        //        if (list.Count < 625)
        //            MessageBox.Show(A + " " + B + "   " + list.Count);
        //    }
        //}

        //button1_Click(sender, e);

        int[,] GetAllMatrix(EG el)
        {
            int[,] res = new int[3,3];

            Point L = new Point(0, -1);
            Point U = new Point(-1, 0);
            Point R = new Point(0, 1);
            Point B = new Point(1, 0);

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (el.arr[i,j] == 0)
                    {
                        //if (i == el.NullCellParent[0] && j == el.NullCellParent[1])
                        //   continue;
                        if (res == null)
                            return res;

                        if (i < 2 && res != null && (i + B.X != el.NullCellParent[0] || j + B.Y != el.NullCellParent[1]))
                            res = MoveCell(el, B);


                        if (i > 0 && res != null && (i + U.X != el.NullCellParent[0] || j + U.Y != el.NullCellParent[1]))
                            res = MoveCell(el, U);

                        if (j > 0 && res != null && (i + L.X != el.NullCellParent[0] || j + L.Y != el.NullCellParent[1]))
                            res = MoveCell(el, L);

                        if (j < 2 && res != null && (i + R.X != el.NullCellParent[0] || j + R.Y != el.NullCellParent[1]))
                            res = MoveCell(el, R);

                    }
                }
            return res;
        }
        int[,] MoveCell(EG el, Point t)
        {
            int[,] tmp = new int[3,3];
            int[] nullCell = new int[2];
            int xn = -1;
            int yn = -1;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                  
                    if (i != xn || j != yn)
                    {
                        tmp[i, j] = el.arr[i, j];
                        if (el.arr[i,j] == 0)
                        {
                            //if (i == el.NullCellParent[0] && j == el.NullCellParent[1])
                            //    return null;
                            int[] nullCellTmp = {i, j};
                            nullCell = nullCellTmp;
                            tmp[i,j] = el.arr[i+t.X,j+t.Y];
                            tmp[i + t.X, j + t.Y] = 0;
                            xn = i + t.X;
                            yn = j + t.Y;
                        }
                    }
                }
            int g = FindG(tmp);
            //MessageBox.Show(el.NullCellParent[0] + " " + el.NullCellParent[1] + "\n\n" + tmp[0, 0] + " " + tmp[0, 1] + " " + tmp[0, 2] + " \n" + tmp[1, 0] + " " + tmp[1, 1] + " " + tmp[1, 2] + " \n" + tmp[2, 0] + " " + tmp[2, 1] + " " + tmp[2, 2]);
            int h = el.H + 1;
            //numSelect++;
            nameEl++;
            el.Lis = false;
            int l = FindN(tmp);
            EG newEl = new EG(tmp, g, h, l, list.Count, 0, nameEl, el.Name, nullCell, true, A, B, C) ; ///numsel-posen
            list.Add(newEl);
            if (g == 0)
            {
                maxH = h;
                return null;
            }

            return tmp;
        }
        int FindG(int[,] arr)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (baseArr[i, j] == arr[i, j])
                        count++;
                }
            return 9 - count;
        }
        int FindMinList()
        {
            double minF = 99999999999999;
            int pos = 0;
            int need = 0;
            foreach (EG el in list)
            {

                if (el.Lis == true && el.F <= minF)
                {
                    minF = el.F;
                    need = pos;
                }
                pos++;

            }
            return need;
        }
        void FindNextMatrix()
        {
            for (int i = 0; i < list.Count; i++)
            {
                i = FindMinList();
                if (GetAllMatrix(list[i]) == null)
                {

                    //MessageBox.Show("Выполнено!");
                    DrawMatrix();
                    return;
                }
            }
        }
      
        void ArrInDG(EG el, Point p)
        {
            DAD dg = new DAD();
            for (int i = 0; i < 3; i++)
            {
                dg.Columns.Add(Convert.ToString(i), Convert.ToString(i));
                dg.Rows.Add();
                if (i == 2)
                {
                    dg.Rows.Add();
                    dg.Columns.Add(Convert.ToString(i), Convert.ToString(i));
                }
            }
            dg.Size = dgBase.Size;
            dg.Height = dgBase.Height + 20;
            dg.Location = p;
            GetDG(dg);
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    if (el.arr[i, j] == 0)
                        dg.Rows[i].Cells[j].Style.BackColor = Color.LightGreen;
                    //MessageBox.Show(el.PosEnter+"");
                    if (el.PosEnter == 100)
                        for (int z = 0; z < 3; z++)
                            for (int x = 0; x < 3; x++)
                                dg.Rows[z].Cells[x].Style.ForeColor = Color.Red;
                    dg.Rows[i].Cells[j].Value = el.arr[i, j];
                    if (i == 2)
                    {
                        dg.Rows[i + 1].Cells[0].Value = el.H;
                        dg.Rows[i + 1].Cells[1].Value = el.G;
                        dg.Rows[i + 1].Cells[2].Value = el.N;
                        dg.Rows[i + 1].Cells[3].Value = el.Tmp;
                        dg.Rows[i].Cells[3].Value = el.F;
                        dg.Rows[i].Cells[3].Style.BackColor = Color.LightSalmon;

                        dg.Columns[3].Width = 50;
                        dg.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                        dg.Rows[i + 1].DefaultCellStyle.BackColor = Color.LightGray;
                        dg.Columns[i + 1].DefaultCellStyle.BackColor = Color.LightGray;
                        dg.Rows[0].Cells[3].Value = el.Name;
                        dg.Rows[1].Cells[3].Value = el.NameParent;
                    }
              
                    //Graphics g = CreateGraphics();
                    //g.DrawLine(new Pen(Color.LightGreen, 2), dg.Location, new Point(300, 480));
                   

                }
            Controls.Add(dg);
            dad.Add(dg);
            dg.ClearSelection();
        }
        void DrawMatrix()
        {
            //MessageBox.Show(list.Count+"");
            //for (int i = 0; i < maxH; i++)
            //{
            //    foreach (EG el in list)
            //        if
            //}


            List<EG> optPath = GetPath(list[list.Count - 1]);

            for (int i = -1; i <= maxH; i++)
            {
                int j = 0;
                foreach (EG el in list)
                    if (el.H == i)
                    {
                        ArrInDG(el, new Point(((j) * (dgBase.Width + 10)), 150 + (i + 1) * (dgBase.Width + 30)));
                        //MessageBox.Show("");
                        j++;
                    }
            }
            this.Paint += new PaintEventHandler(this.Form1_Paint);






            //for (int i = dad.Count-1; i >= 0; i--)
            //{
            //    if
            //    Graphics g = CreateGraphics();
            //    g.DrawLine(new Pen(Color.LightGreen, 3), new Point(100, 80), new Point(300, 480));
            //}

            //if (list.Count < 650)
            //    MessageBox.Show(A + "  " + B);
            textBoxKPD.Text = (optPath.Count + 1) + "/" + list.Count + " = " + ((double)(optPath.Count + 1) / list.Count * 100);
 
            //MessageBox.Show("КПД: " + (optPath.Count + 1) + "/" + list.Count + " = " + ((double)(optPath.Count + 1) / list.Count * 100));
            //MessageBox.Show(list[resIndexEl][0, 0] + " " + list[resIndexEl][0, 1] + " " + list[resIndexEl][0, 2] + " \n" + list[resIndexEl][1, 0] + " " + list[resIndexEl][1, 1] + " " + list[resIndexEl][1, 2] + " \n" + list[resIndexEl][2, 0] + " " + list[resIndexEl][2, 1] + " " + list[resIndexEl][2, 2]);
            //foreach (EG tmp in optPath)
            //    MessageBox.Show(tmp[0, 0] + " " + tmp[0, 1] + " " + tmp[0, 2] + " \n" + tmp[1, 0] + " " + tmp[1, 1] + " " + tmp[1, 2] + " \n" + tmp[2, 0] + " " + tmp[2, 1] + " " + tmp[2, 2]);

        }

        List<EG> GetPath(EG el)
        {
            foreach (EG e in list)
                if (e.Name == el.NameParent)
                {
                    el.PosEnter = 100;
                    countOptima++;
                    elOpt.Add(e);
                    GetPath(e);
                }
            return elOpt;
        
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
        
           
            foreach (DAD d1 in dad)
            {
                foreach (DAD d2 in dad)
                {
                    //MessageBox.Show(d1.Rows[0].Cells[3].Value + "   " + d2.Rows[1].Cells[3].Value);
                    if ((int)d1.Rows[0].Cells[3].Value == (int)d2.Rows[1].Cells[3].Value)
                    {
                        Graphics gr = e.Graphics;
                        Pen p = new Pen(Color.Black, 3/2);// цвет линии и ширина
                        Point p1 = new Point(d2.Location.X + dgBase.Width/2, d2.Location.Y);
                        Point p2 = new Point(d1.Location.X + dgBase.Width / 2, d1.Location.Y+ dgBase.Height + 20);
                        gr.DrawLine(p, p1, p2);// рисуем линию
                        //gr.Dispose();// освобождаем все ресурсы, связанные с отрисовкой
                    }
                }
            }

          
        }



        static void saveLargeForm(Form form, string fileName)
        {
            // yes it may take a while
            form.Cursor = Cursors.WaitCursor;

            // allocate target bitmap and a buffer bitmap
            Bitmap target = new Bitmap(form.DisplayRectangle.Width, form.DisplayRectangle.Height);
            Bitmap buffer = new Bitmap(form.Width, form.Height);
          
            // the vertical pointer
            int y = 0;
            int x = 0;
            var vsc = form.VerticalScroll;
            var hsc = form.HorizontalScroll;
            vsc.Value = 0;
            hsc.Value = 0;
            form.AutoScrollPosition = new Point(0, 0);
            // the scroll amount
            int l = vsc.LargeChange;
            int k = hsc.LargeChange;
            

            Rectangle srcRect = ClientBounds(form);
            Rectangle destRect = Rectangle.Empty;
            Rectangle srcRect1 = ClientBounds(form);
            Rectangle destRect1 = Rectangle.Empty;
            bool done = false;
            bool done1 = false;

            // we'll draw onto the large bitmap with G
            using (Graphics G = Graphics.FromImage(target))
            {

                while (!done)
                {
                //    //hsc = form.HorizontalScroll;
                //    //hsc.Value = 0;
                //    k = hsc.LargeChange;
                //    done1 = false;
                //    srcRect1 = ClientBounds(form);
                //    //destRect1 = Rectangle.Empty;
                //    while (!done1)
                //    {
                //        destRect1 = new Rectangle(x, 0, srcRect1.Width, srcRect1.Height);
                //        form.DrawToBitmap(buffer, new Rectangle(0, 0, form.Width, form.Height));
                //        G.DrawImage(buffer, destRect1, srcRect1, GraphicsUnit.Pixel);
                //        int v1 = hsc.Value;
                //        hsc.Value = hsc.Value + k;
                //        form.AutoScrollPosition = new Point(hsc.Value + k, vsc.Value);
                //        int delta1 = hsc.Value - v1;
                //        done1 = delta1 < k;
                //        x += delta1;

                //    }
                //destRect1 = new Rectangle(x, 0, srcRect1.Width, srcRect1.Height);
                //form.DrawToBitmap(buffer, new Rectangle(0, 0, form.Width, form.Height));
                //G.DrawImage(buffer, destRect1, srcRect1, GraphicsUnit.Pixel);

                destRect = new Rectangle(0, y, srcRect.Width, srcRect.Height);
                form.DrawToBitmap(buffer, new Rectangle(0, 0, form.Width, form.Height));
                G.DrawImage(buffer, destRect, srcRect, GraphicsUnit.Pixel);
                int v = vsc.Value;
                vsc.Value = vsc.Value + l;
                form.AutoScrollPosition = new Point(form.AutoScrollPosition.X, vsc.Value + l);
                int delta = vsc.Value - v;
                done = delta < l;
                y += delta;
            }
            destRect = new Rectangle(0, y, srcRect.Width, srcRect.Height);
            form.DrawToBitmap(buffer, new Rectangle(0, 0, form.Width, form.Height));
            G.DrawImage(buffer, destRect, srcRect, GraphicsUnit.Pixel);
        }
            // write result to disc and clean up
            target.Save(@"c:\Users\Andrei\Desktop\" + fileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
            target.Dispose();
            buffer.Dispose();
            GC.Collect();          // not sure why, but it helped
            form.Cursor = Cursors.Default;
        }

       
        static Rectangle ClientBounds(Form f)
        {
            Rectangle rc = f.ClientRectangle;
            Rectangle rb = f.Bounds;
            int sw = SystemInformation.VerticalScrollBarWidth;
            var vsc = f.VerticalScroll;
            int sh = SystemInformation.HorizontalScrollBarHeight;
            var hsc = f.HorizontalScroll;
            int bw = (rb.Width - rc.Width - (vsc.Visible ? sw : 0)) / 2;
            int th = (rb.Height - rc.Height - (hsc.Visible ? sh : 0)) / 2 + 5;
            return new Rectangle(bw, th + bw, rc.Width, rc.Height);
        }


        private void buttonPrint_Click(object sender, EventArgs e)
        {
            //ActiveForm.VerticalScroll.Value = ActiveForm.Size.Height - 60;
            saveLargeForm(Form1.ActiveForm, "tree");
        }




    }
}

