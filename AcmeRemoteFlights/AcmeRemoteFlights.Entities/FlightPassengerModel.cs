using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LiteDB;

namespace AcmeRemoteFlights.Entities
{
    [Table("tblFlightPassenger")]
    public class FlightPassengerModel
    {
        [BsonId]
        public Guid PassengerId { get; set; }
        public int FlightNumber { get; set; }
        public string PassengerName { get; set; }
        public int NumberOfPassengersBooked { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateEdited { get; set; }
    }
}
