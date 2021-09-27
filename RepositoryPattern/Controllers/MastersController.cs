using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    public class MastersController : ControllerBase
    {
        protected static IMapper Mapper;
    }
}
