using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StatesDataLibrary.Classes.Models.SignalData
{
    [Serializable]
    public class SignalPathLineState
    {
        public int Index { get; set; }

        public enum DirectionEnum { Forward, Back }

        public DirectionEnum Direction { get; set; }

        public int R { get; set; }
        public int G { get; set; }
        public int B { get; set; }

        [NonSerialized]
        private Color _color;

        [XmlIgnore]
        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                R = value.R;
                G = value.G;
                B = value.B;
                _color = value;
            }
        }

        public SignalPathLineState(int index, DirectionEnum direction, Color color)
        {
            this.Index = index;
            this.Direction = direction;
            this.Color = color;
        }
        public SignalPathLineState()
        {
        }

        public void InitializeColor()
        {
            _color = Color.FromArgb(R, G, B);
        }
    }
}
