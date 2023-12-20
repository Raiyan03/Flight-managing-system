using System;

namespace flightManager.Data
{
    // Class representing an airport
    public class Airport
    {
        // Private fields for airport code and name
        private string airportCode;
        private string airportName;

        // Public property for accessing and modifying the airport code
        public string AirportCode
        {
            get { return airportCode; }
            set { airportCode = value; }
        }

        // Public property for accessing and modifying the airport name
        public string AirportName
        {
            get { return airportName; }
            set { airportName = value; }
        }

        // Constructor to initialize the Airport object with code and name
        public Airport(string airport_code, string airport_name)
        {
            // Set the airport code and name using the provided values
            AirportName = airport_name;
            AirportCode = airport_code;
        }
    }
}
