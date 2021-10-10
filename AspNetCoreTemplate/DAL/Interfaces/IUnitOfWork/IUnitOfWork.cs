using System;
using System.Threading.Tasks;
using AspNetCoreTemplate.DAL.Repositories;

namespace AspNetCoreTemplate.DAL.Interfaces.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        SongRepository SongRepository { get; }
        Task CompleteAsync();
    }
}
