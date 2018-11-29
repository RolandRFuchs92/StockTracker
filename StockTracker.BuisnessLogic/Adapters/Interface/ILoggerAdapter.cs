using System;

namespace StockTracker.BuisnessLogic.Adapters.Interface
{
    public interface ILoggerAdapter<T>
    {
        void LogError(int eventId, Exception exception, string message);
        void LogInformation(int eventId, string message);
    }
}
