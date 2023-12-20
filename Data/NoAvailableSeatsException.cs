using System;

namespace flightManager.Data
{
    // Custom exception class for handling scenarios where no available seats are present
    public class NoAvailableSeatsException : Exception
    {
        // Default constructor
        public NoAvailableSeatsException() { }

        // Constructor with a custom message
        public NoAvailableSeatsException(string message) : base(message) { }

        // Constructor with a custom message and an inner exception
        public NoAvailableSeatsException(string message, Exception innerException) : base(message, innerException) { }
    }
}
