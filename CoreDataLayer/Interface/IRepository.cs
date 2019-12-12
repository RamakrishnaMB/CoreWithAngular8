using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreDataLayer.Interface
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);

        IQueryable<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        T GetById(object id);

        void Add(T entity);
        

        void DeleteAll(List<T> entityList);
        
        void UpdateChanges(T entity);
        void SaveChanges();

        Task SaveChangesAsync();

        Task<T> FindAsync(object id);
        IQueryable<T> Fetch(Expression<Func<T, bool>> filter = null);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, Expression<Func<T, object>> orderBy, SortOrder sortOrder, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, Expression<Func<T, object>> orderByDescending, params Expression<Func<T, object>>[] navigationProperties);
        
        T Reload(T entity);

        void AddRange(List<T> entityList);
        void ExecSqlCommand(string sql, params object[] parameters);
    }
}
