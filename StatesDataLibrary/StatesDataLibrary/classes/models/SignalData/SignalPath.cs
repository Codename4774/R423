using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesDataLibrary.Classes.Models.SignalData
{
    [Serializable]
    public class SignalPath
    {

        public List<int> States;


        public SignalPath(List<int> states)
        {
            States = states;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder("", 1000);

            for (int i = 0; i < States.Count - 1; i++)
            {
                result.Append(Convert.ToString(States[i]) + ",");
            }
            result.Append(Convert.ToString(States[States.Count - 1]));

            return result.ToString();
        }
    }
}
