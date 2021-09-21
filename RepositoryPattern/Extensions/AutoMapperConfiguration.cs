using AutoMapper;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Dtos.Song;

namespace RepositoryPattern.Extensions
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            //Song
            CreateMap<Song, SongDto>();
        }
    }
}
