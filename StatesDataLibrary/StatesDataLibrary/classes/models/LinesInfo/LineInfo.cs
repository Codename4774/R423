using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using System.Xml.Schema;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace StatesDataLibrary.Classes.Models.LinesInfo
{
    [Serializable]
    public class LineInfo
    {
        public readonly Polyline PartOfLine;


        public LineInfo(Polyline partOfLine)
        {
            this.PartOfLine = partOfLine;
        }

        public System.Drawing.Point this[int index]
        {
            get { return new System.Drawing.Point((int)PartOfLine.Points[index].X, (int)PartOfLine.Points[index].Y); }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("", 1000);

            for (int i = 0; i < PartOfLine.Points.Count; i++)
            {
                result.Append(" X"+Convert.ToString(i)+ ": " + Convert.ToString(this[i].X));
                result.Append(" Y"+Convert.ToString(i)+ ": "  + Convert.ToString(this[i].Y));
            }


            return result.ToString();
        }

        public static Polyline CreatePolylineFromPointsList(List<System.Drawing.Point> points)
        {
            Polyline result = new Polyline();
            int i = 0;
            foreach (var point in points)
            {
                result.Points.Add(new System.Windows.Point(points[i].X, points[i].Y));
                i++;
            }

            return result;
        }
        public static List<System.Drawing.Point> GetPointsFromPolyline(Polyline polyline)
        {
            List<System.Drawing.Point> result = new List<System.Drawing.Point>();
            foreach (var point in polyline.Points)
            {
                result.Add(new System.Drawing.Point((int)point.X, (int)point.Y));
            }

            return result;
        }

        public void ReverseDirection()
        {
            PartOfLine.Points = new PointCollection(PartOfLine.Points.Reverse()); 
        }
    }
}