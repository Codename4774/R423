using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace R423.Service.Interface
{
    public interface ICoordsConverter
    {
        void Convert(ref Point point);
        void Convert(ref Polyline polyLine);
        void Convert(ref PointCollection points);
        void SetNewCompression(int oldX, int oldY, int newX, int newY);
        void SetNewCompression(int newX, int newY);
        void AddValueToPoints(ref PointCollection points, int addedX, int addedY);
    }
}
