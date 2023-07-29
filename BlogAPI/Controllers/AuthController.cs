using AutoMapper;
using BlogData.Repository.IRepository;
using BlogModels;
using BlogModels.Dto;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Auth;

namespace BlogMangementApi.Controllers
{
    [ApiController]
    [Route("/api/Auth")]
    public class AuthController : ControllerBase
    {

        private readonly IAuthRepository<Users> _authRepository;


        public AuthController(IAuthRepository<Users> authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await _authRepository.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                ModelState.AddModelError("Custom Error", "Name & password Invalid!!");
                return BadRequest(ModelState);

            }

            return Ok(loginResponse);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDto registrationRequestDTO)
        {
            bool ifUserNameUnique = _authRepository.IsUniqueUser(registrationRequestDTO.UserName);
            if (!ifUserNameUnique)
            {
                return BadRequest(new { message = "Username already exists" });
            }
            var user = await _authRepository.Register(registrationRequestDTO);
            if (user == null)
            {
                return BadRequest(new { message = "Error while registering" });
            }
            return Ok(registrationRequestDTO);
        }
    }
}
