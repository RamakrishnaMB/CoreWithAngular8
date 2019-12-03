using CoreDataLayer.Interface;
using CoreDataLayer.ModelsDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Implementation
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly dbTestContext RepositoryContext;
        public Repository(dbTestContext context)
        {
            RepositoryContext = context;
        }

        public IQueryable<T> FindAll()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.RepositoryContext.Set<T>().Remove(entity);
        }

        //RK 
        
        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = this.RepositoryContext.Set<T>();

            if (navigationProperties != null)
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, include) => current.Include(include));

            return dbQuery.AsNoTracking();
        }

    }
}
