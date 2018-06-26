
using System;
using System.Collections.Generic;
using AcmeRemoteFlights.Entities;
using AcmeRemoteFlights.ViewModel;


namespace AcmeRemoteFlights.DataAccess
{
    public interface IFlightPassengerBL
    {
        List<FlightPassengerViewModel> GetPassengerDetails(string passengerName, int flightNumber);

        void InsertFlightDetails(int flightNumber, string passengerName, int numberOfSetasBooked);
    }
}
