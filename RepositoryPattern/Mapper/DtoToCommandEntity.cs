using AutoMapper;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
