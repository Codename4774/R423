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
    public class WindowMainViewModel : ViewModelBase
    {
        private readonly SelectedDrawableState _selectedDrawableState;
        private Dictionary<int, SelectedMode> _selectedModeDict;
        private DrawContextProvider _drawContextProvider;
        
        public DrawContextProvider DrawContextProvider
        {
            get
            {
                return _drawContextProvider;
            }
        }

        private readonly IDrawManager _drawManager;

        public WindowMainViewModel(Canvas drawContext)
        {
            _drawManager = ServiceProvider.DrawManager;
            _drawContextProvider = new DrawContextProvider(drawContext);
            _drawManager.DrawContextProvider = _drawContextProvider;

            _selectedDrawableState = new SelectedDrawableState() { OrdinalStateNumber = -1, SignalPathIndex = 1 };

            _drawStateCommand = new DrawStateCommand(_drawManager, _selectedDrawableState);
            _drawSignalPathCommand = new DrawSignalPathCommand(_drawManager, _selectedDrawableState);
            _signalPathChangedCommand = new SignalPathChangedCommand(_selectedDrawableState);

            _selectedModeDict = new Dictionary<int, SelectedMode>() {
                { 1, new SelectedMode("Окон-2", "48", "Цифровой 48", "Прием") },
                { 2, new SelectedMode("Окон-2", "48", "Цифровой 48", "Передача") },
                { 3, new SelectedMode("Окон-2", "48", "Аналоговый 48", "Прием") },
                { 4, new SelectedMode("Окон-2", "48", "Аналоговый 48", "Передача") },
                { 5, new SelectedMode("Окон-2", "480", "Цифровой 480", "Прием") },
                { 6, new SelectedMode("Окон-2", "480", "Цифровой 480", "Передача") },
                { 7, new SelectedMode("Окон-2", "480", "Цифровой 9x48", "Прием") },
                { 8, new SelectedMode("Окон-2", "480", "Цифровой 9x48", "Передача") },
                { 9, new SelectedMode("Окон-2", "480", "Аналоговый 9x48", "Прием") },
                { 10, new SelectedMode("Окон-2", "480", "Аналоговый 9x48", "Передача") },
                { 11, new SelectedMode("Окон-2", "2x480", "Цифровой 480x2", "Прием") },
                { 12, new SelectedMode("Окон-2", "2x480", "Цифровой 480x2", "Передача") },
                { 13, new SelectedMode("Окон-2", "2x480", "Цифровой 18x48", "Прием") },
                { 14, new SelectedMode("Окон-2", "2x480", "Цифровой 18x48", "Передача") },
                { 15, new SelectedMode("Окон-2", "2x480", "Аналоговый 18x48", "Прием") },
                { 16, new SelectedMode("Окон-2", "2x480", "Аналоговый 18x48", "Передача") },
                { 17, new SelectedMode("Окон-2", "2048", "2048 внешний", "Прием") },
                { 18, new SelectedMode("Окон-2", "2048", "2048 внешний", "Передача") },
                { 19, new SelectedMode("Окон-2", "2048", "С помощью ИО-4", "Прием") },
                { 20, new SelectedMode("Окон-2", "2048", "С помощью ИО-4", "Передача") },
                { 21, new SelectedMode("Окон-1", "48", "Цифровой 48", "Прием") },
                { 22, new SelectedMode("Окон-1", "48", "Цифровой 48", "Передача") },
                { 23, new SelectedMode("Окон-1", "48", "Аналоговый 48", "Прием") },
                { 24, new SelectedMode("Окон-1", "48", "Аналоговый 48", "Передача") },
                { 25, new SelectedMode("Окон-1", "480", "Цифровой 480", "Прием") },
                { 26, new SelectedMode("Окон-1", "480", "Цифровой 480", "Передача") },
                { 27, new SelectedMode("Окон-1", "480", "Цифровой 9x48", "Прием") },
                { 28, new SelectedMode("Окон-1", "480", "Цифровой 9x48", "Передача") },
                { 29, new SelectedMode("Окон-1", "480", "Аналоговый 9x48", "Прием") },
                { 30, new SelectedMode("Окон-1", "480", "Аналоговый 9x48", "Передача") },
                { 31, new SelectedMode("Окон-1", "2x480", "Цифровой 480x2", "Прием") },
                { 32, new SelectedMode("Окон-1", "2x480", "Цифровой 480x2", "Передача") },
                { 33, new SelectedMode("Окон-1", "2x480", "Цифровой 18x48", "Прием") },
                { 34, new SelectedMode("Окон-1", "2x480", "Цифровой 18x48", "Передача") },
                { 35, new SelectedMode("Окон-1", "2x480", "Аналоговый 18x48", "Прием") },
                { 36, new SelectedMode("Окон-1", "2x480", "Аналоговый 18x48", "Передача") },
                { 37, new SelectedMode("Окон-1", "2048", "2048 внешний", "Прием") },
                { 38, new SelectedMode("Окон-1", "2048", "2048 внешний", "Передача") },
                { 39, new SelectedMode("Окон-1", "2048", "С помощью ИО-4", "Прием") },
                { 40, new SelectedMode("Окон-1", "2048", "С помощью ИО-4", "Передача") },
                { 41, new SelectedMode("Узл-2", "480", "Цифровой 48", "ЦТРС 1") },
                { 42, new SelectedMode("Узл-2", "480", "Цифровой 48", "ЦТРС 2") },
                { 43, new SelectedMode("Узл-2", "480", "Аналоговый 48", "ЦТРС 1") },
                { 44, new SelectedMode("Узл-2", "480", "Аналоговый 48", "ЦТРС 2") },
                { 45, new SelectedMode("Узл-2", "2x480", "Цифровой 48", "ЦТРС 1") },
                { 46, new SelectedMode("Узл-2", "2x480", "Цифровой 48", "ЦТРС 2") },
                { 47, new SelectedMode("Узл-2", "2x480", "Аналоговый 48", "ЦТРС 1") },
                { 48, new SelectedMode("Узл-2", "2x480", "Аналоговый 48", "ЦТРС 2") },
                { 49, new SelectedMode("Узл-2", "2048", "Цифровой 48", "ЦТРС 1") },
                { 50, new SelectedMode("Узл-2", "2048", "Цифровой 48", "ЦТРС 2") },
                { 51, new SelectedMode("Узл-2", "2048", "Аналоговый 48", "ЦТРС 1") },
                { 52, new SelectedMode("Узл-2", "2048", "Аналоговый 48", "ЦТРС 2") },
                { 53, new SelectedMode("Узл-1", "480", "Цифровой 48", "ЦТРС 1") },
                { 54, new SelectedMode("Узл-1", "480", "Цифровой 48", "ЦТРС 2") },
                { 55, new SelectedMode("Узл-1", "480", "Аналоговый 48", "ЦТРС 1") },
                { 56, new SelectedMode("Узл-1", "480", "Аналоговый 48", "ЦТРС 2") },
                { 57, new SelectedMode("Узл-1", "2x480", "Цифровой 48", "ЦТРС 1") },
                { 58, new SelectedMode("Узл-1", "2x480", "Цифровой 48", "ЦТРС 2") },
                { 59, new SelectedMode("Узл-1", "2x480", "Аналоговый 48", "ЦТРС 1") },
                { 60, new SelectedMode("Узл-1", "2x480", "Аналоговый 48", "ЦТРС 2") },
                { 61, new SelectedMode("Ретр-2", "48", "Цифровой 48", "ЦТРС 1") },
                { 62, new SelectedMode("Ретр-2", "48", "Цифровой 48", "ЦТРС 2") },
                { 63, new SelectedMode("Ретр-2", "480", "Цифровой 480", "ЦТРС 1") },
                { 64, new SelectedMode("Ретр-2", "480", "Цифровой 480", "ЦТРС 2") },
                { 65, new SelectedMode("Ретр-2", "2x480", "Цифровой 480x2", "ЦТРС 1") },
                { 66, new SelectedMode("Ретр-2", "2x480", "Цифровой 480x2", "ЦТРС 2") },
                { 67, new SelectedMode("Ретр-2", "2048", "2048 внешний", "ЦТРС 1") },
                { 68, new SelectedMode("Ретр-2", "2048", "2048 внешний", "ЦТРС 2") },
                { 69, new SelectedMode("Ретр-1", "48", "Цифровой 48", "ЦТРС А->Б") },
                { 70, new SelectedMode("Ретр-1", "48", "Цифровой 48", "ЦТРС Б->А") },
                { 71, new SelectedMode("Ретр-1", "480", "Цифровой 480", "ЦТРС А->Б") },
                { 72, new SelectedMode("Ретр-1", "480", "Цифровой 480", "ЦТРС Б->А") },
                { 73, new SelectedMode("Ретр-1", "2x480", "Цифровой 480x2", "ЦТРС А->Б") },
                { 74, new SelectedMode("Ретр-1", "2x480", "Цифровой 480x2", "ЦТРС Б->А") },
                { 75, new SelectedMode("Ретр-1", "2048", "2048 внешний", "ЦТРС А->Б") },
                { 76, new SelectedMode("Ретр-1", "2048", "2048 внешний", "ЦТРС Б->А") }
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

        public List<SelectedMode> AllModes
        {
            get
            {
                return _selectedModeDict.Select(el => el.Value).ToList();
            }
        }
    }
}
