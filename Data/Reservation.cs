using System;
using System.Collections.Generic;

namespace flightManager.Data
{
    [Serializable]
    public class Reservation
    {
        // Fields for reservation details
        private Flight flight;
        private string name;
        private string citizenship;
        private string reservationCode;
        private bool isActive;

        // Property for the passenger's name with validation
        public string Name
        {
            get { return name; }
            set
            {
                // Validate that the name is not null or empty
                if (string.IsNullOrEmpty(value))
                {
                    throw new NameNullOrEmptyException("Name cannot be empty.");
                }
                name = value;
            }
        }

        // Property for the passenger's citizenship with validation
        public string Citizenship
        {
            get { return citizenship; }
            set
            {
                // Validate that the citizenship is not null or empty
                if (string.IsNullOrEmpty(value))
                {
                    throw new CitizenshipNullOrEmptyException("Citizenship cannot be empty.");
                }
                citizenship = value;
            }
        }

        // Property for the associated flight with validation for available seats
        public Flight Flight
        {
            get { return flight; }
            set
            {
                // Validate that the flight is not null and has available seats
                if (value != null && value.FlightTotalSeat == 0)
                {
                    throw new NoAvailableSeatsException("Flight has no available seats.");
                }
                flight = value;
            }
        }

        // Property for the reservation code
        public string ReservationCode
        {
            get { return reservationCode; }
            set { reservationCode = value; }
        }

        // Property for the reservation status
        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        // Default constructor
        public Reservation()
        {

        }

        // Parameterized constructor for creating a reservation
        public Reservation(string reservationCode, string name, string citizenship, Flight flight, bool isActive)
        {
            Name = name;
            Citizenship = citizenship;
            Flight = flight;
            ReservationCode = reservationCode;
            IsActive = isActive;
        }
    }
}
