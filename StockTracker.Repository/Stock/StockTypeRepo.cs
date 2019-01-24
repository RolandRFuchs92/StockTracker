using StockTracker.Interface.Models.Stock;
using StockTracker.Repository.Interface.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
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
	public class StockTypeRepo : Logging<IStockTypeRepo>
	{
		private IStockTrackerContext _db;

		public StockTypeRepo(IStockTrackerContext db, ILoggerAdapter<IStockTypeRepo> log) : base(log)
		{
			_db = db;
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

				var stockType = new StockType {StockTypeName = "StockTypeName"};

				_db.StockTypes.Add(stockType);
				var stockTypeId = ((StockTrackerContext) _db).SaveChanges();
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
			throw new NotImplementedException();
		}

		public List<IStockType> List()
		{
			throw new NotImplementedException();
		}

		public bool IsValid(int stockTypeId)
		{
			throw new NotImplementedException();
		}

		

	}
}
