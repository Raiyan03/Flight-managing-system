using System;

namespace flightManager.Data
{
    // Custom exception class for handling cases where citizenship is null or empty
    public class CitizenshipNullOrEmptyException : Exception
    {
        // Default constructor
        public CitizenshipNullOrEmptyException() { }

        // Constructor with a custom error message
        public CitizenshipNullOrEmptyException(string message) : base(message) { }

        // Constructor with a custom error message and inner exception
        public CitizenshipNullOrEmptyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
