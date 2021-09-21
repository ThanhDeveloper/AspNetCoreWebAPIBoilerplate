using AutoMapper;
using RepositoryPattern.Models;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Mapper
{
    public class EntityToCommandSong : Profile
    {
        public EntityToCommandSong()
        {
            //Song
            CreateMap<SongRequest, Song>();
            CreateMap<Song, SongRequest>();
        }
    }
}
