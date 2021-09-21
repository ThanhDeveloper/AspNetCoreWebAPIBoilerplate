using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.Interfaces
{
    public interface ISongRepository: IRepositoryBase<Song>
    {
        Task<IEnumerable<Song>> FindBooksByAuthor(string author);
        Task<Song> GetByName(string name);
        Task CreateSong(SongRequest dto);
    }
}
