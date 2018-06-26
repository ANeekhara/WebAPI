using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace AcmeRemoteFlights.Utility
{
   public static class Common
    {
        public static string  GetTableAttribute<T>(T viewModel)
        {
            string tableName = string.Empty;
            var customAttributes = typeof(T).GetTypeInfo().GetCustomAttributes<TableAttribute>();
            var tableAttributes = customAttributes as IList<TableAttribute> ?? customAttributes.ToList();
            if (tableAttributes.Any())
            {
                tableName = tableAttributes.First().Name;
            }
            return tableName;

        }
    }
}
