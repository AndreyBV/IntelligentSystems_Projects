using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EG
{
    class EG
    {
        public int[,] arr = new int[3, 3];
        int g;
        int h;
        int n;
        int tmp;

        double f;
        int posEnter;
        bool list;
        int name;
        int nameParent;
        int[] nullCellParent = new int[2];
        public double testA;
        public double testB;
        public double testN;
        public int G
        {
            get { return g; }
            set { g = value; }
        }
        public int H
        {
            get { return h; }
            set { h = value; }
        }
        public int N
        {
            get { return n; }
            set { n = value; }
        }
        public int Tmp
        {
            get { return tmp; }
            set { tmp = value; }
        }
        //public int R
        //{
        //    get { return r; }
        //    set { r = value; }
        //}
        public double F
        {
            get { return f = ((testB * h + testA * g + testN *n ) / (tmp)) ; } /*1000*(n)**/
        }
        public int PosEnter
        {
            get { return posEnter; }
            set { posEnter = value; }
        }
        public bool Lis
        {
            get { return list; }
            set { list = value; }
        }
        public int Name
        {
            get { return name; }
            set { name = value; }
        }
        public int NameParent
        {
            get { return nameParent; }
            set { nameParent = value; }
        }
        public int[] NullCellParent
        {
            get { return nullCellParent; }
            set { nullCellParent = value; }
        }


        public EG(int[,] arr, int g, int h, int n, int tmp, int posEnter,int name, int nameParent, int[] nulCellParent, bool list, double A, double B, double N)
        {
            this.arr = arr;
            this.g = g;
            this.h = h;
            this.n = n;
            this.tmp = tmp;
            this.posEnter = posEnter;
            this.name = name;
            this.nameParent = nameParent;
            this.nullCellParent = nulCellParent;
            this.list = list;
            this.testA = A;
            this.testB = B;
            this.testN = N;
        }

        public int this[int x, int y]
        {
            set
            {
                arr[x,y] = value;
            }

            get
            {
                return arr[x,y];
            }
        }

    }
}
