using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace R423.Service.Implementation
{
    public class DrawContextProvider
    {
        private readonly Canvas _drawContext;

        private readonly Image _imageSkeme;

        public DrawContextProvider(Canvas canvas, Image imageSkeme)
        {
            _drawContext = canvas;
            _imageSkeme = imageSkeme;
        }


        public Canvas DrawContext
        {
            get
            {
                return _drawContext;
            }
        }
        public void Clear()
        {
            DrawContext.Children.Clear();
            DrawContext.Children.Add(_imageSkeme);
        }
    }
}
