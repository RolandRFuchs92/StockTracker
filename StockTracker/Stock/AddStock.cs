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

		public bool AddNew(List<INewstockItem> stockItems)
		{
			throw new NotImplementedException();
		}

		public bool Add(IStockItem stockItemId, int clientId, int minPar)
		{
			throw new NotImplementedException();
		}

		public bool Add(List<IStockItem> stockItems, int clinetId, int minPar)
		{
			throw new NotImplementedException();
		}

		public bool AddCategory(int categoryId, int clientId)
		{
			throw new NotImplementedException();
		}

		public bool AddCategory(List<int> categoryIds, int clientId)
		{
			throw new NotImplementedException();
		}

		public bool CopyFromClient(int fromClientId, int toClientId)
		{
			throw new NotImplementedException();
		}

		public bool CopyFromClient(int fromClientId, List<int> toClientIds)
		{
			throw new NotImplementedException();
		}

		public bool EnableAllOldStock(int clientId)
		{
			throw new NotImplementedException();
		}
	}
}
