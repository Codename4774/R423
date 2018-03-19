using StatesDataLibrary.Classes.Models.SignalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StatesDataLibrary.Classes.Models.SignalData.SignalPath;

namespace StatesDataLibrary.Classes.Models
{
    [Serializable]
    public class SignalPathSerializeState
    {
        public int Id { get; set; }
        public int[] States;


        public SignalPathSerializeState()
        {
        }

        public SignalPathSerializeState(int id, SignalPath signalPath)
        {
            this.Id = id;

            States = signalPath.States.ToArray();
        }
    }
}
