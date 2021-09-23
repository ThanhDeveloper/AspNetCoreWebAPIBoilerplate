using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Common.Exceptions;
using RepositoryPattern.Data.Context;
using RepositoryPattern.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal DatabaseContext Context;

        public BaseRepository(DatabaseContext context) =>
            Context = context;

        public virtual async Task Add(TEntity obj)
        {
            await Context.AddAsync(obj);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await Context.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetById(int? id) =>
            await Context.Set<TEntity>().FindAsync(id);


        public virtual async Task Delete(TEntity obj)
        {
            Context.Set<TEntity>().Remove(obj);
        }

        public virtual async Task Delete(int id)
        {
            var obj = await Context.Set<TEntity>().FindAsync(id);
            if (obj == null) {
                throw new EntityNotFoundException("RESOURCE_NOT_FOUND");
            }
            Context.Set<TEntity>().Remove(obj);
        }

        public virtual async Task Update(TEntity obj)
        {
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void Dispose() =>
            Context.Dispose();
    }
}
