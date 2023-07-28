using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModels.Dto
{
    public class LoginResponseDto
    {
        public Users User { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
