using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BlogModels
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? Name { get; set; }
        [Column(TypeName = "varchar(20)")]
        public string? Email { get; set; }

        [Column(TypeName = "har(20)")]
        public string? Role { get; set; }
    }
}
