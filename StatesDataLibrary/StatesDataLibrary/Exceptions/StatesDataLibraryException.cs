using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesDataLibrary.Exceptions
{
    public class StatesDataLibraryException : Exception
    {
        public StatesDataLibraryException(string baseString, Exception innerException) : base(baseString, innerException)
        {
        }
    }
}
