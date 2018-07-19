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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace R423.Page
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow(int id)
        {
            InitializeComponent();
            var doc = XElement.Load("info.xml");
            var elem = from el in doc.Elements("item")
                       where (int)(el.Attribute("id")) == id
                       select el;
            var desc = elem.First().Element("desc");
            Web.NavigateToString(desc.Value.ToString());
           
        }
    }
}
