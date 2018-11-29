using System;

namespace StockTracker.BuisnessLogic.Adapter.Interface
{
    public interface ILoggerAdapter<T>
    {
        void LogError(int eventId, Exception exception, string message);
        void LogInformation(int eventId, string message);
    }
}
