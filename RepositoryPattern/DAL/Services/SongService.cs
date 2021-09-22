using AutoMapper;
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

        public async Task<List<SongDto>> GetAll()
        {
            List<SongDto> songDtos = new List<SongDto>();
            IEnumerable<Song> songs =  await _songRepository.GetAll();
            foreach (var song in songs)
            {
                SongDto songDto = _mapper.Map<SongDto>(song);
                songDtos.Add(songDto);
            }
            return songDtos;
        }

        public async Task<Song> GetSongById(int id)
        {
            return await _songRepository.GetById(id);
        }

        public async Task UpdateSong(Song song)
        {
            await _songRepository.Update(song);
        }
    }
}
