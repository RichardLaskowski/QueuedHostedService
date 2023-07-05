using System;

using Microsoft.Extensions.Logging;

namespace Demo.App;

public class SimpleLogEntry 
{
	/// <summary>
	/// Initializes an instance of the SimpleLogEntry class.
	/// </summary>
	/// <param name="logLevel">The log level.</param>
	/// <param name="category">The category name for the log.</param>
	/// <param name="eventId">The log event Id.</param>
	/// <param name="message">The log message</param>
	public SimpleLogEntry(LogLevel logLevel, string category, EventId eventId, string message)
	{
		LogLevel = logLevel;
		Category = category;
		EventId = eventId;
		Message = message;
	}

	/// <summary>
	/// Gets the LogLevel
	/// </summary>
	public LogLevel LogLevel { get; }

	/// <summary>
	/// Gets the log category
	/// </summary>
	public string Category { get; }

	/// <summary>
	/// Gets the log EventId
	/// </summary>
	public EventId EventId { get; }

	/// <summary>
	/// Gets the log Message
	/// </summary>
	public string Message { get; private set; }

	/// <summary>
	/// Gets the log exception
	/// </summary>
	public Exception? Exception { get; }
}
