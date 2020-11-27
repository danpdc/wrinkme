using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WrinkeMe.Dal;

namespace WrinkMe.Infrastracture.DbCleanup
{
    public class DbCleaner
    {
        private readonly WrinkMeDataContext _ctx;

        public DbCleaner(WrinkMeDataContext ctx)
        {
            _ctx = ctx;
        }

        [FunctionName("DbCleaner")]
        public async Task Run([TimerTrigger("0 1 * * * ")]TimerInfo myTimer, ILogger log)
        {
            var requestNumber = await _ctx.Requests
                .Where(r => r.Device.IsBot == true).CountAsync();
            var totalRequest = await _ctx.Requests.CountAsync();
            var requests = await _ctx.Requests
                .Where(r => r.Device.IsBot == true).ToArrayAsync();
            _ctx.Requests.RemoveRange(requests);
            await _ctx.SaveChangesAsync();

            log.LogInformation($"Deleted {requestNumber} requests at {DateTime.UtcNow}");
            log.LogInformation($"{requestNumber * 100 / totalRequest}% of requests were bots");
        }
    }
}
