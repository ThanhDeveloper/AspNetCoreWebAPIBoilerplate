using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RepositoryPattern.DAL.Data;
using RepositoryPattern.DAL.Interfaces.IService;
using RepositoryPattern.Dtos;
using RepositoryPattern.Dtos.Song;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            List<SongData> songDatas = await _songService.GetAll();
            List<SongDto> songDtos = songDatas.Select(x => Mapper.Map<SongDto>(x)).ToList();
            return Ok(ApiResponse<object>.Success(songDtos));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSongById(int id)
        {
            SongData songData =  await _songService.GetSongById(id);
            SongDto songDto = Mapper.Map<SongDto>(songData);
            return Ok(ApiResponse<SongDto>.Success(songDto));
        }

        [HttpPost]
        public async Task<IActionResult> CreateSong(NewSongDto newSongDto)
        {
            await _songService.AddSong(newSongDto);
            return StatusCode(201);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSong(UpdateSongDto updateSongDto)
        {
            await _songService.UpdateSong(updateSongDto);
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
