using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? Name { get; set; }
       public string? Email { get; set; }
      
        public string? Role { get; set; }
    }
}
