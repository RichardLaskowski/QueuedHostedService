using System.Threading;
using System.Threading.Tasks;

using Demo.App.Generic.Models;

namespace Demo.App.Generic.HostedService.Interface;

public interface IItemQueuedHostedService<TType, TItem> : IQueuedHostedService<TItem>
    where TItem : QueueItem<TType>
{
    Task ProcessItemAsync(TItem item, CancellationToken cancellationToken);
}