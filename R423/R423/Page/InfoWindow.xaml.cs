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
    public partial class InfoWindow : System.Windows.Controls.Page
    {
        private List<String> _imgPath, _schemePath;
        public InfoWindow(int id)
        {
            InitializeComponent();
            _imgPath = new List<string>();
            _schemePath = new List<string>();
            var doc = XElement.Load("info.xml");
            var elem = from el in doc.Elements("item")
                       where (int)(el.Attribute("id")) == id
                       select el;
            this.Title = elem.First().Attribute("name").Value;
            var desc = elem.First().Element("desc");
            var imageSets = elem.First().Elements("imageset");
            foreach (var set in imageSets)
            {
                if (set.Attribute("type").Value == "photo")
                {
                    var photos = set.Elements("image");
                    foreach (XElement el in photos)
                    {
                        _imgPath.Add(el.Attribute("src").Value);
                    }
                }
                else if (set.Attribute("type").Value == "scheme")
                {
                    var schemes = set.Elements("image");
                    foreach (XElement el in schemes)
                    {
                        _schemePath.Add(el.Attribute("src").Value);
                    }
                }
            }
            Web.NavigateToString(desc.Value.ToString());
            PhotoButton.IsEnabled = _imgPath.Count != 0;
            SchemeButton.IsEnabled = _schemePath.Count != 0;
        }

        private void Photo_Click(object sender, RoutedEventArgs e)
        {
            if (_imgPath.Count == 0)
                return;
            this.NavigationService.Navigate(new ImageWindow(_imgPath));
        }

        private void Scheme_Click(object sender, RoutedEventArgs e)
        {
            if (_schemePath.Count == 0)
                return;
            this.NavigationService.Navigate(new ImageWindow(_schemePath));
        }
    }
}
