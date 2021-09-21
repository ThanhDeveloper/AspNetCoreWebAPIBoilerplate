using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Data.Context;
using RepositoryPattern.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DatabaseContext db;

        public RepositoryBase(DatabaseContext context) =>
            db = context;

        public virtual async Task Add(TEntity obj)
        {
            db.Add(obj);
            await db.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await db.Set<TEntity>().ToListAsync();

        public virtual async Task<TEntity> GetById(int? id) =>
            await db.Set<TEntity>().FindAsync(id);


        public virtual async Task Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            await db.SaveChangesAsync();
        }

        public virtual async Task Remove(int id)
        {
            var obj = await db.Set<TEntity>().FindAsync(id);
            db.Set<TEntity>().Remove(obj);
            await db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public void Dispose() =>
            db.Dispose();
    }
}
