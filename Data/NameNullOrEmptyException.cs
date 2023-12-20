using System;

namespace flightManager.Data
{
    // Custom exception class for handling name being null or empty
    public class NameNullOrEmptyException : Exception
    {
        // Default constructor
        public NameNullOrEmptyException() { }

        // Constructor with a custom message
        public NameNullOrEmptyException(string message) : base(message) { }

        // Constructor with a custom message and an inner exception
        public NameNullOrEmptyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
