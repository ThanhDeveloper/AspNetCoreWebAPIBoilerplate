using RepositoryPattern.DAL.Interfaces.IRepository;
using RepositoryPattern.Domain.Context;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.DAL.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(DatabaseContext context) : base(context){}
    }
}
