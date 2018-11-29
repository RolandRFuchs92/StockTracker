﻿using System;
using Microsoft.Extensions.Logging;
using StockTracker.BuisnessLogic.Adapter.Interface;

namespace StockTracker.BuisnessLogic.Adapter.Logging
{
    public class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private ILogger<T> _log;

        public LoggerAdapter(ILogger<T> logger)
        {
            _log = logger;
        }

        public void LogError(int eventId, Exception exception, string message)
        {
            _log.LogError(eventId, exception, message);
        }

        public void LogInformation(int eventId, string message)
        {
            _log.LogInformation(eventId, message);
        }
    }
}
