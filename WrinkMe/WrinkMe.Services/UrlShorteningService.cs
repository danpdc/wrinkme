using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using WrinkMe.Domain.Interfaces;
using WrinkMe.Domain.Models;

namespace WrinkMe.Services
{
    public class UrlShorteningService : IUrlShorteningService
    {
        public ShortUrl QuickShort(Uri url)
        {
            var shortUrl = new ShortUrl();
            shortUrl.OriginalUrl = url;
            shortUrl.DateCreated = DateTime.UtcNow;
            shortUrl.Token = GenerateToken();
            shortUrl.Value = new Uri($"http://wrink.me/{shortUrl.Token}");
            return shortUrl;
        }

        private string GenerateToken()
        {
            string random = string.Empty;
            Enumerable.Range(48, 75)
                .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
                .OrderBy(o => new Random().Next())
                .ToList()
                .ForEach(i => random += Convert.ToChar(i));
            return random.Substring(new Random().Next(0, random.Length - 8), 8);
        }
    }
}
