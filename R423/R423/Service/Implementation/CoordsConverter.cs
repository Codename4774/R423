using R423.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace R423.Service.Implementation
{
    public class CoordsConverter : ICoordsConverter
    {
        private float _xCompressionCoef;

        private float _yCompressionCoef;

        private int _x;

        private int _y;


        public CoordsConverter(IResourceManager resourceManager)
        {
            _x = System.Convert.ToInt32(resourceManager.GetString("xPictureSize"));
            _y = System.Convert.ToInt32(resourceManager.GetString("yPictureSize"));
        }


        public void SetNewCompression(int oldX, int oldY, int newX, int newY)
        {
            _xCompressionCoef = newX / oldX;
            _yCompressionCoef = newY / oldY;
        }

        public void SetNewCompression(int newX, int newY)
        {
            _xCompressionCoef = (float)newX / (float)_x;
            _yCompressionCoef = (float)newY / (float)_y;
        }

        public void Convert(ref Point point)
        {
            point.X = point.X * _xCompressionCoef;
            point.Y = point.Y * _yCompressionCoef;
        }

        public void Convert(ref Polyline polyLine)
        {
            for (int i = 0; i < polyLine.Points.Count; i++)
            {
                var temp = polyLine.Points[i];
                Convert(ref temp);
                polyLine.Points[i] = temp;
            }
        }
    }
}
