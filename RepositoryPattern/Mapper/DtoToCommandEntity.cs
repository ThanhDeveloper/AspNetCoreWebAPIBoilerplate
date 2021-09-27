using AutoMapper;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Dtos.Song;

namespace RepositoryPattern.Mapper
{
    public class DtoToCommandEntity : Profile
    {
        //Dto => Entity
        public DtoToCommandEntity()
        {
            //Song
            CreateMap< NewSongDto, Song>();
            CreateMap< UpdateSongDto, Song>();
        }
    }
}
