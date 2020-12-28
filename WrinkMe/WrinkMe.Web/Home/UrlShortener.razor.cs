using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrinkeMe.Dal;
using WrinkMe.Domain.Interfaces;

namespace WrinkMe.Web.Home
{
    public partial class UrlShortener
    {

        [Inject] public IUrlShorteningService ShorteningService { get; set; }
        [Inject] public IDbContextFactory<WrinkMeDataContext> DataContextFactory { get; set; }
        [Parameter] public EventCallback<int> OnShortenedUrl { get; set; }
        private Url Url { get; set; }
        protected override Task OnInitializedAsync()
        {
            Url = new Url();
            return base.OnInitializedAsync();
        }

        private async void ShortenUrl()
        {
            var url = new Uri(Url.Value);
            var shortUrl = ShorteningService.QuickShort(url);

            using (var ctx = DataContextFactory.CreateDbContext())
            {
                ctx.ShortUrls.Add(shortUrl);
                await ctx.SaveChangesAsync();
            }

            Url.Value = shortUrl.Value.ToString();
            await OnShortenedUrl.InvokeAsync(1);
        }
    }
}
