using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{
    public class CitizenshipNullOrEmptyException : Exception 
    {
        public CitizenshipNullOrEmptyException() { }

        public CitizenshipNullOrEmptyException(string message) : base(message) { }

        public CitizenshipNullOrEmptyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
