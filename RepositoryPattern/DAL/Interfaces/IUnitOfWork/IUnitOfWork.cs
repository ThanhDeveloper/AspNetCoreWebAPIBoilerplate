using RepositoryPattern.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISongRepository SongRepository { get; }
        Task CompleteAsync();
    }
}
