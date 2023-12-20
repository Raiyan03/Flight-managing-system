using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{
    public class ReservationCodeNotFoundException : Exception
    {
        public ReservationCodeNotFoundException() { }

        public ReservationCodeNotFoundException(string message) : base(message) { }

        public ReservationCodeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
