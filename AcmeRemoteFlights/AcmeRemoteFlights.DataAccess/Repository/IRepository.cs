


using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace AcmeRemoteFlights.Data
{

    public interface IRepository<T> where T : class
    {

        List<T> GetByPredicate(Expression<Func<T, bool>> predicate);

        void Create(T entity, string name);

        void Delete(T entity);

        void Update(T entity);

        List<T> GetBy();

    }
}
