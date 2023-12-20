using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{
    // Class for finding flights, inheriting from FlightManager
    public class FindFlights : FlightManager
    {
        // Private fields for flight search criteria and result
        private string flightDay;
        private string flightFrom;
        private string flightTo;
        private List<Flight> searchedFlights = new List<Flight>();

        // Public properties with getters and setters for flight search criteria
        public string FlightDay
        {
            get { return flightDay; }
            set { flightDay = value; }
        }

        public string FlightFrom
        {
            get { return flightFrom; }
            set { flightFrom = value; }
        }

        public string FlightTo
        {
            get { return flightTo; }
            set { flightTo = value; }
        }

        // Constructor to initialize flight search criteria and load flights
        public FindFlights(string flightfrom, string flighto, string flightday)
        {
            LoadFlights();
            FlightDay = flightday;
            FlightFrom = flightfrom;
            FlightTo = flighto;
        }

        // Default constructor, loads flights without specific search criteria
        public FindFlights()
        {
            LoadFlights();
        }

        // Method to update booking for a given flight
        public void UpdateBooking(Flight flight)
        {
            BookingOccured(flight);
        }

        // Method to handle flight cancellation
        public void Cancellation(Flight flight)
        {
            CancellationOccured(flight);
        }

        // Method to search and return a list of flights based on criteria
        public List<Flight> SearchedFlights()
        {
            searchedFlights.Clear();

            // Iterate through flights and add matching ones to the result list
            foreach (Flight flight in flights)
            {
                if (FlightFrom == flight.FlightFrom
                    && FlightTo == flight.FlightDestination
                    && FlightDay == flight.FlightTakeOffDay)
                {
                    searchedFlights.Add(flight);
                }
            }

            return searchedFlights;
        }
    }
}
