using System;

namespace flightManager.Data
{
    // Custom exception class for handling reservation code not found scenarios
    public class ReservationCodeNotFoundException : Exception
    {
        // Default constructor
        public ReservationCodeNotFoundException() { }

        // Constructor with a custom error message
        public ReservationCodeNotFoundException(string message) : base(message) { }

        // Constructor with a custom error message and inner exception
        public ReservationCodeNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
