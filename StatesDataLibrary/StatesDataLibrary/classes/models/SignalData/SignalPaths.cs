using StatesDataLibrary.Classes.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesDataLibrary.Classes.Models.SignalData
{
    public class SignalPaths
    {
        public readonly Dictionary<int, SignalPath> Paths;

        public SignalPaths()
        {
            Paths = new Dictionary<int, SignalPath>();
        }

        public SignalPaths(string fileName)
        {
            SignalPathSerializeState[] deserializedData = Serializer.DeserializeSignalPathsList(fileName);

            Paths = new Dictionary<int, SignalPath>();

            foreach (var deserializedItem in deserializedData)
            {
                Paths.Add(deserializedItem.Id, new SignalPath(deserializedItem.States.ToList()));
            }
        }

        public SignalPathSerializeState[] ToSerializableState()
        {
            SignalPathSerializeState[] result = new SignalPathSerializeState[Paths.Count];
            int i = 0;

            foreach (var item in Paths)
            {
                result[i] = new SignalPathSerializeState(item.Key, item.Value);
                i++;
            }

            return result;
        }

    }
}
