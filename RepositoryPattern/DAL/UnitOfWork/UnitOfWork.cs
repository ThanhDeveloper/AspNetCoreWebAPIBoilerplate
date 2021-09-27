using System;
using System.Threading.Tasks;
using RepositoryPattern.DAL.Interfaces.IRepository;
using RepositoryPattern.DAL.Interfaces.IUnitOfWork;
using RepositoryPattern.Domain.Context;

namespace RepositoryPattern.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        public ISongRepository SongRepository { get; }

        public UnitOfWork(DatabaseContext context,
            ISongRepository songRepo)
        {
            _context = context;
            SongRepository = songRepo;
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

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
