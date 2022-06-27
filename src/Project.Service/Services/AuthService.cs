using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
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
using Project.Service.Common.Exceptions;

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
        var userExist = await _userService.GetUserByUserName(userRegisterDto.UserName.ToLower());
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
        User user = await _userService.GetUserByUserName(userLoginDto.UserName.ToLower());
        if (Cryptography.VerifyPassword(userLoginDto.Password, user.StoredSalt, user.Password))
        {
            UserLoggedDto userLoggedDto = _mapper.Map<UserLoggedDto>(user);
            userLoggedDto.AccessToken = GenerateToken(user, double.Parse(_configuration["Jwt:ExpireAccessToken"]));
            userLoggedDto.RefreshToken = GenerateToken(user, double.Parse(_configuration["Jwt:ExpireRefreshToken"]));
            return userLoggedDto;
        }
        throw new AuthenticationException("Incorrect username or password");
    }
    
    public async Task<Dictionary<string, string>> RefreshToken(int userId)
    {
        User user = await _userService.GetByIdAsync(userId);
        var tokenLst = new Dictionary<string, string>(){
            {"AccessToken", GenerateToken(user, double.Parse(_configuration["Jwt:ExpireAccessToken"]))},
            {"RefreshToken", GenerateToken(user, double.Parse(_configuration["Jwt:ExpireRefreshToken"]))},
        };
        return tokenLst;
    }

    private string GenerateToken(User user, double expireToken)
    {
        //create claims details based on the user information
        var claims = new[] {
            new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
            new Claim(Constants.ClaimTypeUserId, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
            _configuration["Jwt:Audience"],
            claims,
            expires: DateTime.UtcNow.AddMinutes(expireToken),
            signingCredentials: signingCredentials);
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public bool CheckExpires(string refreshToken)
    {
        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        var token = new JwtSecurityToken(jwtEncodedString: refreshToken);
        if (token.Payload.Exp < unixTimestamp)
        {
            return true;
        }
        return false;
    }
}
