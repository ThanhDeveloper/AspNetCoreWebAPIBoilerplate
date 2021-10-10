using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTemplate.Common.Exceptions;
using AspNetCoreTemplate.DAL.Interfaces.IRepository;
using AspNetCoreTemplate.Domain.Context;

namespace AspNetCoreTemplate.DAL.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        internal DatabaseContext _context;

        protected BaseRepository(DatabaseContext context) =>
            _context = context;

        public virtual async Task Add(TEntity obj)
        {
            await _context.AddAsync(obj);
        }

        public virtual IQueryable<TEntity> GetAll() => 
            _context.Set<TEntity>();

        public virtual async Task Delete(TEntity obj)
        { 
            _context.Set<TEntity>().Remove(obj);
        }

        public virtual async Task Delete(int id)
        {
            var obj = await _context.Set<TEntity>().FindAsync(id);
            if (obj == null) {
                throw new EntityNotFoundException("RESOURCE_NOT_FOUND");
            }
            _context.Set<TEntity>().Remove(obj);
        }

        public virtual async Task Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Dispose() =>
            _context.Dispose();
    }
}
