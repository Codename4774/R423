Инструкция по сборке проекта: /R423-develop/Build release guide.txt
Инструкция по созданию файлов с информацией о состояниях: /R423-develop/R423.GUILinesInfoBuilder/readme.txt

Данный проект можно использовать в последующем и для других структурных схем, для этого:
	1. В проекте R423.GUILinesInfoBuilder заменить текущую структурную схему на нужную
	2. Далее создать нужные пути прохождения при помощи R423.GUILinesInfoBuilder (см /R423-develop/R423.GUILinesInfoBuilder/readme.txt)
	3. Далее в проекте R423 в файле Resources.resx установить значения xPictureSize и yPictureSize размеры картинки со структурной схемой
	4. В проекте R423 заменить текущую структурную схему на нужную (/Page/WindowMain.xaml)
	5. В проекте R423 в файле /ViewModel/WindowMainViewModel.cs в конструкторе public WindowMainViewModel(Canvas drawContext, Image image) в инициализации переменной _selectedModeList поменять названия режимов и id режимов согласно данным из файла SignalPaths.xml
	//расписать про значения по умолчанию в  dropdownах
	6. //расписать про info.xml
	7. Поменять название проекта, заглавный экран и т.д.

P.S. Проект R423 написан на WPF, использован паттерн MVVM