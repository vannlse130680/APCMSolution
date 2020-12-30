using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APCMSolution.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class

    {
        DbSet<TEntity> GetAll();
        IQueryable<TEntity> FindAll(Func<TEntity, bool> predicate);
        TEntity Find(Func<TEntity, bool> predicate);
        TEntity GetById(Guid Id);
        void Insert(TEntity entity);
        void Update(TEntity entity, Guid Id);
        void UpdateRange(IQueryable<TEntity> entities);
        void HardDelete(Guid key);
        void DeleteRange(IQueryable<TEntity> entities);
        void InsertRange(IQueryable<TEntity> entities);
    }
}
