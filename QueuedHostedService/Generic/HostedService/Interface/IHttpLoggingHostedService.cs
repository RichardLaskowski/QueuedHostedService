using Demo.App.Generic.Entities;
using Demo.App.Generic.Models;

namespace Demo.App.Generic.HostedService.Interface;

public interface IHttpLoggingHostedService : IItemQueuedHostedService<HttpLogEntity, HttpLogItem>
{
}
