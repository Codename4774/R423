using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatesDataLibrary.Exceptions
{
    public class InvalidIndexException : StatesDataLibraryException
    {
        public InvalidIndexException(string baseString, Exception innerException) : base(baseString, innerException)
        {
        }
    }
}
