﻿using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogModels
{
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Title { get; set; }
        [StringLength(1000)]
        public string Content { get; set; }
        [Required]
        [StringLength(100)]
        public string? Category { get; set; }
        [Required]
        public int SubscriptionsAllowed { get; set; }
        public bool IsApproved { get; set; }
        public bool IsRejected { get; set; }

    }
}
