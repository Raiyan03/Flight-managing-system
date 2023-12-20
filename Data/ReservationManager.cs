using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace flightManager.Data
{
    // Manager class responsible for handling reservations
    public class ReservationManager
    {
        private string reservationCode;
        private Random random = new Random();
        private List<Reservation> reservations = new List<Reservation>();
        static string path = @"..\..\..\..\..\Resources\Res\reservations.json";
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        DataSerialization dataSerialization = new DataSerialization();

        // Default constructor
        public ReservationManager()
        {

        }

        // Constructor to create a new reservation
        public ReservationManager(string Name, string Citizenship, Flight flight)
        {
            reservationCode = GenerateReservationCode();
            Reservation reservation = new Reservation(reservationCode, Name, Citizenship, flight, true);
            LoadReservations();
            reservations.Add(reservation);
        }

        // Generate a unique reservation code
        public string GenerateReservationCode()
        {
            // Unique code generation logic
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            StringBuilder randomString = new StringBuilder();

            randomString.Append(alphabet[random.Next(0, alphabet.Length)]);

            for (int i = 0; i < 4; i++)
            {
                randomString.Append(digits[random.Next(0, digits.Length)]);
            }

            while (ReservationCodeExists(randomString.ToString()))
            {
                randomString.Clear();
                randomString.Append(alphabet[random.Next(0, alphabet.Length)]);
                for (int i = 0; i < 4; i++)
                {
                    randomString.Append(digits[random.Next(0, digits.Length)]);
                }
            }

            return randomString.ToString();
        }

        // Get the current reservation code
        public string getReservationCode()
        {
            return reservationCode;
        }

        // Check if a reservation code already exists
        public bool ReservationCodeExists(string code)
        {
            foreach (Reservation reservation in reservations)
            {
                if (reservation.ReservationCode == code)
                {
                    return true;
                }
            }
            return false;
        }

        // Save reservations to a JSON file
        public void SaveReservation()
        {
            dataSerialization.JsonSerialize(reservations, filePath);
        }

        // Load reservations from a JSON file
        public void LoadReservations()
        {
            reservations = dataSerialization.JsonDeserialize(filePath);
        }

        // Search for reservations based on specified criteria
        public List<Reservation> SearchReservation(string ReservationCode, string ReservationName, string AirlineName)
        {
            // Search logic based on specified criteria
            LoadReservations();
            List<Reservation> SearchedReservations = new List<Reservation>();

            // Check if ReservationName and AirlineName are null
            if (ReservationName == null && AirlineName == null)
            {
                // Check if ReservationCode is null or empty
                if (ReservationCode == null || ReservationCode.Length <= 0)
                {
                    throw new ReservationCodeNotFoundException("Please enter at least one out of Reservation Code, Airline or Name");
                }
                else
                {
                    foreach (Reservation reservation in reservations)
                    {
                        // Find matching reservation by ReservationCode and isActive status
                        if (reservation.ReservationCode == ReservationCode && reservation.IsActive == true)
                        {
                            SearchedReservations.Add(reservation);
                            return SearchedReservations;
                        }
                    }
                }
                throw new ReservationCodeNotFoundException("Entered Reservation is invalid");
            }
            // ReservationName is null, but others are not
            else if (ReservationCode != null && ReservationName == null && AirlineName != null)
            {
                // Find matching reservations by ReservationCode, AirlineName, and isActive status
                foreach (Reservation reservation in reservations)
                {
                    if (ReservationCode == reservation.ReservationCode && AirlineName.ToLower() == reservation.Flight.FlightName.ToLower() && reservation.IsActive == true)
                    {
                        SearchedReservations.Add(reservation);
                    }
                }
                if (SearchedReservations.Count < 1)
                {
                    throw new ReservationCodeNotFoundException("No reservation found");
                }
                return SearchedReservations;
            }
            // ReservationCode is null, but others are not
            else if (ReservationCode == null && ReservationName != null && AirlineName != null)
            {
                // Find matching reservations by ReservationName, AirlineName, and isActive status
                foreach (Reservation reservation in reservations)
                {
                    if (ReservationName.ToLower() == reservation.Name.ToLower() && AirlineName.ToLower() == reservation.Flight.FlightName.ToLower() && reservation.IsActive == true)
                    {
                        SearchedReservations.Add(reservation);
                    }
                }
                if (SearchedReservations.Count < 1)
                {
                    throw new ReservationCodeNotFoundException("No reservation found");
                }
                return SearchedReservations;
            }
            // AirlineCode is null, but others are not
            else if (ReservationCode != null && ReservationName != null && AirlineName == null)
            {
                // Find matching reservations by ReservationCode, ReservationName, and isActive status
                foreach (Reservation reservation in reservations)
                {
                    if (ReservationCode == reservation.ReservationCode && ReservationName.ToLower() == reservation.Name.ToLower() && reservation.IsActive == true)
                    {
                        SearchedReservations.Add(reservation);
                    }
                }
                if (SearchedReservations.Count < 1)
                {
                    throw new ReservationCodeNotFoundException("No reservation found");
                }
                return SearchedReservations;
            }
            // ReservationCode and ReservationName are null, but AirlineCode is not
            else if (ReservationCode == null && ReservationName == null && AirlineName != null)
            {
                // Find matching reservations by AirlineName and isActive status
                foreach (Reservation reservation in reservations)
                {
                    if (AirlineName.ToLower() == reservation.Flight.FlightName.ToLower() && reservation.IsActive == true)
                    {
                        SearchedReservations.Add(reservation);
                    }
                }
                if (SearchedReservations.Count < 1)
                {
                    throw new ReservationCodeNotFoundException("No reservation found");
                }
                return SearchedReservations;
            }
            // ReservationCode is null, but ReservationName is not null
            else if (ReservationCode == null && ReservationName != null && AirlineName == null)
            {
                // Find matching reservations by ReservationName and isActive status
                foreach (Reservation reservation in reservations)
                {
                    if (ReservationName.ToLower() == reservation.Name.ToLower() && reservation.IsActive == true)
                    {
                        SearchedReservations.Add(reservation);
                    }
                }
                if (SearchedReservations.Count < 1)
                {
                    throw new ReservationCodeNotFoundException("No reservation found");
                }
                return SearchedReservations;
            }
            // ReservationCode, ReservationName, and AirlineCode are not null
            else if (ReservationCode != null && ReservationName != null && AirlineName != null)
            {
                // Find matching reservations by ReservationName, ReservationCode, AirlineName, and isActive status
                foreach (Reservation reservation in reservations)
                {
                    if (ReservationName.ToLower() == reservation.Name.ToLower() && ReservationCode == reservation.ReservationCode && AirlineName.ToLower() == reservation.Flight.FlightName.ToLower() && reservation.IsActive == true)
                    {
                        SearchedReservations.Add(reservation);
                    }
                }
                if (SearchedReservations.Count < 1)
                {
                    throw new ReservationCodeNotFoundException("No reservation found");
                }
                return SearchedReservations;
            }

            throw new ReservationCodeNotFoundException("No reservation found");
        }

        // Update reservation details
        public void Update(string Name, string Citizenship, bool isAvtive, Flight flight, Reservation Reservation)
        {
            foreach (Reservation reservation in reservations)
            {
                if (reservation == Reservation)
                {
                    if (Name == null)
                    {
                        throw new NameNullOrEmptyException("Name cannot be empty");
                    }
                    else
                    {
                        reservation.Name = Name;
                    }
                    if (Citizenship == null)
                    {
                        throw new CitizenshipNullOrEmptyException("Citizenship cannot be empty");
                    }
                    else
                    {
                        reservation.Citizenship = Citizenship;
                    }

                    reservation.IsActive = isAvtive;

                    if (reservation.IsActive == false)
                    {
                        FindFlights cancel = new FindFlights();
                        cancel.Cancellation(flight);
                    }
                    dataSerialization.JsonSerialize(reservations, filePath);
                }
            }
        }
    }
}
