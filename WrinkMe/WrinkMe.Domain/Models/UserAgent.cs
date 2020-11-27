using System;
using System.Collections.Generic;
using System.Text;

namespace WrinkMe.Domain.Models
{
    public class UserAgent
    {
        //Private default contrustructor for EF Core
        private UserAgent()
        {
        }

        public UserAgent(OS os, Device device, Browser browser)
        {
            OS = os;
            Device = device;
            Browser = browser;
            RequestDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        public OS OS { get; set; }
        public Device Device { get; set; }
        public Browser Browser { get; set; }
        public int ShortUrlId { get; set; }
        public ShortUrl ShortUrl { get; set; }
        public DateTime RequestDate { get; set; }

        public override string ToString()
        {
            return $"{OS}; {Device}; {Browser}";
        }
    }
}
