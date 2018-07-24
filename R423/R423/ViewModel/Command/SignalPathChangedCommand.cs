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
    public class SignalPathChangedCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly SelectedDrawableState _selectedDrawableState;
        private readonly IDrawManager _drawManager;

        public SignalPathChangedCommand(SelectedDrawableState selectedDrawableState, IDrawManager drawManager)
        {
            _selectedDrawableState = selectedDrawableState;
            _drawManager = drawManager;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                int newIndex = Convert.ToInt32(parameter);

                _selectedDrawableState.SignalPathIndex = newIndex;
                _selectedDrawableState.OrdinalStateNumber = -1;
                _drawManager.StopCurrentAnimation();
                _drawManager.Clear();
            }
            catch (Exception e)
            {
            }
        }
    }
}
