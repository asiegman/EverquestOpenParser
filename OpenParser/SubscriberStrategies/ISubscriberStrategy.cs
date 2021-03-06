﻿namespace OpenParser.SubscriberStrategies
{
    public interface ISubscriberStrategy<T>
    {
        bool IsMatch(LogEntry entry);
        T GetResult(LogEntry entry);
    }
}