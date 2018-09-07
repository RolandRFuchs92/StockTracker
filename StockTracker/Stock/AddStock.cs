using StockTracker.BusinessLogic.Interface.BusinessLogic.Stock;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.BusinessLogic.Stock
{
	public class AddStock : IAddStock
	{
		public bool Add(int stockItemId, int clientId)
		{
			throw new NotImplementedException();
		}

		public bool Add(List<int> stockItemIds, int clinetId)
		{
			throw new NotImplementedException();
		}

		public bool Add(List<IStockItem> stockItems, int clinetId)
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

		public bool AddNew(IStockItem stockItem, int minStock)
		{
			throw new NotImplementedException();
		}

		public bool AddNew(List<INewstockItem> stockItems)
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
