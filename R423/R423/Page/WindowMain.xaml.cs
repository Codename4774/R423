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
        public WindowMain()
        {
            InitializeComponent();
            DataContext = new WindowMainViewModel(CanvasDrawing);
            var allModes = (DataContext as WindowMainViewModel).AllModes;
            NameCombo.ItemsSource = allModes.Select(el => el.Name).Distinct();
        }

        private void NameSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var allModes = (DataContext as WindowMainViewModel).AllModes;
            SpeedCombo.ItemsSource = allModes.Where(el => el.Name == (string)NameCombo.SelectedItem).Select(el => el.Speed).Distinct();
            TypeCombo.ItemsSource = allModes.Where(el => el.Name == (string)NameCombo.SelectedItem && 
                                                   el.Speed == (string)SpeedCombo.SelectedItem).Select(el => el.Type).Distinct();
            DirectionCombo.ItemsSource = allModes.Where(el => el.Name == (string)NameCombo.SelectedItem && 
                                                        el.Speed == (string)SpeedCombo.SelectedItem &&
                                                        el.Type == (string)TypeCombo.SelectedItem).Select(el => el.Direction).Distinct();
            SpeedCombo.SelectedIndex = 0;
            TypeCombo.SelectedIndex = 0;
            DirectionCombo.SelectedIndex = 0;
        }

        private void SpeedSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var allModes = (DataContext as WindowMainViewModel).AllModes;
            TypeCombo.ItemsSource = allModes.Where(el => el.Name == (string)NameCombo.SelectedItem && 
                                                   el.Speed == (string)SpeedCombo.SelectedItem).Select(el => el.Type).Distinct();
            DirectionCombo.ItemsSource = allModes.Where(el => el.Name == (string)NameCombo.SelectedItem &&
                                                        el.Speed == (string)SpeedCombo.SelectedItem && 
                                                        el.Type == (string)TypeCombo.SelectedItem).Select(el => el.Direction).Distinct();
            TypeCombo.SelectedIndex = 0;
            DirectionCombo.SelectedIndex = 0;
        }

        private void TypeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var allModes = (DataContext as WindowMainViewModel).AllModes;
            DirectionCombo.ItemsSource = allModes.Where(el => el.Name == (string)NameCombo.SelectedItem && 
                                                        el.Speed == (string)SpeedCombo.SelectedItem && 
                                                        el.Type == (string)TypeCombo.SelectedItem).Select(el => el.Direction).Distinct();
            DirectionCombo.SelectedIndex = 0;
        }
    }
}
