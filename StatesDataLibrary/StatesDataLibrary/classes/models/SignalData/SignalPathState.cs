using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesDataLibrary.Classes.Models.SignalData
{
    [Serializable]
    public class SignalPathState
    {

        public readonly List<SignalPathLineState> drawableOnStateLine;

        public SignalPathState(List<SignalPathLineState> lines)
        {
            drawableOnStateLine = lines;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("", 1000);

            foreach (var item in drawableOnStateLine)
            {
                result.Append("id: " + Convert.ToString(item.Index));
                result.Append(" dir: " + Convert.ToString(item.Direction));
                result.Append(" col: " + Convert.ToString(item.Color));
                result.Append(", ");
            }

            return result.ToString();
        }

        public string ToStringForEditing()
        {
            StringBuilder result = new StringBuilder("", 1000);

            for (int i = 0; i < drawableOnStateLine.Count - 1; i++)
            {
                result.Append("(" + Convert.ToString(drawableOnStateLine[i].Index) + ",");
                result.Append(Convert.ToString((int)drawableOnStateLine[i].Direction) + "),");
            }
            result.Append("(" + Convert.ToString(drawableOnStateLine[drawableOnStateLine.Count - 1].Index) + ",");
            result.Append(Convert.ToString((int)drawableOnStateLine[drawableOnStateLine.Count - 1].Direction) + ")");

            return result.ToString();
        }
    }
}
