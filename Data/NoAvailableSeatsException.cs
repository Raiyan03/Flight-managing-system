using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{
    public class NoAvailableSeatsException : Exception
    {
        public NoAvailableSeatsException() { }

        public NoAvailableSeatsException(string message) : base(message) { }

        public NoAvailableSeatsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
