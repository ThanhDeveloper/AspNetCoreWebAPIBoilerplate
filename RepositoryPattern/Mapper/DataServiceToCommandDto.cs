using AutoMapper;
using RepositoryPattern.DAL.DataService;
using RepositoryPattern.Dtos.Song;

namespace RepositoryPattern.Mapper
{
    public class DataServiceToCommandDto: Profile
    {
        //DataService => Dto
        public DataServiceToCommandDto()
        {
            //Song
            CreateMap<SongDataService, SongDto>();
        }
    }
}
