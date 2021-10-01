using RepositoryPattern.DAL.Repositories;
using System;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        SongRepository SongRepository { get; }
        Task CompleteAsync();
    }
}
