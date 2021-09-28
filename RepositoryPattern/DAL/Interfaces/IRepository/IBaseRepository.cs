using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL.Interfaces.IRepository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);
        IQueryable<TEntity> GetAll();
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task Delete(int id);
    }
}
