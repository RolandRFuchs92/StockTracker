using StockTracker.BusinessLogic.Interface.BusinessLogic.Stock;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockTracker.Context;
using StockTracker.Model.Stock;

namespace StockTracker.BusinessLogic.Stock
{
	public class AddStock : IAddStock
	{
		private StockTrackerContext _db;
		private readonly IMapper _map;

		public AddStock(StockTrackerContext db, IMapper map)
		{
			_db = db;
			this._map = map;
		}

		public bool AddNew(IStockItem stockItem)
		{
			try
			{
				var stock = _map.Map<StockItem>(stockItem);
				_db.StockItems.Add(stock);
				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public int AddNew(List<IStockItem> stockItems)
		{
			var fails = 0;

			foreach (var stock in stockItems)
				if (!AddNew(stock))
					fails++;

			return fails;
		}

		public bool Add(IStockLevel stockLevel)
		{
			try
			{
				var stock = _map.Map<StockLevel>(stockLevel);
				_db.StockLevels.Add(stock);
				_db.SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public int Add(List<IStockLevel> stockLevels)
		{
			var fails = 0;

			foreach (var stock in stockLevels)
				if (!Add(stock))
					fails++;

			return fails;
		}

		public bool AddCategory(int categoryId, int clientId)
		{
			throw new NotImplementedException();
		}

		public int AddCategory(List<int> categoryIds, int clientId)
		{
			throw new NotImplementedException();
		}

		public bool CopyFromClient(int fromClientId, int toClientId)
		{
			throw new NotImplementedException();
		}

		public int CopyFromClient(int fromClientId, List<int> toClientIds)
		{
			throw new NotImplementedException();
		}

		public bool EnableAllOldStock(int clientId)
		{
			throw new NotImplementedException();
		}
	}
}
