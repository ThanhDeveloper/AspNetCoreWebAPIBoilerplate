using Microsoft.AspNetCore.Mvc;
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

        public SongsController( ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSong()
        {
            List<SongDto> songDtos = await _songService.GetAll();
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
