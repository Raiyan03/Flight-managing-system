using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{
    public class Airport
    {
        private string airportCode;
        private string airportName;

        public string AirportCode
        {
            get { return airportCode; }
            set { airportCode = value; }
        }
        public string AirportName
        {
            get { return airportName; }
            set { airportName = value; }
        }
        public Airport(string airport_code, string airport_name) 
        {
            AirportName = airport_name;
            AirportCode = airport_code;
        }
    }
}
