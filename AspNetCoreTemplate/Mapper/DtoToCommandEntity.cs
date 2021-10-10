using AspNetCoreTemplate.Domain.Entities;
using AspNetCoreTemplate.Dtos.Song;
using AutoMapper;

namespace AspNetCoreTemplate.Mapper
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
