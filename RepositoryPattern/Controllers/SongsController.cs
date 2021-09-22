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
    public class SongsController : ControllerBase
    { 
        private readonly ISongService _songService;
        private readonly IMapper _mapper;

        public SongsController( ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper; 
        }

        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            List<SongDto> songDtos = new List<SongDto>();
            List<SongDataService> songDataServices = await _songService.GetAll();
            foreach(SongDataService songDataService in songDataServices)
            {
                SongDto songDto = _mapper.Map<SongDto>(songDataService);
                songDtos.Add(songDto); 
            }
            return Ok(ApiResponse<List<SongDto>>.Success(songDtos));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(SongRequest dto)
        {
            await _songService.CreateSong(dto);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSong(Song song)
        {
            await _songService.UpdateSong(song);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            await _songService.RemoveSong(id);
            return NoContent();
        }
    }
}
