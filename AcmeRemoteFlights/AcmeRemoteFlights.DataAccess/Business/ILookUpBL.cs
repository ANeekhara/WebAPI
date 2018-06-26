
using System.Collections.Generic;
using AcmeRemoteFlights.Entities;
using AcmeRemoteFlights.ViewModel;


namespace AcmeRemoteFlights.DataAccess
{
    public interface ILookUpBL
    {
        List<LookUpViewModel> GetLookUp(string lookUpType);
    }
}
