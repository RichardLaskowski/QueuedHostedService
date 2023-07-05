using System.Threading;
using System.Threading.Tasks;

namespace Demo.App.Generic.Queue.Interfaces;
public interface IChannelQueue<T>
{
    void Complete();
    Task<T> DequeueAsync(CancellationToken cancellationToken);
    Task EnqueueAsync(T t, CancellationToken cancellationToken);
}