using System;
using System.Collections.Generic;
using System.Text;

namespace WrinkMe.Domain.Models
{
    public class User
    {
        public User()
        {
            IsVerified = true;
        }
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public bool IsVerified { get; set; }
    }
}
