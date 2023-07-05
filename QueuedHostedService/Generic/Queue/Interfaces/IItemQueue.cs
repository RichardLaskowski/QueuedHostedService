using Demo.App.Generic.Models;

namespace Demo.App.Generic.Queue.Interfaces;

public interface IItemQueue<TType, TItem> : IChannelQueue<TItem>
    where TItem : QueueItem<TType>
{
}
