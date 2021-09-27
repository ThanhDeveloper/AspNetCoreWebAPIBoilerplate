using AutoMapper;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Models;

namespace RepositoryPattern.Mapper
{
    public class DtoToCommandEntity : Profile
    {
        //Dto => Entity
        public DtoToCommandEntity()
        {
            //Song
            CreateMap< SongRequest, Song>();
        }
    }
}
