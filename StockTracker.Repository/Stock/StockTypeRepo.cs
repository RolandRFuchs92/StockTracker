using StockTracker.Interface.Models.Stock;
using StockTracker.Repository.Interface.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Stock;
using StockTracker.Repository.Enums;
using StockTracker.Repository.Util;

namespace StockTracker.Repository.Stock
{
	public class StockTypeRepo : Logging<StockTypeRepo>, IStockTypeRepo 
	{
		private readonly StockTrackerContext _db;

		public StockTypeRepo(IStockTrackerContext db, ILoggerAdapter<StockTypeRepo> log) : base(log)
		{
			_db = db as StockTrackerContext;
		}

		public IStockType Add(string stockTypeName)
		{
			try
			{
				if (string.IsNullOrEmpty(stockTypeName))
				{
					LogError(LoggingEvent.Error,$"There was an error creating new StockType[{stockTypeName}]");
					return null;
				}

				var stockType = new StockType {StockTypeName = stockTypeName };

				_db.StockTypes.Add(stockType);
				var stockTypeId = _db.SaveChanges();
				LogInformation(LoggingEvent.Insert, $"Successfully added new StockType[{stockTypeId}]");

				return stockType;
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, "", e);
				return null;
			}
		}

		public IStockType Edit(int stockTypeId, string stockTypeName)
		{
			try
			{
				if (string.IsNullOrEmpty(stockTypeName))
				{
					LogError(LoggingEvent.Error, "StockTypeName cannot be empty.");
					return null;
				}

				var stockType = _db.StockTypes.FirstOrDefault(i => i.StockTypeId == stockTypeId);
				stockType.StockTypeName = stockTypeName;
				_db.SaveChanges();

				LogInformation(LoggingEvent.Update, $"Updated StockType[{stockTypeId}]");
				return stockType;
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"There was an error editing StockType[{stockTypeId}] to use name [{stockTypeName}]", e);
				return null;
			}
		}

		public List<IStockType> List()
		{
			try
			{
				return _db.StockTypes.ToList<IStockType>();
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, "There was an error fetching StockType list.", e);
				return null;
			}
		}

		public bool IsValid(int stockTypeId)
		{
			try
			{
				return _db.StockTypes.Any(i => i.StockTypeId == stockTypeId);
			}
			catch (Exception e)
			{
				LogError(LoggingEvent.Error, $"There was an error checking StockType[{stockTypeId}]");
				return false;
			}
		}
	}
}
