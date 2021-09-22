using RepositoryPattern.DAL.DataService;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Dtos.Song;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Domain.Interfaces.IService
{
    public interface ISongService
    {
        Task<List<SongDataService>> GetAll();
        Task<SongDataService> GetSongById(int id);
        Task CreateSong(SongRequest dto);
        Task UpdateSong(Song song);
        Task RemoveSong(int id);
    }
}
