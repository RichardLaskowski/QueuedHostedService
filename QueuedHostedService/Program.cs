using Demo.App.Generic;
using Demo.App.Generic.HostedService.Classes;
using Demo.App.Generic.Queue.Classes;
using Demo.App.Generic.Queue.Interfaces;
using Demo.App.Generic.Repository;
using Demo.App.Generic.Service;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Demo.App;

public class Program
{
    public static void Main(string[] args)
    {
        IHostBuilder builder = Host.CreateDefaultBuilder(args)
           .ConfigureServices((context, services) =>
           {

               services.AddHostedService<HttpLoggingHostedService>();
               services.AddHostedService<GenericHostedService>();
               
               services.AddDbContext<GenericContext>();
               services.AddSingleton(typeof(IItemQueue<,>), typeof(ItemQueue<,>));
               services.AddSingleton(typeof(IChannelQueue<>), typeof(ChannelQueue<>));

               services.AddSingleton<IHttpLogItemQueue, HttpLogItemQueue>();
               services.AddTransient<IHttpLogRepository, HttpLogRepository>();
               services.AddTransient<IHttpLogService, HttpLogService>();



           });

        IHost host = builder.Build();

        host.Run();
    }
}