using System;
using System.Collections.Generic;
using System.Linq;
using AcmeRemoteFlights.Data;
using AcmeRemoteFlights.Entities;
using AcmeRemoteFlights.ViewModel;
using AutoMapper;


namespace AcmeRemoteFlights.DataAccess
{
    public class FlightPassengerBL :IFlightPassengerBL
    {
        private IFlightPassengerBL _iFlightPassengerBL;
        private IRepository<FlightPassengerModel> _iRepository;

        //public FlightPassengerBL()
        //{
        //    _repository = new Repository<FlightPassengerModel>();
        //}

        public FlightPassengerBL(IRepository<FlightPassengerModel> iRrepository)
        {
            _iRepository = iRrepository;
        }
        public  List<FlightPassengerViewModel> GetPassengerDetails(string passengerName,int flightNumber)
        {
          
          List<FlightPassengerViewModel> passengerDetails = new List<FlightPassengerViewModel>();
          List<FlightPassengerModel> flightPassengerModel = new List<FlightPassengerModel>();
            flightPassengerModel = _iRepository.GetByPredicate(x => x.PassengerName == passengerName ||
                                                   x.FlightNumber == flightNumber).ToList();
            foreach (var passengerInfo in flightPassengerModel)
            {
                passengerDetails.Add(new FlightPassengerViewModel()
                {
                    FlightNumber =  passengerInfo.FlightNumber,
                    PassengerName = passengerInfo.PassengerName
                });
            }
            return passengerDetails;
        }


        public void InsertFlightDetails(int flightNumber, string passengerName, int numberOfSetasBooked)
        {
            FlightPassengerModel flightPassengerModel = new FlightPassengerModel();
            flightPassengerModel.PassengerId = Guid.NewGuid();
            flightPassengerModel.FlightNumber = flightNumber;
            flightPassengerModel.PassengerName = passengerName;
            flightPassengerModel.NumberOfPassengersBooked = numberOfSetasBooked;
            flightPassengerModel.DateCreated = DateTime.Now;
            flightPassengerModel.DateEdited = DateTime.Now;
            _iRepository.Update(flightPassengerModel);
        }
    }
}
