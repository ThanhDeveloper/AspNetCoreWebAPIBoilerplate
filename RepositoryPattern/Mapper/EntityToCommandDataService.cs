using AutoMapper;
using RepositoryPattern.Models;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.DAL.DataService;

namespace RepositoryPattern.Mapper
{
    public class EntityToCommandDataService : Profile
    {
        //Entity => DataService
        public EntityToCommandDataService()
        {
            //Song
            CreateMap<Song, SongDataService>();
        }
    }
}
