using R423.Model;
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


        public SignalPathChangedCommand(SelectedDrawableState selectedDrawableState)
        {
            _selectedDrawableState = selectedDrawableState;
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
            }
            catch (Exception e)
            {
            }
        }
    }
}
