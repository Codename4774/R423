using R423.Service;
using StatesDataLibrary.Classes.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace R423
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            StatesDataControllerInitializer.Initialize();
            ServiceProvider.Initialize();
        }
    }
}
