using System;

namespace AcmeRemoteFlights.ViewModel
{
    
    public class FlightViewModel
    {
        public int FlightNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PassengerCapacity { get; set; }
        public string DepartureCityDescription { get; set; }
        public string ArrivalCityDescription { get; set; }
        public int DepartureCityValue { get; set; }
        public int ArrivalCityValue { get; set; }
    }
}
