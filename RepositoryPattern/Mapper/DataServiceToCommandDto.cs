using AutoMapper;
using RepositoryPattern.DAL.Data;
using RepositoryPattern.Dtos.Song;

namespace RepositoryPattern.Mapper
{
    public class DataServiceToCommandDto: Profile
    {
        //DataService => Dto
        public DataServiceToCommandDto()
        {
            //Song
            CreateMap<SongData, SongDto>();
        }
    }
}
