using System;
using System.Collections.Generic;
using AcmeRemoteFlights.Controllers;
using AcmeRemoteFlights.Data;
using AcmeRemoteFlights.DataAccess.Service;
using AcmeRemoteFlights.Entities;
using AcmeRemoteFlights.ViewModel;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcmeRemoteFlights.Tests
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestMethod]
        public void TestDbConnectionGetAll()
        {
            
            Repository<FlightModel>  repo= new Repository<FlightModel>();
            var result  = repo.GetBy();
            Assert.IsTrue( result.Count>0,"Connection to LiteDb is successfull");
        }

        [TestMethod]
        public void TestGet()
        {

            var mockServiceMock = new Mock<IFlightService>();
            var flightController = new FlightController(mockServiceMock.Object);
            List<FlightViewModel> actual = flightController.Get();
            Assert.IsNotNull(actual);
        }

        [TestMethod]
        public void TestSearchBookings()
        {

            
            var mockServiceMock = new Mock<IFlightService>();
          
            List<FlightViewModel> expected = new List<FlightViewModel>();
            expected.Add(new FlightViewModel()
            {
                FlightNumber = 2,
                StartTime = Convert.ToDateTime("2018-06-25"),
                EndTime =Convert.ToDateTime( "2018-06-25"),
                PassengerCapacity = 150,
                ArrivalCityDescription ="MELBOURNE",
                ArrivalCityValue = 1,
                DepartureCityDescription = "BRISBANE",
                DepartureCityValue= 3
            });
           
            DateTime date = Convert.ToDateTime("2018-06-25");
            mockServiceMock
                .Setup(x => x.GetFlightBookings("Test1", date, "Melbourne", "Brisbane", 2))
                .Returns(expected);
            var flightController = new FlightController(mockServiceMock.Object);

            List<FlightViewModel> actual = flightController.GetFlightBookings("Test1", date, "Melbourne", "Brisbane", 2);
            Assert.IsNotNull(actual);

            CollectionAssert.AreEqual(expected, actual);
        }

  }
}
