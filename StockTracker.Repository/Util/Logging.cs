using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Repository.Enums;

namespace StockTracker.Repository.Util
{
		public class Logging<T>
		{
				public ILoggerAdapter<T> log { get; }

				public Logging(ILoggerAdapter<T> log)
				{
						this.log = log;
				}

				public void LogError(LoggingEvent eventType, string message, Exception excep = null)
				{
						if (excep == null)
								log.LogError((int)eventType, message);

						if (excep != null)
								log.LogError((int)eventType, excep, message);
				}

				public void LogInformation(LoggingEvent eventType, string message)
				{
						log.LogInformation((int)eventType, message);
				}
		}
}
