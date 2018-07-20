using R423.Model;
using R423.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace R423.ViewModel.Command
{
    public class DrawSignalPathCommand : ICommand
    {
        private readonly IDrawManager _drawManager;
        private readonly SelectedDrawableState _selectedDrawableState;

        public DrawSignalPathCommand(IDrawManager drawManager, SelectedDrawableState selectedDrawableState)
        {
            _drawManager = drawManager;
            _selectedDrawableState = selectedDrawableState;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_drawManager.CurrentDrawingProcess == CurrentDrawingProcess.Handle)
            {
                _drawManager.Clear();
            }
            _selectedDrawableState.OrdinalStateNumber = -1;
            _drawManager.DrawSignalPath(_selectedDrawableState.SignalPathIndex);
        }
    }
}
