using System;
using System.Collections.Generic;
using System.IO;

namespace flightManager.Data
{
    // Abstract class for managing flight-related operations
    public abstract class FlightManager
    {
        // List to store Flight objects
        protected List<Flight> flights = new List<Flight>();

        // Path to the CSV file storing flight information
        static string path = @"..\..\..\..\..\Resources\Res\flights.csv";
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

        // Gets the list of flights
        protected List<Flight> getFlights()
        {
            return flights;
        }

        // Loads flight data from CSV into the flights list
        protected void LoadFlights()
        {
            using (var streamReader = new StreamReader(filePath))
            {
                // Read data from CSV file
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Split the CSV line into cells
                    string[] cells = line.Split(',');

                    // Extract flight information from cells and create a Flight object
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

        // Creates a Flight object and adds it to the flights list
        protected void CreateFlight(string flightnumber, string flightName, string flightFrom, string flightDestination, string flighttakeoffday, string flighttime, int flighttotalseat, double cost)
        {
            Flight flight = new Flight(flightnumber, flightName, flightFrom, flightDestination, flighttakeoffday, flighttime, flighttotalseat, cost);
            flights.Add(flight);
        }

        // Handles a booking occurrence by updating the total seat count of the selected flight
        protected void BookingOccured(Flight selectedFlight)
        {
            bool isFound = false;

            // Update total seat count for the selected flight
            foreach (Flight flight in flights)
            {
                if (selectedFlight == flight)
                {
                    flight.FlightTotalSeat -= 1;
                    isFound = true;
                    break;
                }
            }

            // Write the updated flights data to the CSV file if found
            if (isFound)
            {
                WriteFlightsTocsv();
            }
        }

        // Handles a cancellation occurrence by updating the total seat count of the selected flight
        protected void CancellationOccured(Flight selectedFlight)
        {
            bool isFound = false;

            // Update total seat count for the selected flight during cancellation
            foreach (Flight flight in flights)
            {
                if (selectedFlight.FlightName == flight.FlightName && selectedFlight.FlightNumber == flight.FlightNumber && selectedFlight.FlightTime == flight.FlightTime)
                {
                    flight.FlightTotalSeat += 1;
                    isFound = true;
                    break;
                }
            }

            // Write the updated flights data to the CSV file if found
            if (isFound)
            {
                WriteFlightsTocsv();
            }
        }

        // Writes the flights data to the CSV file
        private void WriteFlightsTocsv()
        {
            List<string> lines = new List<string>();

            // Create CSV lines from Flight objects
            foreach (Flight flight in flights)
            {
                string line = $"{flight.FlightNumber},{flight.FlightName},{flight.FlightFrom},{flight.FlightDestination},{flight.FlightTakeOffDay},{flight.FlightTime},{flight.FlightTotalSeat},{flight.Cost}";
                lines.Add(line);
            }

            // Write the CSV lines to the file
            File.WriteAllLines(filePath, lines);
        }
    }
}
