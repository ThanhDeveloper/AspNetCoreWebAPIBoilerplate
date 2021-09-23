using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(int? id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task Delete(int id);
    }
}
