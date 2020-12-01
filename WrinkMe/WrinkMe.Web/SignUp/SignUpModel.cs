using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WrinkMe.Web.SignUp
{
    public class SignUpModel
    {
        [Required]
        [MinLength(6)]
        [MaxLength(20)]
        public string Username { get; set; }
        
        [Required]
        [MinLength(6)]
        [MaxLength(22)]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
