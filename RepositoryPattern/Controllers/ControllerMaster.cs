using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    public class ControllerMaster : ControllerBase
    {
        public static IMapper Mapper;
    }
}
