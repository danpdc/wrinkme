using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace WrinkMe.Domain.Models
{
    public class ShortUrl
    {
        public PathString OriginalUrl { get; set; }
        public PathString Value { get; set; }
        public string Token { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
