using System;
using System.Collections.Generic;
using System.Text;
using UAParser;
using WrinkMe.Domain.Interfaces;
using WrinkMe.Domain.Models;
using UserAgent = WrinkMe.Domain.Models.UserAgent;
using Device = WrinkMe.Domain.Models.Device;
using OS = WrinkMe.Domain.Models.OS;

namespace WrinkMe.Services
{
    public class UserAgentService : IUserAgentService
    {
        public UserAgent ParseUserAgent(string userAgent)
        {
            var uaParser = Parser.GetDefault();
            ClientInfo c = uaParser.Parse(userAgent);
            var os = new OS
            {
                Family = c.OS.Family,
                Major = c.OS.Major,
                Minor = c.OS.Minor,
            };

            var device = new Device
            {
                IsBot = c.Device.IsSpider,
                Brand = c.Device.Brand,
                Family = c.Device.Family,
                Model = c.Device.Model
            };

            var browser = new Browser
            {
                Family = c.UA.Family,
                Major = c.UA.Major,
                Minor = c.UA.Minor
            };
            return new UserAgent(os, device, browser);
        }
    }
}
