using System.Threading;
using System.Threading.Tasks;
using Demo.App.Generic.Queue.Interfaces;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Demo.App;
public class GenericHostedService : IHostedService
{
    private readonly ILogger<GenericHostedService> _logger;
    private readonly IHttpLogItemQueue _httpLogItemQueue;

    public GenericHostedService(ILogger<GenericHostedService> logger, IHttpLogItemQueue httpLogItemQueue)
    {
        _logger = logger;
        _httpLogItemQueue = httpLogItemQueue;
    }


    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            Task.Delay(1000).Wait();
            await _httpLogItemQueue.EnqueueAsync(new(new()), cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(GenericHostedService)} is stopping.");
        return Task.CompletedTask;
    }
}
