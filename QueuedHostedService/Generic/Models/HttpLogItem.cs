using Demo.App.Generic.Entities;

namespace Demo.App.Generic.Models;

public record HttpLogItem(HttpLogEntity httpLogEntity) : QueueItem<HttpLogEntity>(httpLogEntity);
