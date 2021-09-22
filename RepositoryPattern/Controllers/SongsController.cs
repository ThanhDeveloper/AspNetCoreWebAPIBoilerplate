using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.DAL.DataService;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces.IService;
using RepositoryPattern.Dtos.Song;
using RepositoryPattern.Helpers;
using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    [Route("api/songs")]
    [ApiController]
    public class SongsController : ControllerMaster
    { 
        private readonly ISongService SongService;

        public SongsController( ISongService songService, IMapper mapper)
        {
            SongService = songService;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            List<SongDto> songDtos = new List<SongDto>();
            List<SongDataService> songDataServices = await SongService.GetAll();
            foreach(SongDataService songDataService in songDataServices)
            {
                SongDto songDto = Mapper.Map<SongDto>(songDataService);
                songDtos.Add(songDto); 
            }
            return Ok(ApiResponse<List<SongDto>>.Success(songDtos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSongByID(int id)
        {
            SongDataService songDataService =  await SongService.GetSongById(id);
            SongDto songDto = Mapper.Map<SongDto>(songDataService);
            return Ok(ApiResponse<SongDto>.Success(songDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(SongRequest dto)
        {
            await SongService.AddSong(dto);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSong(Song song)
        {
            await SongService.UpdateSong(song);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            await SongService.DeleteSong(id);
            return NoContent();
        }
    }
}
