using BlogModels.Dto;
using BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Repository.IRepository
{
        public interface IAuthRepository<T>where T : class
        {
            bool IsUniqueUser(string username);
            Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
            Task<Users> Register(RegistrationRequestDto registrationRequestDto);
        }
    }