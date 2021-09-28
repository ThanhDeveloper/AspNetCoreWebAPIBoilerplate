using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.DAL.Data;
using RepositoryPattern.DAL.Interfaces.IRepository;
using RepositoryPattern.DAL.Interfaces.IService;
using RepositoryPattern.DAL.Interfaces.IUnitOfWork;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Dtos.Song;

namespace RepositoryPattern.DAL.Services
{
    public class SongService : BaseService, ISongService
    {
        private readonly ISongRepository _songRepository;

        public SongService(ISongRepository songRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            _songRepository = songRepository;
            UnitOfWork = unitOfWork;
        }

        public async Task<List<SongData>> GetAll()
        {
            return await Mapper.ProjectTo<SongData>(_songRepository.GetAll()).ToListAsync();
        }

        public async Task<SongData> GetSongById(int id)
        {
            return await Mapper.ProjectTo<SongData>(_songRepository.GetById(id)).FirstOrDefaultAsync();
        }

        public async Task AddSong(NewSongDto newSongDto)
        {
            Song song = Mapper.Map<Song>(newSongDto);
            await _songRepository.Add(song);
            await UnitOfWork.CompleteAsync();
        }

        public async Task UpdateSong(UpdateSongDto updateSongDto)
        {
            Song song = Mapper.Map<Song>(updateSongDto);
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
