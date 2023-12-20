/*using Intents;*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{
    public abstract class FlightManager
    {
        protected List<Flight> flights = new List<Flight>();
        static string path = @"..\..\..\..\..\Resources\Res\flights.csv";
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        protected List<Flight> getFlights() 
        {
            return flights;
        }

        protected void LoadFlights()
        {
            
            using (var streamReader = new StreamReader(filePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] cells = line.Split(',');
                    string flightnumber = cells[0];
                    string flightname = cells[1];
                    string flightFrom = cells[2];
                    string flightdestination = cells[3];
                    string flighttakeoffday = cells[4];
                    string flighttime = cells[5];
                    int flighttotalseat = Convert.ToInt32(cells[6]);
                    double cost = Convert.ToDouble(cells[7]);

                    CreateFlight(flightnumber, flightname, flightFrom, flightdestination, flighttakeoffday, flighttime, flighttotalseat, cost);
                }
            }
        }
        protected void CreateFlight(string flightnumber, string flightName, string flightFrom, string flightDestination, string flighttakeoffday, string flighttime, int flighttotalseat, double cost)
        {
            Flight flight = new Flight(flightnumber, flightName, flightFrom, flightDestination, flighttakeoffday, flighttime, flighttotalseat, cost);
            flights.Add(flight);
        }
        protected void BookingOccured(Flight selectedFlight)
        {

            bool isFound = false;
            foreach (Flight flight in flights)
            {
                if (selectedFlight == flight)
                {
                    flight.FlightTotalSeat -= 1;
                    isFound = true;
                    break;
                }
            }
            if (isFound) 
            {
                WriteFlightsTocsv();
            }
            
        }

        protected void CancellationOccured(Flight selectedFlight)
        {
            bool isFound = false;
            foreach (Flight flight in flights)
            {
                if (selectedFlight.FlightName == flight.FlightName && selectedFlight.FlightNumber == flight.FlightNumber && selectedFlight.FlightTime == flight.FlightTime)
                {
                    flight.FlightTotalSeat += 1;
                    isFound = true;
                    break;
                }
            }
            if (isFound)
            {
                WriteFlightsTocsv();
            }
        }
        private void WriteFlightsTocsv() 
        {
            List<string> lines = new List<string>();

            foreach (Flight flight in flights)
            {
                string line = $"{flight.FlightNumber},{flight.FlightName},{flight.FlightFrom},{flight.FlightDestination},{flight.FlightTakeOffDay},{flight.FlightTime},{flight.FlightTotalSeat},{flight.Cost}";
                lines.Add(line);
            }
            File.WriteAllLines(filePath, lines);
        }

    }
}
       
