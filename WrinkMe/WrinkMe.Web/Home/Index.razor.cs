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
        public int RequestsPerDay { get; set; }

        
        protected override async Task OnInitializedAsync()
        {
            ShortenedUrls = await DataContext.ShortUrls.CountAsync();
            RequestsPerDay = await DataContext.Requests
                .Where(r => r.RequestDate >= DateTime.UtcNow.AddHours(-24) && r.RequestDate <= DateTime.UtcNow)
                .CountAsync();
        }

        private void IncreaseShortUrlCount()
        {
            ShortenedUrls += 1;
        }
    }
}
