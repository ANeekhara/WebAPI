using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcmeRemoteFlights.Utility;
using AcmeRemoteFlights.ViewModel;

namespace AcmeRemoteFlights.DataAccess.Service
{
   public class FlightService :IFlightService
    {
        private IFlightDetailsBL _iFlightDetailsBL;
        private IFlightPassengerBL _iFlightPassengerBL;
        private ILookUpBL _lookUpBL;
       
        public FlightService(IFlightDetailsBL iFlightDetailsBL, IFlightPassengerBL iFlightPassengerBL,ILookUpBL lookUpBL)
        {
            _iFlightDetailsBL = iFlightDetailsBL;
            _iFlightPassengerBL = iFlightPassengerBL;
            _lookUpBL = lookUpBL;
        }
       
        public List<FlightViewModel> GetAllFlights()
        {
            List<FlightViewModel> flightViewModel = new List<FlightViewModel>();
            List<LookUpViewModel> lookUpViewModel = new List<LookUpViewModel>();

            //Get the list of flights
            flightViewModel = _iFlightDetailsBL.GetFlightDetails();

            //Resolve the City numbers to Name 
            lookUpViewModel = _lookUpBL.GetLookUp(Enum.GetName(typeof(LookUpType), 1));

            List<FlightViewModel> flightDetails = flightViewModel.Select(s =>
            {
                s.ArrivalCityDescription = (lookUpViewModel.Where(l => l.LookupNumber == s.ArrivalCityValue).Select(d=>d.Description).FirstOrDefault());
                s.DepartureCityDescription = (lookUpViewModel.Where(l => l.LookupNumber == s.DepartureCityValue).Select(d=>d.Description).FirstOrDefault());
                return s;
            }).ToList();

            return flightDetails;
        }

    
        /// <summary>
        /// by passenger name, date, arrival city, departure city, flight number
       /// </summary>
       /// <param name="passengerName"></param>
       /// <param name="departureDate"></param>
       /// <param name="arrivalCity"></param>
       /// <param name="departureCity"></param>
        /// <param name="flightNumber"></param>
       /// <returns></returns>
        public List<FlightViewModel> GetFlightBookings(string passengerName, DateTime departureDate, string arrivalCity,
                                                        string departureCity, int flightNumber)
        {
            List<FlightViewModel> flightViewModel = new List<FlightViewModel>();
            List<FlightPassengerViewModel> passengerViewModel = new List<FlightPassengerViewModel>();
            passengerViewModel = _iFlightPassengerBL.GetPassengerDetails(passengerName,flightNumber);

            int lookupArrivalCity = 0;
            int lookupDepartureCity = 0;
            if (passengerViewModel.Any())
            {
                flightViewModel = _iFlightDetailsBL.GetFlightDetails();

            }
            if (Enum.IsDefined(typeof(City), arrivalCity))
            {
                lookupArrivalCity = (int) Enum.Parse(typeof(City), arrivalCity);
            }
            if (Enum.IsDefined(typeof(City), departureCity))
            {
                lookupDepartureCity = (int)Enum.Parse(typeof(City), departureCity);
            }
           
            var passengerBookingFound = flightViewModel
                .Where(x => passengerViewModel.Any(y => y.FlightNumber == x.FlightNumber)).ToList();

            return passengerBookingFound.Where(x =>  departureDate >= x.StartTime.Date  && departureDate <= x.EndTime.Date 
                                               && x.ArrivalCityValue == lookupArrivalCity
                                               && x.DepartureCityValue == lookupDepartureCity).ToList();

        }

        public List<FlightViewModel> GetFlightAvailability(DateTime startDate, DateTime endDate, int numberOfPassengers)
        {
            List<FlightViewModel> flightViewModel = new List<FlightViewModel>();
            flightViewModel = _iFlightDetailsBL.GetFlightDetailsByPredicate(startDate, endDate, numberOfPassengers);
            return flightViewModel;
        }

        public void  SaveFlightBookings(int flightNumber, string passengerName, int numberOfSetasBooked)
        {
             _iFlightDetailsBL.InsertFlightDetails(flightNumber, passengerName, numberOfSetasBooked);
            _iFlightPassengerBL.InsertFlightDetails(flightNumber, passengerName, numberOfSetasBooked);
        }
    }
}
