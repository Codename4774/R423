using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using StatesDataLibrary.Classes.Models.LinesInfo;
using StatesDataLibrary.Exceptions;

namespace StatesDataLibrary.Classes.Controllers
{
    public static class LineStatesController
    {
        private static LinesBase _lineBase;
        private static readonly string _pathToFile = "LinesCoordinates.xml"; 

        public static LineInfo GetLineByIndex(int index)
        {
            LineInfo result = null;
            try
            {
                result = LineBase.LineBase[index];
            }
            catch (KeyNotFoundException e)
            {
                throw new InvalidIndexException("Error, invalid index", e);
            }

            return result;
        }

        public static LinesBase LineBase
        {
            get
            {
                return _lineBase;
            }
            set
            {
                _lineBase = value;
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
