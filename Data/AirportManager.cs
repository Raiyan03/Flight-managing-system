using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{
    public class AirportManager
    {
        private List<Airport> airportList = new List<Airport>();
        private void LoadAirport ()
        {
            string path = @"..\..\..\..\..\Resources\Res\airports.csv";
            string FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);

            using(var streamReader = new StreamReader(FilePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] cells = line.Split(',');
                    string AirportCode = cells[0];
                    string AirportName = cells[1];
                    CreateAirport (AirportCode, AirportName);
                }
            }
        }
        private void CreateAirport(string code, string name)
        {
            Airport airport = new Airport(code, name);
            airportList.Add(airport);
        }
        public List<Airport> getAirline() 
        { 
            LoadAirport();
            return airportList;
        }
    }
}
