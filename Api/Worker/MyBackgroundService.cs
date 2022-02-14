using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.DataContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Api.Worker
{
    public class MyBackgroundService : BackgroundService
    {
        public readonly IServiceScopeFactory ScopeFactory;
        public MyBackgroundService(IServiceScopeFactory scopeFactory)
        {
            ScopeFactory = scopeFactory;
        }
        
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = ScopeFactory.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<WorkerDataContext>();
                    foreach(var pageUrl in db.PageUrls.Where(t=>!t.IsActive == true && t.UrlAddress !=null ))
                    {
                        Console.WriteLine(pageUrl.UrlAddress);
                        pageUrl.IsActive = true;
                    }
                    
                }
                await Task.Delay(TimeSpan.FromMinutes(5));
            }
        }
    }
}