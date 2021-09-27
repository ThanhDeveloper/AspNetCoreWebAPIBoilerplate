using System.Collections.Generic;
using System.Threading.Tasks;
using RepositoryPattern.DAL.Data;
using RepositoryPattern.Dtos.Song;

namespace RepositoryPattern.DAL.Interfaces.IService
{
    public interface ISongService
    {
        Task<List<SongData>> GetAll();
        Task<SongData> GetSongById(int id);
        Task AddSong(NewSongDto dto);
        Task UpdateSong(UpdateSongDto song);
        Task DeleteSong(int id);
    }
}
