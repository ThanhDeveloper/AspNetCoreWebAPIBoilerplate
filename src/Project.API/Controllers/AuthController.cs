using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Core.DTOs;
using Project.Core.DTOs.Users;
using Project.Core.Services;

namespace Project.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public AuthController(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }
        
        // POST api/auth/register
        [HttpPost]
        [Route(("register"))]
        public async Task<IActionResult> Register([FromBody] UserCreateDto userCreateDto)
        {
            await _userService.Create(userCreateDto);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(201));
        }
        
        [HttpPost]
        [Route(("login"))]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var userLogged = await _userService.Authenticate(userLoginDto);
            return CreateActionResult(CustomResponseDto<UserLoggedDto>.Success(200, userLogged));
        }
    }
}