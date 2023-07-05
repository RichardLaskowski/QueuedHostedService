using Demo.App.Generic.Entities;

namespace Demo.App.Generic.Repository;

public class HttpLogRepository : IHttpLogRepository
{
    public GenericContext GenericContext { get; set; }

    public HttpLogRepository(GenericContext genericContext)
    {
        GenericContext = genericContext;
    }

    public void AddHttpLog(HttpLogEntity httpLogEntity)
    {
        GenericContext.Set<HttpLogEntity>().Add(httpLogEntity);
    }
}
