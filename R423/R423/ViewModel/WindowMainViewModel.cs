using R423.Model;
using R423.Service;
using R423.Service.Implementation;
using R423.Service.Interface;
using R423.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace R423.ViewModel
{
    public class WindowMainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly SelectedDrawableState _selectedDrawableState;
        private List<SelectedMode> _selectedModeList;
        private DrawContextProvider _drawContextProvider;
        public event PropertyChangedEventHandler PropertyChanged;

        public DrawContextProvider DrawContextProvider
        {
            get
            {
                return _drawContextProvider;
            }
        }

        private readonly IDrawManager _drawManager;

        public WindowMainViewModel(Canvas drawContext, Image image)
        {
            _drawManager = ServiceProvider.DrawManager;
            _drawContextProvider = new DrawContextProvider(drawContext, image);
            _drawManager.DrawContextProvider = _drawContextProvider;

            _selectedDrawableState = new SelectedDrawableState() { OrdinalStateNumber = -1, SignalPathIndex = 1 };

            _drawStateCommand = new DrawStateCommand(_drawManager, _selectedDrawableState);
            _drawSignalPathCommand = new DrawSignalPathCommand(_drawManager, _selectedDrawableState);
            _signalPathChangedCommand = new SignalPathChangedCommand(_selectedDrawableState, _drawManager);
            _pauseAnimationCommand = new PauseAnimationCommand(_drawManager);
            _resumeAnimationCommand = new ResumeAnimationCommand(_drawManager);
            _stopAnimationCommand = new StopAnimationCommand(_drawManager);

            _selectedModeList = new List<SelectedMode>() {
                { new SelectedMode(1, "Окон-2", "48", "Цифровой 48", "Прием") },
                { new SelectedMode(2, "Окон-2", "48", "Цифровой 48", "Передача") },
                { new SelectedMode(1, "Окон-2", "48", "Аналоговый 48", "Прием") },
                { new SelectedMode(2, "Окон-2", "48", "Аналоговый 48", "Передача") },
                { new SelectedMode(3, "Окон-2", "480", "Цифровой 480", "Прием") },
                { new SelectedMode(4, "Окон-2", "480", "Цифровой 480", "Передача") },
                { new SelectedMode(7, "Окон-2", "480", "Цифровой 9x48", "Прием") },
                { new SelectedMode(8, "Окон-2", "480", "Цифровой 9x48", "Передача") },
                { new SelectedMode(9, "Окон-2", "480", "Аналоговый 9x48", "Прием") },
                { new SelectedMode(10, "Окон-2", "480", "Аналоговый 9x48", "Передача") },
                { new SelectedMode(5, "Окон-2", "2x480", "Цифровой 480x2", "Прием") },
                { new SelectedMode(6, "Окон-2", "2x480", "Цифровой 480x2", "Передача") },
                { new SelectedMode(11, "Окон-2", "2x480", "Цифровой 18x48", "Прием") },
                { new SelectedMode(12, "Окон-2", "2x480", "Цифровой 18x48", "Передача") },
                { new SelectedMode(13, "Окон-2", "2x480", "Аналоговый 18x48", "Прием") },
                { new SelectedMode(14, "Окон-2", "2x480", "Аналоговый 18x48", "Передача") },
                { new SelectedMode(15, "Окон-2", "2048", "2048 внешний", "Прием") },
                { new SelectedMode(16, "Окон-2", "2048", "2048 внешний", "Передача") },
                { new SelectedMode(17, "Окон-2", "2048", "С помощью ИО-4", "Прием") },
                { new SelectedMode(18, "Окон-2", "2048", "С помощью ИО-4", "Передача") },
                { new SelectedMode(19, "Окон-1", "48", "Цифровой 48", "Прием") },
                { new SelectedMode(20, "Окон-1", "48", "Цифровой 48", "Передача") },
                { new SelectedMode(19, "Окон-1", "48", "Аналоговый 48", "Прием") },
                { new SelectedMode(20, "Окон-1", "48", "Аналоговый 48", "Передача") },
                { new SelectedMode(21, "Окон-1", "480", "Цифровой 480", "Прием") },
                { new SelectedMode(22, "Окон-1", "480", "Цифровой 480", "Передача") },
                { new SelectedMode(23, "Окон-1", "480", "Цифровой 9x48", "Прием") },
                { new SelectedMode(24, "Окон-1", "480", "Цифровой 9x48", "Передача") },
                { new SelectedMode(25, "Окон-1", "480", "Аналоговый 9x48", "Прием") },
                { new SelectedMode(26, "Окон-1", "480", "Аналоговый 9x48", "Передача") },
                { new SelectedMode(27, "Окон-1", "2x480", "Цифровой 480x2", "Прием") },
                { new SelectedMode(28, "Окон-1", "2x480", "Цифровой 480x2", "Передача") },
                { new SelectedMode(29, "Окон-1", "2x480", "Цифровой 18x48", "Прием") },
                { new SelectedMode(30, "Окон-1", "2x480", "Цифровой 18x48", "Передача") },
                { new SelectedMode(31, "Окон-1", "2x480", "Аналоговый 18x48", "Прием") },
                { new SelectedMode(32, "Окон-1", "2x480", "Аналоговый 18x48", "Передача") },
                { new SelectedMode(33, "Окон-1", "2048", "2048 внешний", "Прием") },
                { new SelectedMode(34, "Окон-1", "2048", "2048 внешний", "Передача") },
                { new SelectedMode(35, "Окон-1", "2048", "С помощью ИО-4", "Прием") },
                { new SelectedMode(36, "Окон-1", "2048", "С помощью ИО-4", "Передача") },
                { new SelectedMode(0, "Узл-2", "480", "Цифровой 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-2", "480", "Цифровой 48", "ЦТРС 2") },
                { new SelectedMode(0, "Узл-2", "480", "Аналоговый 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-2", "480", "Аналоговый 48", "ЦТРС 2") },
                { new SelectedMode(0, "Узл-2", "2x480", "Цифровой 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-2", "2x480", "Цифровой 48", "ЦТРС 2") },
                { new SelectedMode(0, "Узл-2", "2x480", "Аналоговый 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-2", "2x480", "Аналоговый 48", "ЦТРС 2") },
                { new SelectedMode(0, "Узл-2", "2048", "Цифровой 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-2", "2048", "Цифровой 48", "ЦТРС 2") },
                { new SelectedMode(0, "Узл-2", "2048", "Аналоговый 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-2", "2048", "Аналоговый 48", "ЦТРС 2") },
                { new SelectedMode(0, "Узл-1", "480", "Цифровой 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-1", "480", "Цифровой 48", "ЦТРС 2") },
                { new SelectedMode(0, "Узл-1", "480", "Аналоговый 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-1", "480", "Аналоговый 48", "ЦТРС 2") },
                { new SelectedMode(0, "Узл-1", "2x480", "Цифровой 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-1", "2x480", "Цифровой 48", "ЦТРС 2") },
                { new SelectedMode(0, "Узл-1", "2x480", "Аналоговый 48", "ЦТРС 1") },
                { new SelectedMode(0, "Узл-1", "2x480", "Аналоговый 48", "ЦТРС 2") },
                { new SelectedMode(39, "Ретр-2", "48", "Цифровой 48", "ЦТРС 1") },
                { new SelectedMode(40, "Ретр-2", "48", "Цифровой 48", "ЦТРС 2") },
                { new SelectedMode(41, "Ретр-2", "480", "Цифровой 480", "ЦТРС 1") },
                { new SelectedMode(42, "Ретр-2", "480", "Цифровой 480", "ЦТРС 2") },
                { new SelectedMode(0, "Ретр-2", "2x480", "Цифровой 480x2", "ЦТРС 1") },
                { new SelectedMode(0, "Ретр-2", "2x480", "Цифровой 480x2", "ЦТРС 2") },
                { new SelectedMode(41, "Ретр-2", "2048", "2048 внешний", "ЦТРС 1") },
                { new SelectedMode(42, "Ретр-2", "2048", "2048 внешний", "ЦТРС 2") },
                { new SelectedMode(37, "Ретр-1", "48", "Цифровой 48", "ЦТРС А->Б") },
                { new SelectedMode(38, "Ретр-1", "48", "Цифровой 48", "ЦТРС Б->А") },
                { new SelectedMode(37, "Ретр-1", "480", "Цифровой 480", "ЦТРС А->Б") },
                { new SelectedMode(38, "Ретр-1", "480", "Цифровой 480", "ЦТРС Б->А") },
                { new SelectedMode(37, "Ретр-1", "2x480", "Цифровой 480x2", "ЦТРС А->Б") },
                { new SelectedMode(38, "Ретр-1", "2x480", "Цифровой 480x2", "ЦТРС Б->А") },
                { new SelectedMode(37, "Ретр-1", "2048", "2048 внешний", "ЦТРС А->Б") },
                { new SelectedMode(38, "Ретр-1", "2048", "2048 внешний", "ЦТРС Б->А") }
            };
        }

        private ICommand _drawStateCommand;
        public ICommand DrawStateCommand
        {
            get
            {
                return _drawStateCommand;
            }
        }

        private ICommand _drawSignalPathCommand;
        public ICommand DrawSignalPathCommand
        {
            get
            {
                return _drawSignalPathCommand;
            }
        }

        private ICommand _signalPathChangedCommand;
        public ICommand SignalPathChangedCommand
        {
            get
            {
                return _signalPathChangedCommand;
            }
        }
        
        private int _pathNum;
        public int PathNum
        {
            get
            {
                return _pathNum;
            }
            set
            {
                _pathNum = value < 1 ? 1 : value;
                NotifyPropertyChanged("PathNum");
            }
        }

        private ICommand _pauseAnimationCommand;
        public ICommand PauseAnimationCommand
        {
            get
            {
                return _pauseAnimationCommand;
            }
        }

        private ICommand _resumeAnimationCommand;
        public ICommand ResumeAnimationCommand
        {
            get
            {
                return _resumeAnimationCommand;
            }
        }

        private ICommand _stopAnimationCommand;
        public ICommand StopAnimationCommand
        {
            get
            {
                return _stopAnimationCommand;
            }
        }

        public void SetSpeed(double value)
        {
            _drawManager.SetSpeed(value);
        }

        public List<SelectedMode> AllModes
        {
            get
            {
                return _selectedModeList;
            }
        }

        public void ResetStateNumber()
        {
            _selectedDrawableState.OrdinalStateNumber = -1;
        }

        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
