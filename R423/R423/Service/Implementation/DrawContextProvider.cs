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


        public DrawContextProvider(Canvas canvas)
        {
            _drawContext = canvas;
        }


        public Canvas DrawContext
        {
            get
            {
                return _drawContext;
            }
        }
    }
}
