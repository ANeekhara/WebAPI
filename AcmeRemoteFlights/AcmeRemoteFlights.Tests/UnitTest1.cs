using System;
using System.Collections.Generic;
using AcmeRemoteFlights.Controllers;
using AcmeRemoteFlights.Data;
using AcmeRemoteFlights.DataAccess;
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
        public void TestGetAll()
        {
            Repository<FlightModel> repo = new Repository<FlightModel>();
            FlightDetailsBL flightDetailsBL = new FlightDetailsBL(repo);
            var actual = flightDetailsBL.GetFlightDetails();
            Assert.IsNotNull(actual);
        }
    }
}
