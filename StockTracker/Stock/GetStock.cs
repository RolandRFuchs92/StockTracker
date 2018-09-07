using StockTracker.BusinessLogic.Interface.BusinessLogic.Stock;
using StockTracker.Context;
using StockTracker.Interface.Models.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.BusinessLogic.Stock
{
	public class GetStock : IGetStock
	{
		private StockTrackerContext _db;

		public GetStock(StockTrackerContext db)
		{
			_db = db;
		}

		public List<IStockItem> GetStockAbovePar(int stockId, int clientId)
		{
			//_db.StockItems.Where
			throw new NotImplementedException();
		}

		public List<IStockItem> GetStockAbovePar()
		{
			throw new NotImplementedException();
		}

		public List<IStockItem> GetStockBelowPar()
		{
			throw new NotImplementedException();
		}

		public IStockItem GetStockByStockItem(int stockId)
		{
			throw new NotImplementedException();
		}

		public IStockItem GetStockByStockItem(int stockId, int clientId)
		{
			throw new NotImplementedException();
		}

		public List<IStockItem> GetStockCheckedToday()
		{
			throw new NotImplementedException();
		}

		public List<IStockItem> GetStockNotCheckedToday()
		{
			throw new NotImplementedException();
		}
	}
}
