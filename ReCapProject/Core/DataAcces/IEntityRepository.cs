using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;
using Core.Entities;
using System.Security.Principal;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter); // tek bir detaya gitmek istediğinde

        List<T> GetAll(Expression<Func<T, bool>> filter = null); // her türlü filtreyi yapmak için.

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}