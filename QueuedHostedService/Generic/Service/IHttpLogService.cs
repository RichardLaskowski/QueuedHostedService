using Demo.App.Generic.Entities;

namespace Demo.App.Generic.Service;
public interface IHttpLogService
{
    void AddHttpLog(HttpLogEntity httpLogEntity);
}