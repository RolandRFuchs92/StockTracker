using System;

namespace StockTracker.Adapter.Interface.Logger
{
    public interface ILoggerAdapter<T>
    {
        void LogError(int eventId, Exception exception, string message);
        void LogError(int eventId, string message);
        void LogInformation(int eventId, string message);
    }
}
