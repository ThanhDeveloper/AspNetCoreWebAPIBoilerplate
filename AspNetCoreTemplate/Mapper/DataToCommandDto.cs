using AspNetCoreTemplate.DAL.Data;
using AspNetCoreTemplate.Dtos.Song;
using AutoMapper;

namespace AspNetCoreTemplate.Mapper
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
