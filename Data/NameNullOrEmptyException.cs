using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{
    public class NameNullOrEmptyException : Exception
    {
        public NameNullOrEmptyException() { }

        public NameNullOrEmptyException(string message) : base(message) { }

        public NameNullOrEmptyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
