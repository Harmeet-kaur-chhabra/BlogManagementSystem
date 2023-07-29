using AutoMapper;
using BlogData.Repository.IRepository;
using BlogModels;
using BlogModels.Dto;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BlogModels.Dto;

namespace BlogData.Repository
{

    public class AuthRepository : IAuthRepository<Users>
    {
        private readonly ApplicationDbContext _db;
        public string secretKey;
        public AuthRepository(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;
            secretKey = configuration.GetValue<String>("ApiSettings:Secret");



        }
        public bool IsUniqueUser(string username)
        {
            var user = _db.Users.FirstOrDefault(x => x.Name == username);
            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.Users.FirstOrDefault(x => x.Name.ToLower() == loginRequestDto.UserName.ToLower() &&
            x.Password == loginRequestDto.Password);
            if (user == null)
            {


                return new LoginResponseDto()
                {
                    Token = "",
                    User = null
                };
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
                  new Claim(ClaimTypes.Name, user.Name.ToString()),
                  new Claim(ClaimTypes.Role, user.Role)


              }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(TokenDescriptor);
            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                Token = tokenHandler.WriteToken(token),
                User = user
            };



            return loginResponseDto;
        }

        public async Task<Users> Register(RegistrationRequestDto registrationRequestDto)
        {
            Users user = new()
            {
                Name = registrationRequestDto.UserName,
                Email = registrationRequestDto.Email,
                Password = registrationRequestDto.Password,
                Role = registrationRequestDto.Role
            };

            _db.Users.Add(user);
            await _db.SaveChangesAsync();
            user.Password = "";
            return user;
        }
    } }