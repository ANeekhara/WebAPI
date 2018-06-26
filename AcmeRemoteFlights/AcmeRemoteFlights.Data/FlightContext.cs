using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SQLite;
using AcmeRemoteFlights.Model;
using LiteDB;


namespace AcmeRemoteFlights.Data
{

    public class FlightContext 
    {
        private FlightViewModel _flightViewModel = new FlightViewModel();

        public FlightContext()
        {
            using (var db = new LiteDatabase(connection))
            {
                
            }
            
        }
      
    }


    //public class FlightContext : DbContext
    //{
    //    private FlightViewModel _flightViewModel = new FlightViewModel();

    //    public FlightContext()
    //       : base(
    //    {
    //        ConnectionString =
    //            new SQLiteConnectionStringBuilder() {DataSource = "D:\\Databases\\SQLiteWithEF.db", ForeignKeys = true}
    //                .ConnectionString
    //    }, true)

    //    {
    //    }
    //}

//        public DbSet<FlightViewModel> Flight
//{
//get;
//D
//}
//    }
}
