namespace Demo.App.Generic.Models;

public abstract record QueueItem<TType>(TType Value);
