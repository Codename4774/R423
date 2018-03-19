using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatesDataLibrary.Classes.Models.SignalData;
using static StatesDataLibrary.Classes.Models.SignalData.SignalPathState;

namespace StatesDataLibrary.Classes.Models
{
    [Serializable]
    public class SignalPathStateSerializeState
    {
        public int Id { get; set; }
        public SignalPathLineState[] DrawableOnStateLines { get; set; }

        public SignalPathStateSerializeState()
        {
        }

        public SignalPathStateSerializeState(int id, SignalPathState signalPathState)
        {
            this.Id = id;

            DrawableOnStateLines = signalPathState.drawableOnStateLine.ToArray();
        }

        public void InitializeColors()
        {
            foreach (var lineState in DrawableOnStateLines)
            {
                lineState.InitializeColor();
            }
        }
    }
}
