using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WrinkMe.Web.Home
{
    public class Url
    {
        [Required]
        public string Value { get; set; }
    }
}
