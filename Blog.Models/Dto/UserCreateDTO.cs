﻿using System.ComponentModel.DataAnnotations;

namespace BlogModels.Dto
{
    public class UserCreateDTO
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
