using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTemplate.DAL.Data;
using AspNetCoreTemplate.Dtos.Song;

namespace AspNetCoreTemplate.DAL.Interfaces.IService
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
