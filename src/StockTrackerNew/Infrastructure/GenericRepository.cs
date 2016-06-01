using StockTrackerNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// namespace CoderCamps.Infrastructure
namespace StockTrackerNew.Infrastructure
{
    public class GenericRepository<T> : IDisposable where T : class
    {
        protected ApplicationDbContext _db;

        public GenericRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public void Add(T entity)
        {
            _db.Set<T>().Add(entity);
        }

        public IQueryable<T> List()
        {
            return _db.Set<T>();
        }

        /// <summary>
        /// Generic query method
        /// </summary>
        public IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }

        public void Remove(T entity)
        {
            _db.Remove(entity);
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
            // throw new NotImplementedException();
        }

        /*
        // Can't do this here inside the generic repository,  because
        // the Generic Repository doesn't know if there is an Id
        public T Find(int id)
        {
            return _db.Set<T>().FirstOrDefault(t => t.Id == id);
        }
        */
    }
}
