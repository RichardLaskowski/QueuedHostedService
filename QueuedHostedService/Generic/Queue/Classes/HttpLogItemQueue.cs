using Demo.App.Generic.Entities;
using Demo.App.Generic.Models;
using Demo.App.Generic.Queue.Interfaces;

namespace Demo.App.Generic.Queue.Classes;

public class HttpLogItemQueue : ItemQueue<HttpLogEntity, HttpLogItem>, IHttpLogItemQueue
{
    public HttpLogItemQueue(int capacity = 100) : base(capacity)
    {
    }
}
