using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using static StatesDataLibrary.Classes.Models.SignalData.SignalPathLineState;

namespace StatesDataLibrary.Classes.Models.SignalData
{
    public class SignalLineDrawableState
    {
        public readonly Polyline Polyline;
        public readonly int Index;
        public readonly DirectionEnum Direction;
        public readonly Color Color;
        public readonly TypeEnum Type;

        public SignalLineDrawableState(Polyline polyline, int index, DirectionEnum direction, Color color, TypeEnum type)
        {
            this.Polyline = polyline;
            this.Index = index;
            this.Direction = direction;
            this.Color = color;
            this.Type = type;
        }
    }
}
