using AutoMapper;
using RepositoryPattern.DAL.DataService;
using RepositoryPattern.DAL.Interfaces.UnitOfWork;
using RepositoryPattern.DAL.Services;
using RepositoryPattern.Data.UnitOfWork;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
using RepositoryPattern.Domain.Interfaces.IService;
using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Service
{
    public class SongService : ServiceMaster, ISongService
    {
        private readonly ISongRepository SongRepository;

        public SongService(ISongRepository songRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            SongRepository = songRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<List<SongDataService>> GetAll()
        {
            List<SongDataService> songDataServices = new List<SongDataService>();
            IEnumerable<Song> songs = await SongRepository.GetAll();
            foreach (var song in songs)
            {
                SongDataService songDataService = Mapper.Map<SongDataService>(song);
                songDataServices.Add(songDataService);
            }
            return songDataServices;
        }

        public async Task<SongDataService> GetSongById(int id)
        {
            Song song = await SongRepository.GetById(id);
            SongDataService songDataService = Mapper.Map<SongDataService>(song);
            return songDataService;
        }

        public async Task AddSong(SongRequest dto)
        {
            Song song = Mapper.Map<Song>(dto);
            await SongRepository.Add(song);
            await UnitOfWork.CompleteAsync();
        }

        public async Task UpdateSong(Song song)
        {
            await SongRepository.Update(song);
            await UnitOfWork.CompleteAsync();
        }

        public async Task DeleteSong(int id)
        {
            await SongRepository.Delete(id);
            await UnitOfWork.CompleteAsync();
        }
    }
}
