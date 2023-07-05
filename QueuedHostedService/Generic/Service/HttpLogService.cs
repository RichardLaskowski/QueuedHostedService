using Demo.App.Generic.Entities;
using Demo.App.Generic.Repository;

namespace Demo.App.Generic.Service;

public class HttpLogService : IHttpLogService
{
    private readonly IHttpLogRepository _httpLogRepository;

    public HttpLogService(IHttpLogRepository httpLogRepository)
    {
        _httpLogRepository = httpLogRepository;
    }

    public void AddHttpLog(HttpLogEntity httpLogEntity)
    {
        _httpLogRepository.AddHttpLog(httpLogEntity);
    }
}
