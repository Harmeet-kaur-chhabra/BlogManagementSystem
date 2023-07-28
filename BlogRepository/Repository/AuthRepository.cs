/*using AutoMapper;
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

namespace BlogData.Repository
{
    public class AuthRepository : Repository<Users>, IAuthRepository
    {
        private readonly ApplicationDbContext _db;

        private readonly IMapper _mapper;
        private string secretKey;
        public AuthRepository(ApplicationDbContext db, IMapper mapper, IConfiguration configuration) : base(db)
        {
            _db = db;
            _mapper = mapper;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");
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

        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestdto)
        {
            var user = _db.Users.FirstOrDefault(u => u.Name.ToLower() == loginRequestDto.UserName.ToLower()
            && u.Password == loginRequestdto.Password);
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

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDto loginResponseDTO = new LoginResponseDto()
            {
                Token = tokenHandler.WriteToken(token),

                User = _mapper.Map<Users>(user),

            };
            return loginResponseDTO;
        }

        public Task<Users> Register(RegistrationRequestDto registrationRequestDTO)
        {
            Users users = new()
            {
                Name = registrationRequestDTO.UserName,
                Password = registrationRequestDTO.Password,
                Email = registrationRequestDTO.Email,
                Role = registrationRequestDTO.Role
            };
            _db.Users.Add(users);
            await _db.SaveChangesAsync();
            users.Password = "";
            return users;
        }

        public Task<Users> UpdateAsync(Users entity)
        {
            _db.Users.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
*/