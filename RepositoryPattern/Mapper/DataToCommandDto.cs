using AutoMapper;
using RepositoryPattern.DAL.Data;
using RepositoryPattern.Dtos.Song;

namespace RepositoryPattern.Mapper
{
    public class DataToCommandDto: Profile
    {
        //Data => Dto
        public DataToCommandDto()
        {
            //Song
            CreateMap<SongData, SongDto>();
        }
    }
}
