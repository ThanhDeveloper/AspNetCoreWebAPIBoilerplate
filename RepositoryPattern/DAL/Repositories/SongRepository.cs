using System.Linq;
using RepositoryPattern.DAL.Interfaces.IRepository;
using RepositoryPattern.Domain.Context;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.DAL.Repositories
{
    public class SongRepository : BaseRepository<Song>, ISongRepository
    {
        public SongRepository(DatabaseContext context) : base(context){}
        
        public IQueryable<Song> GetById(int id) => _context.Set<Song>().Where(x => x.Id == id);
    }
}
