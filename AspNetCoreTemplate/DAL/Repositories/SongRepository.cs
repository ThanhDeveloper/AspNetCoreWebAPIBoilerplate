using System.Linq;
using AspNetCoreTemplate.Domain.Context;
using AspNetCoreTemplate.Domain.Entities;

namespace AspNetCoreTemplate.DAL.Repositories
{
    public class SongRepository : BaseRepository<Song>
    {
        public SongRepository(DatabaseContext context) : base(context){}
        
        public IQueryable<Song> GetById(int id) => _context.Set<Song>().Where(x => x.Id == id);
    }
}
