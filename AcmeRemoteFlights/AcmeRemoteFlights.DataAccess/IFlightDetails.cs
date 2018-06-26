using System.Collections.Generic;
using AcmeRemoteFlights.Model;

namespace AcmeRemoteFlights.DataAccess
{
    public interface IFlightDetails
    {
        #region  CRUD

        List<FlightViewModel> GetFlightDetails();

        List<FlightViewModel> InsertFlightDetails(List<FlightViewModel> flightViewModel);

        #endregion
    }
}
