using RepositoryPattern.Data.Context;
using RepositoryPattern.Data.Repositories;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;

namespace RepositoryPattern.Repositories
{
    public class SongRepository : RepositoryBase<Song>, ISongRepository
    {
        public SongRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
