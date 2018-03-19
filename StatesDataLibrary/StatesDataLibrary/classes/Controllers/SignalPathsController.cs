using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatesDataLibrary.Classes.Models.SignalData;
using System.Windows.Shapes;
using StatesDataLibrary.Exceptions;
using System.Text.RegularExpressions;

namespace StatesDataLibrary.Classes.Controllers
{
    public static class SignalPathsController
    {
        private static  SignalPaths _signalPaths;

        private static readonly string _pathToFile = "SignalPaths.xml";


        static SignalPathsController()
        {
            SignalPaths = new SignalPaths(PathToFile);
        }


        public static SignalPath GetSignalPath(int index)
        {
            try
            {
                return SignalPaths.Paths[index];
            }
            catch (KeyNotFoundException e)
            {
                throw new InvalidIndexException("Error, invalid index", e);
            }
        }

        public static void AddSignalPath(SignalPath path, int id)
        {
            _signalPaths.Paths.Add(id, path);
        }

        private static string pattern = @"\s*([\d]+)\s*";

        public static void AddSignalPathFromString(string path, int id)
        {
            Regex regex = new Regex(pattern);


            Match match = regex.Match(path);
            if (match.Success)
            {
                List<int> parsedLines = new List<int>();

                while (match.Success)
                {
                    parsedLines.Add(Convert.ToInt32(match.Groups[1].Value));
                    match = match.NextMatch();
                }

                _signalPaths.Paths.Add(id, new SignalPath(parsedLines));
            }
            else
            {
                throw new Exception("Invalid string");
            }
        }


        public static SignalPaths SignalPaths
        {
            get
            {
                return _signalPaths;
            }
            set
            {
                _signalPaths = value;
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


