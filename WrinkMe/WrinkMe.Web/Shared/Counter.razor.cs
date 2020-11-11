using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WrinkMe.Web.Shared
{
    public partial class Counter
    {
        [Parameter] public int Count { get; set; }
        [Parameter] public string Text { get; set; }
    }
}
