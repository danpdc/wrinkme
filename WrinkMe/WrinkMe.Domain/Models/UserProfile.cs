using System;
using System.Collections.Generic;
using System.Text;

namespace WrinkMe.Domain.Models
{
    public class UserProfile
    {
        public int UserProfileId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<ShortUrl> Wrinks { get; set; }

        public static UserProfile CreateUserProfile(User user)
        {
            return new UserProfile { UserId = user.UserId };
        }
    }
}
