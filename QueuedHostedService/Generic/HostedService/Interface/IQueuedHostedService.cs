using System.Threading;
using System.Threading.Tasks;

namespace Demo.App.Generic.HostedService.Interface;
public interface IQueuedHostedService<T>
{
    Task ProcessQueueAsync(CancellationToken cancellationToken);
    Task StopAsync(CancellationToken cancellationToken);
}