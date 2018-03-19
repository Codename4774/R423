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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace animation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DoubleAnimation buttonAnimation = new DoubleAnimation();
            //buttonAnimation.From = helloButton.ActualWidth;
            buttonAnimation.To = 150;
            buttonAnimation.Duration = TimeSpan.FromSeconds(3);
            //helloButton.BeginAnimation(Button.WidthProperty, buttonAnimation);
            

        }

        private void D0031_Click(object sender, RoutedEventArgs e)
        {
            //easycraft!
            MessageBox.Show("Данный блок бла-бла-бла");
        }
    }
}
