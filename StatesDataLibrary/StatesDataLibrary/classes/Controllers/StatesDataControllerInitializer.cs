using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesDataLibrary.Classes.Controllers
{
    public static class StatesDataControllerInitializer
    {
        public static void Initialize()
        {
            LineStatesController.Initialize();
            SignalPathStatesController.Initialize();
            SignalPathsController.Initialize();
        }
    }
}
