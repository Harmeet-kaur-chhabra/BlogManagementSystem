using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModels.Dto
{
    public class BlogDto
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        
        public string Category { get; set; }
        public int SubscriptionsAllowed { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }
    }
}
