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
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        // POST api/auth/register
        [HttpPost]
        [Route(("register"))]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userRegisterDto)
        {
            return Ok();
            await _authService.Register(userRegisterDto);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(201));
        }
        
        // POST api/auth/login
        [HttpPost]
        [Route(("login"))]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var userLogged = await _authService.Authenticate(userLoginDto);
            return CreateActionResult(CustomResponseDto<UserLoggedDto>.Success(200, userLogged));
        }
    }
}