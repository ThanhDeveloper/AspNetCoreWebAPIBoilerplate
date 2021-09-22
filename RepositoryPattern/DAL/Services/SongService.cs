using AutoMapper;
using RepositoryPattern.DAL.DataService;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Domain.Interfaces.IService;
using RepositoryPattern.Dtos.Song;
using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Service
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongService(ISongRepository songRepository, IMapper mapper)
        {
            _mapper = mapper;
            _songRepository = songRepository;
        }
        public async Task CreateSong(SongRequest dto)
        {
            Song song = _mapper.Map<Song>(dto);
            await _songRepository.Add(song);
        }

        public async Task RemoveSong(int id)
        {
            await _songRepository.Remove(id);
        }

        public async Task<List<SongDataService>> GetAll()
        {
            List<SongDataService> songDataServices = new List<SongDataService>();
            IEnumerable<Song> songs = await _songRepository.GetAll();
            foreach (var song in songs)
            {
                SongDataService songDataService = _mapper.Map<SongDataService>(song);
                songDataServices.Add(songDataService);
            }
            return songDataServices;
        }

        public async Task<SongDataService> GetSongById(int id)
        {
            Song song = await _songRepository.GetById(id);
            SongDataService songDataService = _mapper.Map<SongDataService>(song);
            return songDataService;
        }

        public async Task UpdateSong(Song song)
        {
            await _songRepository.Update(song);
        }
    }
}
