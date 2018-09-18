using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IGetStockLevel
    {
	    StockLevel Get(int stockItemId, int clientId);
	    List<StockLevel> Get(List<int> stockItemId, int clientId);
	    List<StockLevel> GetByCategoryId(int categoryId, int clientId);
	    List<StockLevel> GetByCategoryId(List<int> categoryId, int clientId);
    }
}
