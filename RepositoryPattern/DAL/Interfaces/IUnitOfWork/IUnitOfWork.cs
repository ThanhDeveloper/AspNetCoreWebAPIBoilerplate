using System;
using System.Threading.Tasks;
using RepositoryPattern.DAL.Interfaces.IRepository;

namespace RepositoryPattern.DAL.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISongRepository SongRepository { get; }
        Task CompleteAsync();
    }
}
