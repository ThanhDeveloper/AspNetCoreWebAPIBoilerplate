using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTemplate.DAL.Data;
using AspNetCoreTemplate.DAL.Interfaces.IService;
using AspNetCoreTemplate.DAL.Interfaces.IUnitOfWork;
using AspNetCoreTemplate.Domain.Entities;
using AspNetCoreTemplate.Dtos.Song;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTemplate.DAL.Interfaces.IRepository;

namespace AspNetCoreTemplate.DAL.Services
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
