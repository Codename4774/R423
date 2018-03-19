using R423.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace R423.ViewModel
{
    public class WindowMainViewModel : ViewModelBase
    {
        public WindowMainViewModel()
        {
            _canvasLoadedCommand = new CanvasLoadedCommand();
        }

        private ICommand _canvasLoadedCommand;
        public ICommand CanvasLoadedCommand
        {
            get
            {
                return _canvasLoadedCommand;
            }
        }
    }
}
