using System;
using System.Collections.Generic;
using System.Linq;
using AcmeRemoteFlights.Data;
using AcmeRemoteFlights.Entities;
using AcmeRemoteFlights.ViewModel;
using AutoMapper;


namespace AcmeRemoteFlights.DataAccess
{
    public class FlightDetailsBL :IFlightDetailsBL
    {
        private IFlightDetailsBL _iFlightDetailsBL;
        private IRepository<FlightModel> _repository;
      
        public FlightDetailsBL(IRepository<FlightModel> repository)
        {
            _repository = repository;
        }
        public  List<FlightViewModel> GetFlightDetails()
        {
           List<FlightViewModel> flightDetails = new List<FlightViewModel>();
            List<FlightModel> flightModel = new List<FlightModel>();
            flightModel = _repository.GetBy();
            foreach (var flighInfo in flightModel)
            {
                flightDetails.Add(new FlightViewModel
                {
                    FlightNumber = flighInfo.FlightNumber,
                    StartTime = flighInfo.StartTime,
                    EndTime = flighInfo.EndTime,
                    PassengerCapacity = flighInfo.PassengerCapacity,
                    DepartureCityDescription = flighInfo.DepartureCity.ToString(),
                    ArrivalCityDescription = flighInfo.ArrivalCity.ToString(),
                    ArrivalCityValue = flighInfo.ArrivalCity,
                    DepartureCityValue = flighInfo.DepartureCity
                });
                
            }
        
            return flightDetails;
        }


      public List<FlightViewModel> GetFlightDetailsByPredicate(DateTime startDate, DateTime endDate, int numberOfPassengers)
      {
          List<FlightViewModel> flightDetails = new List<FlightViewModel>();
          List<FlightModel> flightModel = new List<FlightModel>();

          flightModel = _repository.GetByPredicate(x => x.StartTime >= startDate && x.EndTime <= endDate)
              .Where(x => x.PassengerCapacity >= numberOfPassengers).ToList();

          foreach (var flighInfo in flightModel)
          {
              flightDetails.Add(new FlightViewModel
              {
                  FlightNumber = flighInfo.FlightNumber,
                  StartTime = flighInfo.StartTime,
                  EndTime = flighInfo.EndTime,
                  PassengerCapacity = flighInfo.PassengerCapacity,
                  DepartureCityDescription = flighInfo.DepartureCity.ToString(),
                  ArrivalCityDescription = flighInfo.ArrivalCity.ToString(),
           });

          }
          //  flightDetails = Mapper.Map<List<FlightModel>, List<FlightViewModel>>(flightModel);
          return flightDetails;
      }
        public void InsertFlightDetails(int flightNumber, string passengerName, int numberOfSetasBooked)
        {
          var flightDetails =  _repository.GetByPredicate(x => x.FlightNumber == flightNumber);
        var flightModel = flightDetails.Select(x =>
            {
                x.PassengerCapacity = x.PassengerCapacity - numberOfSetasBooked;
                return x;
            }).FirstOrDefault();
            _repository.Update(flightModel);
          
        }
    }
}
