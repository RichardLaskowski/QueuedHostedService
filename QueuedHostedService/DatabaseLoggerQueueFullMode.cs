namespace Demo.App;

public enum DatabaseLoggerQueueFullMode
{
	/// <summary>
	/// Blocks the logging threads once the queue limit is reached.
	/// </summary>
	Wait,
        /// <summary>
        /// Drops new log messages when the queue is full.
        /// </summary>
        DropWrite
}