using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Domain.Interfaces;
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
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;

        public SongsController(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSong()
        {
            var songs = await _songRepository.GetAll();
            return Ok(ApiResponse<IEnumerable<object>>.Success(songs));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(SongRequest dto)
        {
            await _songRepository.CreateSong(dto);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSong(Song song)
        {
            await _songRepository.Update(song);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSong(int id)
        {
            await _songRepository.Remove(id);
            return NoContent();
        }
    }
}
