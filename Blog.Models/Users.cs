using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModels
{
    public class Users
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public String Name { get; set; }
        [Required]
        [StringLength(100)]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Role { get; set; }
        
    }
}
