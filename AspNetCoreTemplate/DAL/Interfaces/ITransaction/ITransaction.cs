using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace AspNetCoreTemplate.DAL.Interfaces.ITransaction
{
    public interface ITransaction
    {
        Task<IDbContextTransaction> BeginTransactionAsync(IsolationLevel isolation = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default(CancellationToken));
        Task CommitTransactionAsync(IDbContextTransaction transaction, CancellationToken cancellationToken = default(CancellationToken));
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}