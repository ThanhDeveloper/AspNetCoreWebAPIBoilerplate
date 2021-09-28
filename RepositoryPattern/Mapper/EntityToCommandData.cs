using AutoMapper;
using RepositoryPattern.DAL.Data;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Mapper
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
