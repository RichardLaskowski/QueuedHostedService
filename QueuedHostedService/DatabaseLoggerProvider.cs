using System;
using System.Collections.Concurrent;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Demo.App;

[ProviderAlias("Database")]
public class DatabaseLoggerProvider : ILoggerProvider
{
	#region Fields

	private readonly IDisposable? _onChangeToken;
	private DatabaseLoggerConfiguration _currentConfig;
	private readonly ConcurrentDictionary<string, DatabaseLogger> _loggers = new ConcurrentDictionary<string, DatabaseLogger>(StringComparer.OrdinalIgnoreCase);
	private readonly IQueue<SimpleLogEntry> _queue;

	#endregion

	#region Constructor

	public DatabaseLoggerProvider(IOptionsMonitor<DatabaseLoggerConfiguration> config, IQueue<SimpleLogEntry> queue)
	{
		_currentConfig = config.CurrentValue;
		_onChangeToken = config.OnChange(updatedConfig => _currentConfig = updatedConfig);
		_queue = queue;
	}

	#endregion

	#region Public Methods

	public ILogger CreateLogger(string categoryName)
	{
		return _loggers.GetOrAdd(categoryName, (name) =>
		{
			return new DatabaseLogger(name, _queue, GetCurrentConfig());
		});
	}

	public void Dispose()
	{
		_loggers.Clear();
		_onChangeToken?.Dispose();
	}

	#endregion

	#region Private Methods

	private DatabaseLoggerConfiguration GetCurrentConfig() => _currentConfig;

	#endregion
}
