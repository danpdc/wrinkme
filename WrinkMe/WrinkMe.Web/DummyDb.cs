using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrinkMe.Domain.Models;

namespace WrinkMe.Web
{
    public class DummyDb
    {
        public DummyDb()
        {
            ShortUrls = new List<ShortUrl>();
        }
        public List<ShortUrl> ShortUrls { get; set; }
    }
}
