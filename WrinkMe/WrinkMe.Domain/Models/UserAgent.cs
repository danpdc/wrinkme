using System;
using System.Collections.Generic;
using System.Text;

namespace WrinkMe.Domain.Models
{
    public class UserAgent
    {
        public UserAgent()
        {
        }

        public UserAgent(OS os, Device device, Browser browser)
        {
            OS = os;
            Device = device;
            Browser = browser;
        }
        public OS OS { get; set; }
        public Device Device { get; set; }
        public Browser Browser { get; set; }

        public override string ToString()
        {
            return $"{OS.ToString()}; {Device.ToString()}; {Browser.ToString()}";
        }
    }
}
