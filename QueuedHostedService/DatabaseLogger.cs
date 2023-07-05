using System;

using Microsoft.Extensions.Logging;

namespace Demo.App;

public class DatabaseLogger : ILogger
{
	private readonly string _categoryName;
	private readonly IQueue<SimpleLogEntry> _queue;
	private readonly DatabaseLoggerConfiguration _databaseLoggerConfiguration;

	public DatabaseLogger(
		string categoryName,
		IQueue<SimpleLogEntry> queue,
		DatabaseLoggerConfiguration databaseLoggerConfiguration)
	{
		_categoryName = categoryName;
		_queue = queue;
		_databaseLoggerConfiguration = databaseLoggerConfiguration;
	}

	public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
	{
		if (!IsEnabled(logLevel))
		{
			return;
		}

		if (formatter is null)
		{
			throw new ArgumentNullException(nameof(formatter));
		}

		string message = formatter(state, exception);
		SimpleLogEntry simpleLogEntry = new SimpleLogEntry(logLevel, _categoryName, eventId, message);
		//_queue.EnqueueAsync(simpleLogEntry);
	}

	public bool IsEnabled(LogLevel logLevel) => logLevel >= _databaseLoggerConfiguration.Default;
	public IDisposable? BeginScope<TState>(TState state) where TState : notnull => default!;
}
