using APCMSolution.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APCMSolution.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        
            public IRepository<T> Repository<T>()
              where T : class;

            int Commit();
             void Dispose();

            Task<int> CommitAsync();
        
    }
}
