using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using RepositoryPattern.DAL.DataServices;
using RepositoryPattern.DAL.Interfaces.IRepository;
using RepositoryPattern.DAL.Interfaces.IService;
using RepositoryPattern.DAL.Interfaces.IUnitOfWork;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Models;

namespace RepositoryPattern.DAL.Services
{
    public class SongService : ServiceMaster, ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            _songRepository = songRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<List<SongDataService>> GetAll()
        {
            List<SongDataService> songDataServices = new List<SongDataService>();
            IEnumerable<Song> songs = await _songRepository.GetAll();
            foreach (var song in songs)
            {
                SongDataService songDataService = Mapper.Map<SongDataService>(song);
                songDataServices.Add(songDataService);
            }
            return songDataServices;
        }

        public async Task<SongDataService> GetSongById(int id)
        {
            Song song = await _songRepository.GetById(id);
            SongDataService songDataService = Mapper.Map<SongDataService>(song);
            return songDataService;
        }

        public async Task AddSong(SongRequest dto)
        {
            Song song = Mapper.Map<Song>(dto);
            await _songRepository.Add(song);
            await UnitOfWork.CompleteAsync();
        }

        public async Task UpdateSong(Song song)
        {
            await _songRepository.Update(song);
            await UnitOfWork.CompleteAsync();
        }

        public async Task DeleteSong(int id)
        {
            await _songRepository.Delete(id);
            await UnitOfWork.CompleteAsync();
        }
    }
}
