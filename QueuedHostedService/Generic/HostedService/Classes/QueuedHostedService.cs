using System.Threading.Tasks;
using System.Threading;

using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Demo.App.Generic.Queue.Interfaces;
using Demo.App.Generic.HostedService.Interface;

namespace Demo.App.Generic.HostedService.Classes;

public abstract class QueuedHostedService<T> : BackgroundService, IQueuedHostedService<T>
{
    #region Fields

    protected readonly IChannelQueue<T> _queue;
    protected readonly ILogger<QueuedHostedService<T>> _logger;

    #endregion

    #region Constructors

    protected QueuedHostedService(IChannelQueue<T> queue, ILogger<QueuedHostedService<T>> logger)
    {
        _queue = queue;
        _logger = logger;
    }

    #endregion

    protected override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"{nameof(QueuedHostedService<T>)} is running.");

        return ProcessQueueAsync(cancellationToken);
    }

    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"{nameof(QueuedHostedService<T>)} is stopping.");

        await base.StopAsync(stoppingToken);
    }

    public abstract Task ProcessQueueAsync(CancellationToken cancellationToken);
}
