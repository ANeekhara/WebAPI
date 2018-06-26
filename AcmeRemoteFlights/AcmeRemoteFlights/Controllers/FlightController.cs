using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AcmeRemoteFlights.DataAccess.Service;
using AcmeRemoteFlights.ViewModel;


namespace AcmeRemoteFlights.Controllers
{

    [RoutePrefix("api/flights")]
    public class FlightController : ApiController
    {
        //Initialize the Service via constructor DI
        private IFlightService _iFlightService;

        public FlightController(IFlightService iFlightService)
        {

            _iFlightService = iFlightService;
        }

        /// <summary>
        /// Get all the flights 
        /// </summary>
        /// <returns></returns>

        [Route("")]
        public List<FlightViewModel> Get()
        {
            try
            {
                List<FlightViewModel> flightViewModel = new List<FlightViewModel>();
                flightViewModel = _iFlightService.GetAllFlights();
                if (flightViewModel.Count > 0)
                {
                    return flightViewModel;
                }

                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Search the bookings.All the params are mandatory
        /// </summary>
        /// <param name="passengerName"></param>
        /// <param name="departureDate"></param>
        /// <param name="arrivalCity"></param>
        /// <param name="departureCity"></param>
        /// <param name="flightNumer"></param>
        /// <returns></returns>
        [Route(
            "FlightBookings/{passengerName}/{departureDate:regex(\\d{4}-\\d{2}-\\d{2})}/{arrivalCity}/{departureCity}/{flightNumer}")]
        public List<FlightViewModel> GetFlightBookings(string passengerName, DateTime departureDate, string arrivalCity,
            string departureCity, int flightNumer)
        {
            try
            {
                List<FlightViewModel> flightViewModel = new List<FlightViewModel>();
                flightViewModel = _iFlightService.GetFlightBookings(passengerName, departureDate,
                    arrivalCity.ToUpper(), departureCity.ToUpper(), flightNumer);
                return flightViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        /// <summary>
        /// Check the Flight availability based on Flight Start Time
        /// Flight End Time 
        /// Number of seats remaining
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="numberOfPassengers"></param>
        /// <returns></returns>
        [Route(
            "FlightAvailability/{startDate:regex(\\d{4}-\\d{2}-\\d{2})}/{endDate:regex(\\d{4}-\\d{2}-\\d{2})}/{numberOfPassengers}")]
        public List<FlightViewModel> GetFlightAvailability(DateTime startDate, DateTime endDate, int numberOfPassengers)
        {
            try
            {
                List<FlightViewModel> flightViewModel = new List<FlightViewModel>();
                flightViewModel = _iFlightService.GetFlightAvailability(startDate, endDate, numberOfPassengers);
                return flightViewModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return null;
        }

        /// <summary>
        /// Update the booking 
        /// </summary>
        /// <param name="flightNumber"></param>
        /// <param name="passengerName"></param>
        /// <param name="numberOfSeatsBooked"></param>
        /// <returns></returns>
        [Route("MakeBooking/{flightNumber}/{passengerName}/{numberOfSeatsBooked}"),HttpPost]
        public HttpResponseMessage Post([FromUri]int flightNumber,[FromUri] string passengerName,[FromUri] int numberOfSeatsBooked)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _iFlightService.SaveFlightBookings(flightNumber, passengerName, numberOfSeatsBooked);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.InnerException.ToString());
            }
            return Request.CreateResponse(HttpStatusCode.OK);
          
        }


    }
}
