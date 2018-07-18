using R423.Service.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace R423.Service.Interface
{
    public interface IDrawManager
    {
        void DrawState(int stateIndex, int signalPathIndex, DrawStateCompletedDelegate onDrawComplete = null, int statesCount = -1);
        void DrawStateRevertDirection(int stateIndex, int signalPathIndex);
        void DrawSignalPath(int signalPathIndex);
        Ellipse GetEllipse(Point coordiante, Brush brush);
        void PauseCurrentAnimation();
        void ResumeCurrentAnimation();
        void StopCurrentAnimation();
        void SetSpeed(double speedValue);
        void Clear();
        DrawContextProvider DrawContextProvider { set; }
    }
}
