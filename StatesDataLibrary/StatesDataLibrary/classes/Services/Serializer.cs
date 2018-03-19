using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatesDataLibrary.Classes.Models.LinesInfo;
using System.Xml.Serialization;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using StatesDataLibrary.Classes.Models;
using StatesDataLibrary.Classes.Models.SignalData;

namespace StatesDataLibrary.Classes.Services
{
    public static class Serializer
    {
        public static object DeserializeFile(string fileName, Type type)
        {
            object result;
            XmlSerializer formatter = new XmlSerializer(type);

            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                result = formatter.Deserialize(fs);
            }
            return result;
        }
        /*
        public static void TestSerializeLinesBase(string fileName)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<LineInfo>));
            List<LineInfo> test = new List<LineInfo>();
            Line test1 = new Line() { X1 = 0, Y1 = 1, X2 = 1, Y2 = 1 };
            //test1.x = new System.Windows.Media.PointCollection((new Point[2] { new Point(0, 1), new Point(1, 1) }).ToList());
            test.Add(new LineInfo(test1));
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, test);
            }
        }
        */
        public static void SerializeObject(string fileName, object serializableObj, Type type)
        {
            XmlSerializer formatter = new XmlSerializer(type);

            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, serializableObj);
            }

        }

        public static void SerializeLinesBase(string fileName, LinesBase lineInfoList)
        {
            SerializeObject(fileName, lineInfoList.ToSerializableState(), typeof(LineSerializeState[]));
        }

        public static void SerializeSignalPathStatesList(string fileName, SignalPathStates signalPathStatesList)
        {
            SerializeObject(fileName, signalPathStatesList.ToSerializableState(), typeof(SignalPathStateSerializeState[]));
        }

        public static void SerializeSignalPathsList(string fileName, SignalPaths signalPathsList)
        {
            SerializeObject(fileName, signalPathsList.ToSerializableState(), typeof(SignalPathSerializeState[]));
        }

        public static LineSerializeState[] DeserializeLinesBase(string fileName)
        {
            return (LineSerializeState[]) DeserializeFile(fileName, typeof(LineSerializeState[]));
        }

        public static SignalPathStateSerializeState[] DeserializeSignalPathStatesList(string fileName)
        {
            return (SignalPathStateSerializeState[]) DeserializeFile(fileName, typeof(SignalPathStateSerializeState[]));
        }

        public static SignalPathSerializeState[] DeserializeSignalPathsList(string fileName)
        {
            return (SignalPathSerializeState[])DeserializeFile(fileName, typeof(SignalPathSerializeState[]));
        }
    }
}
