
using System;
using System.Collections.Generic;
using AcmeRemoteFlights.Data;
using AcmeRemoteFlights.Entities;
using AcmeRemoteFlights.ViewModel;


namespace AcmeRemoteFlights.DataAccess
{
    /// <summary>
    /// Get the data for the type of data passed - for this practice test the look fetched is for City.
    /// </summary>
    public class LookUpBL : ILookUpBL
    {
        private ILookUpBL _iLookUpBL;
        private Repository<LookUpModel> _repository;

        public LookUpBL()
        {
            _repository = new Repository<LookUpModel>();
        }

        public List<LookUpViewModel> GetLookUp(string lookUpType)
        {
            List<LookUpViewModel> lookUpViewModel = new List<LookUpViewModel>();
            List<LookUpModel> lookUpModel = new List<LookUpModel>();
            lookUpModel = _repository.GetByPredicate(x=>x.LookUpType == lookUpType);
            foreach (var lookUpInfo in lookUpModel)
            {
                lookUpViewModel.Add(new LookUpViewModel
                {
                    LookupNumber = lookUpInfo.LookupNumber,
                    Description = lookUpInfo.Description
                });
              }
            return lookUpViewModel;

        }
    }
}
