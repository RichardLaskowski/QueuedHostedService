using Demo.App.Generic.Models;
using Demo.App.Generic.Queue.Interfaces;

namespace Demo.App.Generic.Queue.Classes;

public class ItemQueue<TType, TItem> : ChannelQueue<TItem>, IItemQueue<TType, TItem> 
    where TItem : QueueItem<TType>
{
    public ItemQueue(int capacity = 100) : base(capacity)
    {
    }
}
