using System;
using System.Collections.Generic;
using System.Text;

namespace WrinkMe.Domain.Models
{
    public class OS
    {
        public string Family { get; set; }
        public string Major { get; set; }
        public string Minor { get; set; }

        public override string ToString()
        {
            return $"{Family} {Major}.{Minor}";
        }
    }
}
