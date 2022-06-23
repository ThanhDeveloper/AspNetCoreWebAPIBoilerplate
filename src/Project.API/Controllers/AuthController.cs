using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.Core.DTOs;
using Project.Core.DTOs.Users;
using Project.Core.Services;
using Project.Data.UnitOfWorks;

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
            await _authService.Register(userRegisterDto);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(StatusCodes.Status201Created));
        }

        // POST api/auth/login
        [HttpPost]
        [Route(("login"))]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            var userLogged = await _authService.Authenticate(userLoginDto);

            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                SameSite = SameSiteMode.None,
                Secure = true
            };

            Response.Cookies.Append("X-Access-Token", userLogged.AccessToken, cookieOptions);
            Response.Cookies.Append("X-Refresh-Token", userLogged.RefreshToken, cookieOptions);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK));
        }

        // POST api/auth/logout
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("logout")]
        public Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("X-Access-Token");
            Response.Cookies.Delete("X-Refresh-Token");
            return Task.FromResult(CreateActionResult(CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK)));
        }

        [HttpGet("refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["X-Refresh-Token"];
            if (refreshToken != null)
            {
                var isExpires = _authService.CheckExpires(refreshToken);
                if (isExpires)
                {
                    Response.Cookies.Delete("X-Access-Token");
                    Response.Cookies.Delete("X-Refresh-Token");
                    return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status401Unauthorized, "Token expires"));
                }
                var token = new JwtSecurityToken(refreshToken);
                var userId = Int32.Parse(token.Claims.First(x => x.Type == ClaimTypes.Name).Value);
                var tokenLst = await _authService.RefreshToken(userId);
            
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.None,
                    Secure = true
                };

                Response.Cookies.Append("X-Access-Token", tokenLst["AccessToken"], cookieOptions);
                Response.Cookies.Append("X-Refresh-Token", tokenLst["RefreshToken"], cookieOptions);

                return CreateActionResult(CustomResponseDto<NoContentDto>.Success(StatusCodes.Status200OK));
            }
            return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(StatusCodes.Status401Unauthorized, "Token expires"));
        }
    }
}