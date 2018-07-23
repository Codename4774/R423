using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace R423.Page
{
    /// <summary>
    /// Логика взаимодействия для ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : System.Windows.Controls.Page
    {
        private Point _lastDragPoint;
        private List<string> _path;
        private int _currentIndex = 0;
        private float _scale = 1;
        private float MAX_SCALE = 6;
        private float SCALE_STEP = 0.5F;

        public ImageWindow(List<String> imgPath)
        {
            InitializeComponent();
            _path = imgPath;
            CurrentImage.Source = new BitmapImage(new Uri(_path[_currentIndex], UriKind.Relative));
        }

        private void ImgGrid_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ImgGrid.ReleaseMouseCapture();
        }

        private void ImgGrid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                _scale = _scale >= MAX_SCALE ? _scale : _scale + SCALE_STEP;
            else
                _scale = _scale <= 1 ? _scale : _scale - SCALE_STEP;

            var pos = e.GetPosition(CurrentImage);
            ImgScale.CenterX = pos.X;
            ImgScale.CenterY = pos.Y;
            ImgScale.ScaleX = _scale;
            ImgScale.ScaleY = _scale;
        }

        private void ImgGrid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImgGrid.CaptureMouse();
        }

        private void ImgGrid_MouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(ImgGrid);
            if (ImgGrid.IsMouseCaptured)
            {
                ImgScale.CenterX -= (pos.X - _lastDragPoint.X) * 1.2;
                ImgScale.CenterY -= (pos.Y - _lastDragPoint.Y) * 1.2;
            }
            _lastDragPoint = pos;
        }

        private void ImgGrid_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            _scale = 1;
            if (++_currentIndex > _path.Count - 1)
                _currentIndex = 0;
            CurrentImage.Source = new BitmapImage(new Uri(_path[_currentIndex], UriKind.Relative));
        }
    }
}
