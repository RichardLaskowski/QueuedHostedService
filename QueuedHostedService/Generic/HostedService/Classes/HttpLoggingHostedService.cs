using System;
using System.Threading;
using System.Threading.Tasks;

using Demo.App.Generic.Entities;
using Demo.App.Generic.HostedService.Interface;
using Demo.App.Generic.Models;
using Demo.App.Generic.Queue.Interfaces;
using Demo.App.Generic.Service;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Demo.App.Generic.HostedService.Classes;

internal class HttpLoggingHostedService : ItemQueuedHostedService<HttpLogEntity, HttpLogItem>, IHttpLoggingHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IHttpLogService _httpLogService;

    public HttpLoggingHostedService(
        IServiceProvider serviceProvider,
        IHttpLogItemQueue queue,
        ILogger<HttpLoggingHostedService> logger) : base(queue, logger)
    {
        _serviceProvider = serviceProvider;

        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            _httpLogService = scope.ServiceProvider.GetRequiredService<IHttpLogService>();
        }
    }

    public override async Task ProcessItemAsync(HttpLogItem httpLogItem, CancellationToken cancellationToken)
    {
        await WriteToDatabaseAsync(httpLogItem.httpLogEntity, cancellationToken);
    }

    private async Task WriteToDatabaseAsync(HttpLogEntity httpLogEntity, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync("Writing httpLog to database.");
    }
}
