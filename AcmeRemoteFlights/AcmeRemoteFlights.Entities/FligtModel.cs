using System;
using System.ComponentModel.DataAnnotations.Schema;
using LiteDB;

namespace AcmeRemoteFlights.Entities
{
    [Table("tblFlight")]
    public class FlightModel
    {
        [BsonId]
        public Guid FlightId { get; set; }
        public int FlightNumber { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PassengerCapacity { get; set; }
        public int DepartureCity { get; set; }
        public int ArrivalCity { get; set; }
    }
}
