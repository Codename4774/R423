using R423.Service.Implementation;
using StatesDataLibrary.Classes.Controllers;
using StatesDataLibrary.Classes.Models.LinesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace R423.ViewModel.Command
{
    public class CanvasLoadedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var canvasDrawing = (Canvas)parameter;

            canvasDrawing.Children.Add(new Polyline() { Points = new PointCollection(new[] { new Point(0, 0), new Point(10, 10) }) });

            ResourceManager resourceManager = new Service.Implementation.ResourceManager("R423.Resources", typeof(Resources).Assembly);
            CoordsConverter converter = new CoordsConverter(resourceManager);
            converter.SetNewCompression(resourceManager.GetInt("xDisplayed"), resourceManager.GetInt("yDisplayed"));

            LineStatesController.LineBase = new LinesBase(LineStatesController.PathToFile);
            foreach (var item in LineStatesController.LineBase.LineBase)
            {
                item.Value.PartOfLine.Stroke = new SolidColorBrush(Colors.Aqua);
                Polyline polyline = item.Value.PartOfLine;

                converter.Convert(ref polyline);
                canvasDrawing.Children.Add(polyline);
            }
        }
    }
}
