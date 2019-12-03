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

        public IQueryable<T> Fetch(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = this.RepositoryContext.Set<T>();

            if (filter != null)
                query = query.Where(filter);

            return query;
        }

        public T GetById(object id)
        {
            return this.RepositoryContext.Set<T>().Find(id);
        }

        public void Add(T entity)
        {
            this.RepositoryContext.Set<T>().Add(entity);
            this.RepositoryContext.SaveChanges();
        }

      
        public void DeleteAll(List<T> entityList)
        {
            foreach (var entity in entityList)
            {
                var entry = this.RepositoryContext.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    this.RepositoryContext.Set<T>().Attach(entity);
                }
                this.RepositoryContext.Set<T>().Remove(entity);
                this.RepositoryContext.SaveChanges();

            }
        }

        
        public void SaveChanges()
        {
            this.RepositoryContext.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            this.RepositoryContext.SaveChangesAsync();
        }

        public async Task SaveChangesTaskAsync()
        {
            await this.RepositoryContext.SaveChangesAsync();
        }

        public void UpdateChanges(T entity)
        {
            var entry = this.RepositoryContext.Entry<T>(entity);
            entry.State = EntityState.Modified;
            this.RepositoryContext.SaveChanges();
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = this.RepositoryContext.Set<T>();

            if (navigationProperties != null)
                dbQuery = navigationProperties.Aggregate(dbQuery.Where(where).AsQueryable(), (current, include) => current.Include(include));

            return dbQuery.ToList();
        }


        public IList<T> GetList(Func<T, bool> where, Expression<Func<T, object>> orderBy, SortOrder sortOrder, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = this.RepositoryContext.Set<T>();

            if (navigationProperties != null)
                dbQuery = navigationProperties.Aggregate(dbQuery.Where(where).AsQueryable(), (current, include) => current.Include(include));

            if (orderBy != null)
            {
                if (sortOrder == SortOrder.Ascending)
                {
                    dbQuery = dbQuery.OrderBy(orderBy);
                }
                else if (sortOrder == SortOrder.Descending)
                {
                    dbQuery = dbQuery.OrderByDescending(orderBy);
                }
            }
            return dbQuery.ToList();
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T entity = null;
            IQueryable<T> dbQuery = this.RepositoryContext.Set<T>();

            if (navigationProperties != null)
                dbQuery = navigationProperties.Aggregate(dbQuery.AsNoTracking().Where(where).AsQueryable(), (current, include) => current.Include(include));



            entity = dbQuery.SingleOrDefault();

            return entity;
        }

        public T GetSingle(Func<T, bool> where, Expression<Func<T, object>> orderByDescending, params Expression<Func<T, object>>[] navigationProperties)
        {
            T entity = null;
            IQueryable<T> dbQuery = this.RepositoryContext.Set<T>();

            if (navigationProperties != null)
                dbQuery = navigationProperties.Aggregate(dbQuery.AsNoTracking().Where(where).AsQueryable(), (current, include) => current.Include(include));

            if (orderByDescending != null)
                dbQuery = dbQuery.OrderByDescending(orderByDescending);

            entity = dbQuery.SingleOrDefault();

            return entity;
        }

        
      
        public T Reload(T entity)
        {
            this.RepositoryContext.Entry(entity).Reload();
            return entity;
        }


        public void AddRange(List<T> entityList)
        {
            this.RepositoryContext.Set<T>().AddRange(entityList);
            this.RepositoryContext.SaveChanges();
        }

        public void ExecSqlCommand(string sql, params object[] parameters)
        {
            this.RepositoryContext.Database.ExecuteSqlCommand(sql, parameters);
        }

    }
}
