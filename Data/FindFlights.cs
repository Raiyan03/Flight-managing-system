using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{

    public class FindFlights : FlightManager
    {
        private string flightDay;
        private string flightFrom;
        private string flightTo;
        private List<Flight> searchedFlights = new List<Flight>();
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
        public FindFlights(string flightfrom, string flighto, string flightday)
        {
            LoadFlights();
            FlightDay = flightday;
            FlightFrom = flightfrom;
            FlightTo = flighto;
        }
        public FindFlights()
        {
            LoadFlights();
        }
        public void updateBooking(Flight flight)
        {
            BookingOccured(flight);
        }
        public void Cancellation(Flight flight)
        {
            CancellationOccured(flight);
        }

        public List<Flight> SearchedFlights()
        {
            searchedFlights.Clear();

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