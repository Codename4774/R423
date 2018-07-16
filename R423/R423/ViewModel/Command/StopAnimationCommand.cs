using R423.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace R423.ViewModel.Command
{
    public class StopAnimationCommand : ICommand
    {
        private readonly IDrawManager _drawManager;
        public StopAnimationCommand(IDrawManager drawManager)
        {
            _drawManager = drawManager;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _drawManager.StopCurrentAnimation();
            _drawManager.Clear();
        }
    }
}
