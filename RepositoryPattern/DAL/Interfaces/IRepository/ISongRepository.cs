using System.Linq;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.DAL.Interfaces.IRepository
{
    public interface ISongRepository: IBaseRepository<Song>
    {
        IQueryable<Song> GetById(int id) ;
    }
}
