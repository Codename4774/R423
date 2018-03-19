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
            DataContext = new WindowMainViewModel();
        }
    }
}
