using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Demo.App.Generic.Queue.Interfaces;

namespace Demo.App.Generic.Queue.Classes;

public class ChannelQueue<T> : IChannelQueue<T>
{
    private readonly Channel<T> _channel;

    public int Count => _channel.Reader.Count;

    public ChannelQueue(int capacity = 100)
    {
        BoundedChannelOptions options = new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        };

        _channel = Channel.CreateBounded<T>(options);
    }

    public async Task EnqueueAsync(T t, CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {

        }

        cancellationToken.ThrowIfCancellationRequested();

        await _channel.Writer.WriteAsync(t, cancellationToken);
    }

    public async Task<T> DequeueAsync(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {

        }

        cancellationToken.ThrowIfCancellationRequested();


        return await _channel.Reader.ReadAsync(cancellationToken);
    }

    public void Complete()
    {
        _channel.Writer.Complete();
    }
}
