using System.Web.Http;

namespace AcmeRemoteFlights
{
    public class Bootstrapper
    {
        public static void Run()
        {
            //Configure AutoFac  
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
           
        }

    }
}