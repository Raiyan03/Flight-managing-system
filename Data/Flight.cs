// Namespace for flight-related data
namespace flightManager.Data
{
    // Class representing a Flight
    public class Flight
    {
        // Private fields for flight details
        private string flightNumber;
        private string flightName;
        private string flightFrom;
        private string flightDestination;
        private string flighthTakeOffDay;
        private string flightTime;
        private int flightTotalSeat;
        private double cost;

        // Public properties to access private fields with getters and setters
        public string FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; }
        }

        public string FlightName
        {
            get { return flightName; }
            set { flightName = value; }
        }

        public string FlightFrom
        {
            get { return flightFrom; }
            set { flightFrom = value; }
        }

        public string FlightDestination
        {
            get { return flightDestination; }
            set { flightDestination = value; }
        }

        public string FlightTakeOffDay
        {
            get { return flighthTakeOffDay; }
            set { flighthTakeOffDay = value; }
        }

        public string FlightTime
        {
            get { return flightTime; }
            set { flightTime = value; }
        }

        public int FlightTotalSeat
        {
            get { return flightTotalSeat; }
            set { flightTotalSeat = value; }
        }

        public double Cost
        {
            get { return cost; }
            set { cost = value; }
        }

        // Default constructor
        public Flight()
        {
        }

        // Parameterized constructor to initialize Flight properties
        public Flight(string flightnumber, string flightName, string flightFrom, string flightDestination, string flighttaketakeoffday, string flighttime, int flighttotalseat, double cost)
        {
            FlightNumber = flightnumber;
            FlightName = flightName;
            FlightFrom = flightFrom;
            FlightDestination = flightDestination;
            FlightTakeOffDay = flighttaketakeoffday;
            FlightTime = flighttime;
            FlightTotalSeat = flighttotalseat;
            Cost = cost;
        }
    }
}
