using Demo.App.Generic.Entities;

namespace Demo.App.Generic.Repository;
public interface IHttpLogRepository
{
    void AddHttpLog(HttpLogEntity httpLog);
}