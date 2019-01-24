using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.Stock
{
		public interface IStockTypeRepo
		{
				IStockType Add(string stockTypeName);
				IStockType Edit(int stockTypeId, string stockTypeName);
				List<IStockType> List();
				bool IsValid(int stockTypeId);
		}
}
