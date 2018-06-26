using System;
using System.Collections.Generic;
using System.IO;
using LiteDB;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using AcmeRemoteFlights.Utility;


namespace AcmeRemoteFlights.Data
{

    public class Repository<T> : IRepository<T>
        where T :class, new()

    {
        private readonly LiteDatabase _connection;
        
        public Repository()
        {

            var currentLocation = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Flight.db");
            _connection = new LiteDatabase(currentLocation);
        }
        public void Create(T viewModel , string table)
        {
            var collection = _connection.GetCollection<T>(table);
            var results = collection.FindAll();
           
            collection.Insert(viewModel);

        }

        public void Delete(T entity)
        {

            //Write your logic here to delete an entity

        }

        //public T GetById(long id)
       public List<T> GetByPredicate(Expression<Func<T, bool>> predicate)
       {
           string tableName = Common.GetTableAttribute(new T());
          var collection = _connection.GetCollection<T>(tableName);
            //Write your logic here to retrieve an entity by Id
            return collection.Find(predicate).ToList();

        }

        public void Update(Expression<Func<T, bool>> predicate)
        {
            string tableName = Common.GetTableAttribute(new T());
            var collection = _connection.GetCollection<T>(tableName);
            var updateData = collection.Find(predicate).ToList();
            collection.Update(updateData);
        }

        public void Update(T entity)
        {
            string tableName = Common.GetTableAttribute(new T());
            var collection = _connection.GetCollection<T>(tableName);
            collection.Update(entity);
        }

        public List<T> GetBy()
        {
            string tableName = Common.GetTableAttribute(new T());
            var collection = _connection.GetCollection<T>(tableName);
            var results = collection.FindAll().ToList();
            return results;
        }
    }
}
