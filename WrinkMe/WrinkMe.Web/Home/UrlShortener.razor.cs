using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrinkMe.Domain.Interfaces;

namespace WrinkMe.Web.Home
{
    public partial class UrlShortener
    {

        [Inject] public IUrlShorteningService ShorteningService { get; set; }
        [Inject] public DummyDb DummyDb { get; set; }
        private Url Url { get; set; }
        protected override Task OnInitializedAsync()
        {
            Url = new Url();
            return base.OnInitializedAsync();
        }

        private void ShortenUrl()
        {
            var url = new Uri(Url.Value);
            var shortUrl = ShorteningService.QuickShort(url);
            DummyDb.ShortUrls.Add(shortUrl);
            Url.Value = shortUrl.Value.ToString();
        }
    }
}
