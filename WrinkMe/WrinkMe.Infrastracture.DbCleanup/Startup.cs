using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WrinkeMe.Dal;
using WrinkMe.Infrastracture.DbCleanup;

[assembly: FunctionsStartup(typeof(Startup))]
namespace WrinkMe.Infrastracture.DbCleanup
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var cs = Environment.GetEnvironmentVariable("Sql");
            builder.Services.AddDbContext<WrinkMeDataContext>(options => options.UseSqlServer(cs));
        }
    }
}
