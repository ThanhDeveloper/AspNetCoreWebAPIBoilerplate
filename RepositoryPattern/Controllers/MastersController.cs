﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace RepositoryPattern.Controllers
{
    [ApiController]
    public class MastersController : ControllerBase
    {
        public static IMapper Mapper;
    }
}