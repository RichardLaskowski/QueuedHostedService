using Microsoft.Extensions.Logging;

namespace Demo.App;

public class DatabaseLoggerConfiguration
{
	public LogLevel Default { get; set; }
	public string ConnectionString { get; set; }
	public string Table { get; set; }
	public int QueueCapacity { get; set; }
}
