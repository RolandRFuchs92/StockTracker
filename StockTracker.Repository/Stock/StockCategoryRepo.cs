using StockTracker.Interface.Models.Stock;
using StockTracker.Repository.Interface.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Repository.Stock
{
		public class StockCategoryRepo : IStockCategoryRepo
		{
				public IStockCategory Add(string categoryName)
				{
						throw new NotImplementedException();
				}

				public IStockCategory Edit(int stockCategoryId, string categoryName)
				{
						throw new NotImplementedException();
				}

				public bool IsValid(int stockCategoryId)
				{
						throw new NotImplementedException();
				}

				public List<IStockCategory> List()
				{
						throw new NotImplementedException();
				}
		}
}
