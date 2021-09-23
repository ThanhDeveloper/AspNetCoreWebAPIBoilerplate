using RepositoryPattern.DAL.Interfaces.UnitOfWork;
using RepositoryPattern.Data.Context;
using RepositoryPattern.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace RepositoryPattern.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DatabaseContext Context;
        public ISongRepository SongRepository { get; }

        public UnitOfWork(DatabaseContext context,
            ISongRepository songRepo)
        {
            Context = context;
            SongRepository = songRepo;
        }

        public async Task CompleteAsync()
        {
           await Context.SaveChangesAsync();
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
                Context.Dispose();
            }
        }
    }
}
