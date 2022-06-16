using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Project.Core.DTOs.Users;
using Project.Core.Entities;
using Project.Core.Services;
using Project.Service.Common;
using Project.Service.Common.Security;

namespace Project.Service.Services;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    
    public AuthService(IUserService userService,  IMapper mapper, IConfiguration configuration)
    {
        _userService = userService;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task Register(UserRegisterDto userRegisterDto)
    {
        var userExist = await _userService.GetByUserName(userRegisterDto.UserName.ToLower());
        if (userExist != null)
        {
            throw new ArgumentException($"{userRegisterDto.UserName} already exists");
        }
        var hashSalt  = Cryptography.EncryptPassword(userRegisterDto.Password);
        User user = _mapper.Map<User>(userRegisterDto);
        user.UserName = user.UserName.ToLower();
        user.Password = hashSalt.Hash;
        user.StoredSalt = hashSalt.Salt;
        user.Role = Constants.RoleGuest;
        await _userService.AddAsync(user);
    }

    public async Task<UserLoggedDto> Authenticate(UserLoginDto userLoginDto)
    {
        User user = await _userService.GetByUserName(userLoginDto.UserName.ToLower());
        if (user != null && Cryptography.VerifyPassword(userLoginDto.Password, user.StoredSalt, user.Password))
        {
            UserLoggedDto userLoginData = _mapper.Map<UserLoggedDto>(user); 
            //create claims details based on the user information
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(0.0416666667),
                signingCredentials: signingCredentials);

            userLoginData.Token = new JwtSecurityTokenHandler().WriteToken(token);
            return userLoginData;
        }

        return new UserLoggedDto();
    }
}
