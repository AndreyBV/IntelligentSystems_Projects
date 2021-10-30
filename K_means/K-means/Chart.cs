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
using ZedGraph;
//using GeoAPI.Geometries;
//using NetTopologySuite.Geometries;

namespace K_means
{
    public partial class Chart : Form
    {
        public Chart()
        {
            InitializeComponent();
        }

        public Dictionary<string, List<double>> point = new Dictionary<string, List<double>>();
        public List<List<double>> listCenterPoint = new List<List<double>>();
        public List<double> classEl = new List<double>();
        public double minAxis;
        public double maxAxis;

        System.Drawing.Point pt = new System.Drawing.Point(0,0);
        int countElInRow = 0;

        public static List<NetTopologySuite.Geometries.Point> GetContour(List<NetTopologySuite.Geometries.Point> pts)
        {
            List<NetTopologySuite.Geometries.Point> resVal = new List<NetTopologySuite.Geometries.Point>();
            List<GeoAPI.Geometries.Coordinate> coordinates = new List<GeoAPI.Geometries.Coordinate>();
            foreach (var P in pts)
                coordinates.Add(new GeoAPI.Geometries.Coordinate(P.X, P.Y));
            var multiPoint = NetTopologySuite.Geometries.Geometry.DefaultFactory.CreateMultiPoint(coordinates.ToArray());
            multiPoint.Normalize();
            var hullGeom = multiPoint.ConvexHull();
            foreach (var c in hullGeom.Coordinates)
                resVal.Add(new NetTopologySuite.Geometries.Point(c.X, c.Y));

            return resVal;
        }
        public void DrawAllProections()
        {
            for (int i = 0; i < point.Count; i++)
                for (int j = i + 1; j < point.Count; j++)
                {
                    DrawGraph(point.ElementAt(i).Key, point.ElementAt(i).Value, point.ElementAt(j).Key, point.ElementAt(j).Value, pt, i, j);
                    pt.X += 370;
                    countElInRow++;
                    if (countElInRow == 4)
                    {
                        pt.X = 0;
                        pt.Y += 300;
                        countElInRow = 0;
                    }
                }
        }
        public void DrawGraph(string oneName, List<double> oneList, string twoName, List<double> twoList, System.Drawing.Point pt, int one, int two)
        {
            ZedGraphControl zedGraph = new ZedGraphControl();
            zedGraph.Height = 300;
            zedGraph.Width = 370;
            zedGraph.Location = pt;
            Controls.Add(zedGraph);
            // Получим панель для рисования
            GraphPane pane = zedGraph.GraphPane;
            pane.Title.FontSpec.Size = 18;
            pane.Title.Text = "Проекция: " + oneName + " - " + twoName;
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            // Очистим список кривых на тот случай, если до этого сигналы уже были нарисованы
            pane.CurveList.Clear();

            // Создадим список точек
            PointPairList listCP = new PointPairList();

            // Заполняем список точек
         

            foreach (var el in listCenterPoint)
            {
                double x = 0;
                double y = 0;
                x = el.ElementAt(one);
                y = el.ElementAt(two);

                listCP.Add(x, y);
            }
            PointPairList listBP= new PointPairList();

            bool onOffStr = true;

        

            foreach (var el in classEl)
            {
                listBP = new PointPairList();
                List<NetTopologySuite.Geometries.Point> lp = new List<NetTopologySuite.Geometries.Point>();

                int findOne = 0;
                double xTmp = 0;
                double yTmp = 0;
                //for (int i = 0; i < 2; i += 2)
                    for (int j = 0; j < oneList.Count; j++)
                    {
                        if (classEl.ElementAt(j) == el)
                        {
                            double x = 0;
                            double y = 0;
                            x = oneList.ElementAt(j);
                            y = twoList.ElementAt(j);
                            if (findOne == 0)
                            {
                                xTmp = x;
                                yTmp = y;
                            }
                            findOne++;

                            NetTopologySuite.Geometries.Point p = new NetTopologySuite.Geometries.Point(oneList.ElementAt(j), twoList.ElementAt(j));
                            lp.Add(p);
                            listBP.Add(x, y);
                        }
                    }
  
                lp = GetContour(lp);

                PointPairList listBPContur = new PointPairList();
                foreach (var elp in lp)
                {
                    listBPContur.Add(elp.X, elp.Y);
                }


                string str = "";
                if (onOffStr)
                    str = "Точка объекта";
                onOffStr = false;
                Random rnd = new Random();
                Thread.Sleep(25);

                LineItem basePoint = pane.AddCurve(str, listBP, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)), SymbolType.Circle);
                basePoint.Line.IsVisible = false;

                basePoint.Symbol.Fill.Color = Color.Blue;
                basePoint.Symbol.Fill.Type = FillType.Solid;
                basePoint.Symbol.Size = 7;

                LineItem basePointContur = pane.AddCurve("", listBPContur, Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255)), SymbolType.Circle);
                basePointContur.Line.IsVisible = true;

                basePointContur.Symbol.Fill.Color = Color.Blue;
                basePointContur.Symbol.Fill.Type = FillType.Solid;
                basePointContur.Symbol.Size = 7;
            }

            LineItem pointCenter = pane.AddCurve("Центр класса", listCP, Color.Red, SymbolType.Triangle);
            pointCenter.Line.IsVisible = false;
            pointCenter.Symbol.Fill.Color = Color.Red;
            pointCenter.Symbol.Fill.Type = FillType.Solid;
            pointCenter.Symbol.Size = 10;

            // Устанавливаем интересующий нас интервал по оси X
            AxisLabel al = new AxisLabel(oneName, "Microsoft Sans Serif", 18, Color.Black, false, false, false);
            pane.XAxis.Title = al;
            pane.XAxis.Scale.Min = 0;
            pane.XAxis.Scale.Max = maxAxis;

            // Устанавливаем интересующий нас интервал по оси Y
            al = new AxisLabel(twoName, "Microsoft Sans Serif", 18, Color.Black, false, false, false);
            pane.YAxis.Title = al;
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = maxAxis;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            // В противном случае на рисунке будет показана только часть графика, 
            // которая умещается в интервалы по осям, установленные по умолчанию
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();

           

        }

    }
}
