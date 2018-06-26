using System;

namespace AcmeRemoteFlights.ViewModel
{
   public class FlightPassengerViewModel
    {
        public int FlightNumber { get; set; }
        public string PassengerName { get; set; }
        public int NumberOfPassengersBooked { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
    }
}
