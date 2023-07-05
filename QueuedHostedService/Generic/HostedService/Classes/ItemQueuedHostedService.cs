using System.Threading;
using System.Threading.Tasks;

using Demo.App.Generic.HostedService.Interface;
using Demo.App.Generic.Models;
using Demo.App.Generic.Queue.Interfaces;

using Microsoft.Extensions.Logging;

namespace Demo.App.Generic.HostedService.Classes;

public abstract class ItemQueuedHostedService<TType, TItem> : QueuedHostedService<TItem>, IItemQueuedHostedService<TType, TItem>
    where TItem : QueueItem<TType>
{
    public ItemQueuedHostedService(
        IItemQueue<TType, TItem> queue,
        ILogger<ItemQueuedHostedService<TType, TItem>> logger) : base(queue, logger)
    {
    }

    public override async Task ProcessQueueAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            TItem item = await _queue.DequeueAsync(cancellationToken);

            if (item is not null)
            {
               await ProcessItemAsync(item, cancellationToken);
            }
        }
    }

    public abstract Task ProcessItemAsync(TItem item, CancellationToken cancellationToken);
}
