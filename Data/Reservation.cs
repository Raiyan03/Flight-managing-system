using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace flightManager.Data
{
    [Serializable]
    public class Reservation
    {
        private Flight flight;
        private string name;
        private string citizenship;
        private string reservationCode;
        private bool isActive;

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new NameNullOrEmptyException("Name cannot be empty.");
                }
                name = value;
            }
        }

        public string Citizenship
        {
            get { return citizenship; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new CitizenshipNullOrEmptyException("Citizenship cannot be empty.");
                }
                citizenship = value;
            }
        }

        public Flight Flight
        {
            get { return flight; }
            set
            {
                if (value != null && value.FlightTotalSeat == 0)
                {
                    throw new NoAvailableSeatsException("Flight has no available seats.");
                }
                flight = value;
            }
        }
        public string ReservationCode
        {
            get { return reservationCode; }
            set { reservationCode = value; }
        }
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public Reservation()
        {

        }
        public Reservation(string reservationCode,string name, string citizenship, Flight flight, bool isActive)
        {
            Name = name;
            Citizenship = citizenship;
            Flight = flight;
            ReservationCode = reservationCode;
            IsActive = isActive;
        }
    }

    
}
