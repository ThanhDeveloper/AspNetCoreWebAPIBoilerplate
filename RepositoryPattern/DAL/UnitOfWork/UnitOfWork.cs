using RepositoryPattern.DAL.Interfaces.UnitOfWork;
using RepositoryPattern.Data.Context;
using RepositoryPattern.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext _context;
        public ISongRepository songRepository { get; }

        public UnitOfWork(DatabaseContext context,
            ISongRepository songRepo)
        {
            _context = context;
            songRepository = songRepo;
        }

        public async Task CompleteAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
