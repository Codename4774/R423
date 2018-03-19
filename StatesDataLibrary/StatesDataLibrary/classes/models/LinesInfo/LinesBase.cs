using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using StatesDataLibrary.Classes.Services;

namespace StatesDataLibrary.Classes.Models.LinesInfo
{
    public class LinesBase
    {
        public readonly Dictionary<int, LineInfo> LineBase;

        public LinesBase()
        {
            LineBase = new Dictionary<int, LineInfo>();
        }

        public LinesBase(string fileName)
        {
            LineSerializeState[] deserializedData = Serializer.DeserializeLinesBase(fileName);
            LineBase = new Dictionary<int, LineInfo>();
            foreach (var deserializedItem in deserializedData)
            {
                LineBase.Add(deserializedItem.Id, new LineInfo(LineInfo.CreatePolylineFromPointsList(deserializedItem.Points.ToList())));
            }
        }

        public List<KeyValuePair<int, LineInfo>> ToList()
        {
            return LineBase.ToList();
        }

        public LineSerializeState[] ToSerializableState()
        {
            LineSerializeState[] result = new LineSerializeState[LineBase.Count];
            int i = 0;
            foreach (var item in LineBase)
            {
                result[i] = new LineSerializeState(item.Key, LineInfo.GetPointsFromPolyline(item.Value.PartOfLine).ToArray() );
                i++;
            }
            return result;
        }
    }
}
