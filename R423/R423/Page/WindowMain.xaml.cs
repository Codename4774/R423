using R423.ViewModel;
using StatesDataLibrary.Classes.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StatesDataLibrary.Classes.Models.LinesInfo;
using R423.Service.Implementation;
using System.Reflection;
using System.Windows.Interactivity;

namespace R423.Page
{
    /// <summary>
    /// Interaction logic for WindowMain.xaml
    /// </summary>
    public partial class WindowMain : Window
    {
        private Point _lastDragPoint;
        private float _currentScale = 1;
        private float MAX_SCALE = 4;
        private float SCALE_STEP = 0.5F;

        public WindowMain()
        {
            InitializeComponent();
            DataContext = new WindowMainViewModel(CanvasDrawing, ImageScheme);
            var allModes = (DataContext as WindowMainViewModel).AllModes;
            NameCombo.ItemsSource = allModes.Select(el => el.Name).Distinct();
            CanvasDrawing.MouseLeftButtonDown += DrawingLButton_Down;
            CanvasDrawing.MouseLeftButtonUp += DrawingLButton_Up;
            CanvasDrawing.MouseMove += DrawingMouse_Move;
            CanvasDrawing.MouseWheel += DrawingMouse_Wheel;
        }

        private int CurrentPath()
        {
            var allModesList = (DataContext as WindowMainViewModel).AllModes;
            var pathNum = allModesList.Where(el => el.Name == (string)NameCombo.SelectedItem &&
                                                        el.Speed == (string)SpeedCombo.SelectedItem &&
                                                        el.Type == (string)TypeCombo.SelectedItem &&
                                                        el.Direction == (string)DirectionCombo.SelectedItem);
            try
            {
                return pathNum.FirstOrDefault().Id;
            }
            catch(NullReferenceException e)
            {
                return 1;
            }
        }

        private void NameSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var allModesList = (DataContext as WindowMainViewModel).AllModes;
            SpeedCombo.ItemsSource = allModesList.Where(el => el.Name == (string)NameCombo.SelectedItem).Select(el => el.Speed).Distinct();
            TypeCombo.ItemsSource = allModesList.Where(el => el.Name == (string)NameCombo.SelectedItem && 
                                                   el.Speed == (string)SpeedCombo.SelectedItem).Select(el => el.Type).Distinct();
            DirectionCombo.ItemsSource = allModesList.Where(el => el.Name == (string)NameCombo.SelectedItem && 
                                                        el.Speed == (string)SpeedCombo.SelectedItem &&
                                                        el.Type == (string)TypeCombo.SelectedItem).Select(el => el.Direction).Distinct();
            SpeedCombo.SelectedIndex = 0;
            TypeCombo.SelectedIndex = 0;
            DirectionCombo.SelectedIndex = 0;
        }

        private void SpeedSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var allModesList = (DataContext as WindowMainViewModel).AllModes;
            TypeCombo.ItemsSource = allModesList.Where(el => el.Name == (string)NameCombo.SelectedItem && 
                                                   el.Speed == (string)SpeedCombo.SelectedItem).Select(el => el.Type).Distinct();
            DirectionCombo.ItemsSource = allModesList.Where(el => el.Name == (string)NameCombo.SelectedItem &&
                                                        el.Speed == (string)SpeedCombo.SelectedItem && 
                                                        el.Type == (string)TypeCombo.SelectedItem).Select(el => el.Direction).Distinct();
            TypeCombo.SelectedIndex = 0;
            DirectionCombo.SelectedIndex = 0;
        }

        private void TypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var allModesList = (DataContext as WindowMainViewModel).AllModes;
            DirectionCombo.ItemsSource = allModesList.Where(el => el.Name == (string)NameCombo.SelectedItem && 
                                                        el.Speed == (string)SpeedCombo.SelectedItem && 
                                                        el.Type == (string)TypeCombo.SelectedItem).Select(el => el.Direction).Distinct();
            DirectionCombo.SelectedIndex = 0;
        }


        private void DirectionSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (DataContext as WindowMainViewModel).PathNum = CurrentPath();
            (DataContext as WindowMainViewModel).ResetStateNumber();
        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            _currentScale = _currentScale >= MAX_SCALE ? _currentScale : _currentScale + SCALE_STEP;
            CanvasScale.ScaleX = _currentScale;
            CanvasScale.ScaleY = _currentScale;
            SliderScale.Value = _currentScale;
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            _currentScale = _currentScale <= 1 ? _currentScale : _currentScale - SCALE_STEP;
            CanvasScale.ScaleX = _currentScale;
            CanvasScale.ScaleY = _currentScale;
            SliderScale.Value = _currentScale;
        }

        private void DrawingLButton_Down(object sender, MouseButtonEventArgs e)
        {
            CanvasDrawing.CaptureMouse();
        }

        private void DrawingLButton_Up(object sender, MouseButtonEventArgs e)
        {
            CanvasDrawing.ReleaseMouseCapture();
        }

        private void DrawingMouse_Move(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(CanvasDrawing);
            if (CanvasDrawing.IsMouseCaptured)
            {
                CanvasScale.CenterX -= (pos.X - _lastDragPoint.X) * 1.2;
                CanvasScale.CenterY -= (pos.Y - _lastDragPoint.Y) * 1.2;
            }
            _lastDragPoint = pos;
        }

        private void DrawingMouse_Wheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                _currentScale = _currentScale >= MAX_SCALE ? _currentScale : _currentScale + SCALE_STEP;
            else
                _currentScale = _currentScale <= 1 ? _currentScale : _currentScale - SCALE_STEP;
            var pos = e.GetPosition(CanvasDrawing);
            CanvasScale.CenterX = pos.X - Width/2;
            CanvasScale.CenterY = pos.Y - Height/2;
            CanvasScale.ScaleX = _currentScale;
            CanvasScale.ScaleY = _currentScale;
            SliderScale.Value = _currentScale;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CanvasScale.ScaleX = e.NewValue;
            CanvasScale.ScaleY = e.NewValue;
        }
    }
}
