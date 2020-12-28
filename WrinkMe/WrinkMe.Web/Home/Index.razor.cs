using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrinkeMe.Dal;

namespace WrinkMe.Web.Home
{
    public partial class Index
    {
        [Inject] public IDbContextFactory<WrinkMeDataContext> DataContextFactory { get; set; }
        public int ShortenedUrls { get; set; }
        public int RequestsPerDay { get; set; }
        public int RegisteredUsers { get; set; }

        
        protected override async Task OnInitializedAsync()
        {
            using (var ctx = DataContextFactory.CreateDbContext())
            {
                ShortenedUrls = await ctx.ShortUrls.CountAsync();
                RequestsPerDay = await ctx.Requests
                    .Where(r => r.RequestDate >= DateTime.UtcNow.AddHours(-24) && r.RequestDate <= DateTime.UtcNow)
                    .CountAsync();
                RegisteredUsers = await ctx.Users.CountAsync();
            }
        }

        private void IncreaseShortUrlCount()
        {
            ShortenedUrls += 1;
        }
    }
}
