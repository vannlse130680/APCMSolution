using APCMSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APCMSolution.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private static CapstoneProjectContext _Context;
        public static DbSet<T> _table { get; set; }
        public Repository(CapstoneProjectContext context)
        {
            _Context = context;
            _table = _Context.Set<T>();
        }
        public T Find(Func<T, bool> predicate)
        {
            return _table.FirstOrDefault(predicate);
        }

        public IQueryable<T> FindAll(Func<T, bool> predicate)
        {
            return _table.Where(predicate).AsQueryable();

        }

        public DbSet<T> GetAll()
        {
            return _table;
        }

        public T GetById(Guid Id)
        {
            return _table.Find(Id);
        }

        public void HardDelete(Guid key)
        {
            _table.Remove(GetById(key));
        }

        public void Insert(T entity)
        {
            _table.Add(entity);
        }


        public void Update(T entity, Guid Id)
        {
            var existEntity = GetById(Id);
            _Context.Entry(existEntity).CurrentValues.SetValues(entity);
            _table.Update(existEntity);
        }

        public void UpdateRange(IQueryable<T> entities)
        {
            _table.UpdateRange(entities);
        }

        public void DeleteRange(IQueryable<T> entities)
        {
            _table.RemoveRange(entities);
        }

        public void InsertRange(IQueryable<T> entities)
        {
            _table.AddRange(entities);
        }
    }
}
