using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
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
        [Inject] public WrinkMeDataContext DataContext { get; set; }
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
            DataContext.ShortUrls.Add(shortUrl);
            await DataContext.SaveChangesAsync();
            Url.Value = shortUrl.Value.ToString();
            await OnShortenedUrl.InvokeAsync(1);
        }
    }
}
