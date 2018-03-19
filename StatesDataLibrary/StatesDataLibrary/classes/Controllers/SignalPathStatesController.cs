using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatesDataLibrary.Classes.Models.SignalData;
using System.Windows.Shapes;
using StatesDataLibrary.Exceptions;
using System.Text.RegularExpressions;
using System.Drawing;

namespace StatesDataLibrary.Classes.Controllers
{
    public static class SignalPathStatesController
    {
        private static SignalPathStates _signalPathStates;
        private static readonly string _pathToFile = "SignalPathStates.xml";

        public static List<SignalLineDrawableState> GetDrawableState(int index)
        {
            SignalPathState drawableOnStateLine;
            try
            {
                drawableOnStateLine = _signalPathStates.States[index];
            }
            catch (KeyNotFoundException e)
            {
                throw new InvalidIndexException("Error, invalid index", e);
            }
            
            List<SignalLineDrawableState> result = new List<SignalLineDrawableState>();

            foreach (var item in drawableOnStateLine.drawableOnStateLine)
            {
                result.Add
                (
                    new SignalLineDrawableState
                    (
                        LineStatesController.GetLineByIndex(item.Index).PartOfLine,
                        item.Index,
                        item.Direction,
                        item.Color
                    )
                );
            }

            return result;
        }

        public static void AddSignalPathState(List<SignalPathLineState> lines, int id)
        {
            _signalPathStates.States.Add(id, new SignalPathState(lines));
        }

        private static string pattern = @"\(\s*([\d]+)\s*,\s*([01])\)";

        public static void AddSignalPathStateFromString(string lines, int id, Color color)
        {
            Regex regex = new Regex(pattern);

            
            Match match = regex.Match(lines);
            if (match.Success)
            {
                List<SignalPathLineState> parsedLines = new List<SignalPathLineState>();

                while (match.Success)
                {
                    parsedLines.Add(new SignalPathLineState(Convert.ToInt32(match.Groups[1].Value), match.Groups[2].Value == "0" ? SignalPathLineState.DirectionEnum.Forward : SignalPathLineState.DirectionEnum.Back, color));
                    match = match.NextMatch();
                }

                _signalPathStates.States.Add(id, new SignalPathState(parsedLines));
            }
            else
            {
                throw new Exception("Invalid string");
            }
        }

        public static SignalPathStates SignalPathStates
        {
            get
            {
                return _signalPathStates;
            }
            set
            {
                _signalPathStates = value;
            }
        }

        public static string PathToFile
        {
            get
            {
                return _pathToFile;
            }
        }
    }
}
