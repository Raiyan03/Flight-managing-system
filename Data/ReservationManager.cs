using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;


namespace flightManager.Data
{
    public class ReservationManager 
    {
        private string reservationCode;
        private Random random = new Random();
        private List<Reservation> reservations = new List<Reservation>();
        static string path = @"..\..\..\..\..\Resources\Res\reservations.json";
        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, path);
        DataSerialization dataSerialization = new DataSerialization();

        public ReservationManager() 
        {

        }
        public ReservationManager(string Name, string Citizenship, Flight flight )
        {

            reservationCode = GenerateReservationCode();


            Reservation reservation = new Reservation(reservationCode, Name, Citizenship, flight, true);
            LoadReservations();
            reservations.Add(reservation);
        }
        public string GenerateReservationCode()
        {
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
        public string getReservationCode()
        {
            return reservationCode;
        }

        public bool ReservationCodeExists(string code)
        {
            foreach(Reservation reservation in reservations)
            {
                if (reservation.ReservationCode == code)
                { 
                    return true; 
                }

            }
            return false;
        }
         public void SaveReservation()
        {
            dataSerialization.JsonSerialize(reservations, filePath);
        }
        public void LoadReservations()
        {
            reservations = dataSerialization.JsonDeserialize(filePath);
        }

        public List<Reservation> SearchReservation(string ReservationCode, string ReservationName, string AirlineName)
        {
            LoadReservations();
            List<Reservation> SearchedReservations = new List<Reservation>();

            if (ReservationName == null && AirlineName == null)
            {
                if (ReservationCode == null || ReservationCode.Length <= 0)
                {
                    throw new ReservationCodeNotFoundException("Please enter atleast one out of Reservation Code, Airline or Name");
                }
                else
                {
                    foreach (Reservation reservation in reservations)
                    {
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
                foreach(Reservation reservation in reservations)
                {
                    if(ReservationCode == reservation.ReservationCode && ReservationName.ToLower() == reservation.Name.ToLower() && reservation.IsActive == true)
                    {
                        SearchedReservations.Add(reservation);
                    }
                }
                if(SearchedReservations.Count < 1)
                {
                    throw new ReservationCodeNotFoundException("No reservation found");
                }
                return SearchedReservations;
            }
            // ReservationCode and ReservationName are null, but AirlineCode is not
            else if (ReservationCode == null && ReservationName == null && AirlineName != null)
            {
                foreach(Reservation reservation in reservations)
                {
                    if(AirlineName.ToLower() == reservation.Flight.FlightName.ToLower() && reservation.IsActive == true)
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
            else if (ReservationCode == null && ReservationName != null && AirlineName == null)
            {
                foreach(Reservation reservation in reservations)
                {
                    if(ReservationName.ToLower() == reservation.Name.ToLower() && reservation.IsActive == true)
                    {
                        SearchedReservations.Add(reservation);
                    }
                }
                if (SearchedReservations.Count < 1)
                {
                    throw new ReservationCodeNotFoundException("No reservationfound");
                }
                return SearchedReservations;
            }
            else if(ReservationCode != null && ReservationName !=null && AirlineName != null)
            {
                foreach (Reservation reservation in reservations)
                {
                    if (ReservationName.ToLower() == reservation.Name.ToLower() && ReservationCode == reservation.ReservationCode && AirlineName.ToLower() == reservation.Flight.FlightName.ToLower() && reservation.IsActive == true)
                    {
                        SearchedReservations.Add(reservation);
                    }
                }
                if (SearchedReservations.Count < 1)
                {
                    throw new ReservationCodeNotFoundException("No reservationfound");
                }
                return SearchedReservations;
            }

            throw new ReservationCodeNotFoundException("No reservation found");
        }
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
                    if(Citizenship == null)
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
