
using System;
using System.Collections.Generic;
using AcmeRemoteFlights.Entities;
using AcmeRemoteFlights.ViewModel;


namespace AcmeRemoteFlights.DataAccess
{
    public interface IFlightDetailsBL
    {
        List<FlightViewModel> GetFlightDetails();

        List<FlightViewModel> GetFlightDetailsByPredicate(DateTime startDate, DateTime endDate, int numberOfPassengers);
      
        void InsertFlightDetails(int flightNumber, string passengerName, int numberOfSetasBooked);

    }
}
