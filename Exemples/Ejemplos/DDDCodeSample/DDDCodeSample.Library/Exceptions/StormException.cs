using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDCodeSample.Library.Exceptions
{
    public class StormException : Exception
    {
        public StormException() { }

        public StormException(string message) : base(message) { }

        public StormException(string message, Exception exception) : base(message, exception) { }
    }
}
