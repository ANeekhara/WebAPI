using System.Reflection;
using System.Web.Http;
using AcmeRemoteFlights.Data;
using AcmeRemoteFlights.DataAccess;
using AcmeRemoteFlights.DataAccess.Service;
using AcmeRemoteFlights.Entities;
using Autofac;
using Autofac.Integration.WebApi;

namespace AcmeRemoteFlights
{
    public class AutofacWebapiConfig
    {
        public static IContainer Container;
        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
          
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<FlightService>().As<IFlightService>();
            builder.RegisterType<FlightDetailsBL>().As<IFlightDetailsBL>();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));
            builder.RegisterType<FlightPassengerBL>().As<IFlightPassengerBL>();
            builder.RegisterType<LookUpBL>().As<ILookUpBL>();
            Container = builder.Build();

            return Container;
        }  
  
    }
}