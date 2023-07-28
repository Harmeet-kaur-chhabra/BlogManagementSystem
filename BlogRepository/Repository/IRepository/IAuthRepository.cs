using BlogModels.Dto;
using BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repository.IRepository
{
    public interface IAuthRepository : IRepository<Users>
    {
        bool IsUniqueUser(string username);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDTO);
        Task<Users> Register(RegistrationRequestDto registrationRequestDto);
        Task<Users> UpdateAsync(Users entity);
    }
}
