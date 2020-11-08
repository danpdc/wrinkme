using System;
using System.Collections.Generic;
using System.Text;
using WrinkMe.Domain.Models;

namespace WrinkMe.Domain.Interfaces
{
    public interface IUserAgentService
    {
        UserAgent ParseUserAgent(string userAgent);
    }
}
