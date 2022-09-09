using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApp1.Models
{
    public class AppUsers : IdentityUser
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserDuty { get; set; }

    }
}
