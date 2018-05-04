using R423.Model;
using R423.Service.Implementation;
using R423.Service.Interface;
using StatesDataLibrary.Classes.Controllers;
using StatesDataLibrary.Classes.Models.LinesInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace R423.ViewModel.Command
{
    public class DrawStateCommand : ICommand
    {
        private readonly IDrawManager _drawManager;
        private readonly SelectedDrawableState _selectedDrawableState;

        public DrawStateCommand(IDrawManager drawManager, SelectedDrawableState selectedDrawableState)
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
            switch ((string)parameter)
            {
                case "Next":
                    {
                        _selectedDrawableState.OrdinalStateNumber += 1;
                        _drawManager.DrawState(_selectedDrawableState.OrdinalStateNumber, _selectedDrawableState.SignalPathIndex, Direction.Forward);
                    }
                    break;
                case "Previous":
                    {
                        
                        _drawManager.DrawState(_selectedDrawableState.OrdinalStateNumber, _selectedDrawableState.SignalPathIndex, Direction.Back);
                        _selectedDrawableState.OrdinalStateNumber -= 1;
                    }
                    break;
            }

            
        }
    }
}
