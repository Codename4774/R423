using R423.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R423.Service.Implementation
{
    public delegate void DrawStateCompletedDelegate(int stateIndex, int signalPathIndex, int statesCount);
}
