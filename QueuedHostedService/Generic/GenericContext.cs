using Demo.App.Generic.Entities;

using Microsoft.EntityFrameworkCore;

namespace Demo.App.Generic;
public class GenericContext : DbContext
{
    DbSet<HttpLogEntity> _logs;
}
