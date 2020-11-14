using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrinkeMe.Dal;

namespace WrinkMe.Web.Home
{
    public partial class Index
    {
        [Inject] public WrinkMeDataContext DataContext { get; set; }
        public int ShortenedUrls { get; set; }

        
        protected override async Task OnInitializedAsync()
        {
            ShortenedUrls = await DataContext.ShortUrls.CountAsync();
        }

        private void IncreaseShortUrlCount()
        {
            ShortenedUrls += 1;
        }
    }
}
