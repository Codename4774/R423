using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatesDataLibrary.Classes.Services;

namespace StatesDataLibrary.Classes.Models.SignalData
{
    public class SignalPathStates
    {
        public readonly Dictionary<int, SignalPathState> States;

        public SignalPathStates(string fileName)
        {
            SignalPathStateSerializeState[] deserializedData = Serializer.DeserializeSignalPathStatesList(fileName);

            States = new Dictionary<int, SignalPathState>();

            foreach (var deserializedItem in deserializedData)
            {
                deserializedItem.InitializeColors();
                States.Add(deserializedItem.Id, new SignalPathState (deserializedItem.DrawableOnStateLines.ToList()));
            }            
        }

        public SignalPathStateSerializeState[] ToSerializableState()
        {
            SignalPathStateSerializeState[] result = new SignalPathStateSerializeState[States.Count];
            int i = 0;

            foreach (var item in States)
            {
                result[i] = new SignalPathStateSerializeState(item.Key, item.Value);
                i++;
            }

            return result;
        }

        public List<KeyValuePair<int, SignalPathState>> ToList()
        {
            return States.ToList();
        }

        public SignalPathStates()
        {
            States = new Dictionary<int, SignalPathState>();
        }
    }
}
