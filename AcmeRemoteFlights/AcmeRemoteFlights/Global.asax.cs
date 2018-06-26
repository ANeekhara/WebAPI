using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;


namespace AcmeRemoteFlights
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           // Database.SetInitializer<FlightContext>(null);
            AreaRegistration.RegisterAllAreas();
            Bootstrapper.Run(); 
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
