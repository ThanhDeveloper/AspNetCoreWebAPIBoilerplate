using AspNetCoreTemplate.DAL.Interfaces.IRepository;
using System;
using System.Threading.Tasks;
using AspNetCoreTemplate.DAL.Interfaces.IUnitOfWork;
using AspNetCoreTemplate.DAL.Repositories;
using AspNetCoreTemplate.Domain.Context;

namespace AspNetCoreTemplate.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;
        private SongRepository _songRepository;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        public SongRepository SongRepository
        {
            get
            {
                if (_songRepository == null)
                {
                    _songRepository = new SongRepository(_context);
                }
                return _songRepository;
            }
        }

        /*public ExampleRepository ExampleRepository
        {
            get
            {
                if (_exampleRepository == null)
                {
                    _exampleRepository = new ExampleRepository(_context);
                }
                return _exampleRepository;
            }
        }*/

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
