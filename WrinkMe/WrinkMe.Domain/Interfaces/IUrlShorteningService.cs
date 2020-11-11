using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using WrinkMe.Domain.Models;

namespace WrinkMe.Domain.Interfaces
{
    public interface IUrlShorteningService
    {
        ShortUrl QuickShort(Uri url);
    }
}
