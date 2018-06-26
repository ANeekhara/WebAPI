using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeRemoteFlights.ViewModel;

namespace AcmeRemoteFlights.DataAccess.Service
{
  public interface IFlightService
  {
       List<FlightViewModel> GetAllFlights();

       List<FlightViewModel> GetFlightBookings(string passengerName, DateTime departureDate, string arrivalCity,
          string departureCity, int flightNumber);

      List<FlightViewModel> GetFlightAvailability(DateTime startDate,DateTime endDate, int numberOfPassengers);

     void SaveFlightBookings(int flightNumber, string passengerName, int numberOfSetasBooked);
  }
}
