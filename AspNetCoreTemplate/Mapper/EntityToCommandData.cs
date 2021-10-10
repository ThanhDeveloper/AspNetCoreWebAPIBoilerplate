using AspNetCoreTemplate.DAL.Data;
using AspNetCoreTemplate.Domain.Entities;
using AutoMapper;

namespace AspNetCoreTemplate.Mapper
{
    public class EntityToCommandData : Profile
    {
        //Entity => Data
        public EntityToCommandData()
        {
            //Song
            CreateMap<Song, SongData>();
        }
    }
}
