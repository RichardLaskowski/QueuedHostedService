using Demo.App.Generic.Entities;
using Demo.App.Generic.Models;

namespace Demo.App.Generic.Queue.Interfaces;
public interface IHttpLogItemQueue : IItemQueue<HttpLogEntity, HttpLogItem>
{
}
