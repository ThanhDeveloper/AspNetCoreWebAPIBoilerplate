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
        public SongService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            Mapper = mapper;
            UnitOfWork = unitOfWork;
        }

        public async Task<List<SongData>> GetAll()
        {
            return await Mapper.ProjectTo<SongData>(UnitOfWork.SongRepository.GetAll()).ToListAsync();
        }

        public async Task<SongData> GetSongById(int id)
        {
            return await Mapper.ProjectTo<SongData>(UnitOfWork.SongRepository.GetById(id)).FirstOrDefaultAsync();
        }

        public async Task AddSong(NewSongDto newSongDto)
        {
            Song song = Mapper.Map<Song>(newSongDto);
            await UnitOfWork.SongRepository.Add(song);
            await UnitOfWork.CompleteAsync();
        }

        public async Task UpdateSong(UpdateSongDto updateSongDto)
        {
            Song song = Mapper.Map<Song>(updateSongDto);
            await UnitOfWork.SongRepository.Update(song);
            await UnitOfWork.CompleteAsync();
        }

        public async Task DeleteSong(int id)
        {
            await UnitOfWork.SongRepository.Delete(id);
            await UnitOfWork.CompleteAsync();
        }
    }
}
