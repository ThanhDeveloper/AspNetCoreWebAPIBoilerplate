using AutoMapper;
using RepositoryPattern.DAL.Data;
using RepositoryPattern.Domain.Entities;

namespace RepositoryPattern.Mapper
{
    public class EntityToCommandDataService : Profile
    {
        //Entity => DataService
        public EntityToCommandDataService()
        {
            //Song
            CreateMap<Song, SongData>();
        }
    }
}
