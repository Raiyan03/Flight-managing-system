using System;
using System.Collections.Generic;
using System.IO;

namespace flightManager.Data
{
    // Class responsible for managing airports
    public class AirportManager
    {
        // List to store airport information
        private List<Airport> airportList = new List<Airport>();

        // Method to load airport data from a CSV file
        private void LoadAirport()
        {
            // Relative path to the airports.csv file
            string path = @"..\..\..\..\..\Resources\Res\airports.csv";

            // Combine the base directory with the relative path to get the full file path
            string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            // Read data from the CSV file
            using (var streamReader = new StreamReader(FilePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    // Split each line into cells using ',' as the delimiter
                    string[] cells = line.Split(',');

                    // Extract airport code and name from cells
                    string AirportCode = cells[0];
                    string AirportName = cells[1];

                    // Create an Airport object and add it to the list
                    CreateAirport(AirportCode, AirportName);
                }
            }
        }

        // Method to create an Airport object and add it to the list
        private void CreateAirport(string code, string name)
        {
            Airport airport = new Airport(code, name);
            airportList.Add(airport);
        }

        // Method to get the list of airports
        public List<Airport> getAirline()
        {
            // Load airport data before returning the list
            LoadAirport();
            return airportList;
        }
    }
}
