using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Dtos.Song;
using RepositoryPattern.Helpers;
using RepositoryPattern.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.DAL.DataServices;
using RepositoryPattern.DAL.Interfaces.IService;

namespace RepositoryPattern.Controllers
{
    [Route("api/songs")]
    [ApiController]
    public class SongsController : MastersController
    { 
        private readonly ISongService _songService;
        private readonly IConfiguration _configuration;

        public SongsController( ISongService songService, IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            _songService = songService;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetSongs()
        {
            List<SongDto> songDtos = new List<SongDto>();
            List<SongDataService> songDataServices = await _songService.GetAll();
            foreach(SongDataService songDataService in songDataServices)
            {
                SongDto songDto = Mapper.Map<SongDto>(songDataService);
                songDtos.Add(songDto); 
            }
            return Ok(ApiResponse<List<SongDto>>.Success(songDtos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSongById(int id)
        {
            SongDataService songDataService =  await _songService.GetSongById(id);
            SongDto songDto = Mapper.Map<SongDto>(songDataService);
            return Ok(ApiResponse<SongDto>.Success(songDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(SongRequest dto)
        {
            await _songService.AddSong(dto);
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
            await _songService.DeleteSong(id);
            return NoContent();
        }

        //Authorize 
        /*[HttpGet("me")]
        public async Task<IActionResult> GetSong(int id)
        {
            await SongService.GetSongById(ClaimsPrincipalExtensions.GetLoggedInUserId<int>(User));
            return NoContent();
        }*/
    }
}
