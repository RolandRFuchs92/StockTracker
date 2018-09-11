using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IGetStockLevel
    {
	    IStockLevel Get(int stockItemId, int clientId);
	    List<IStockLevel> Get(List<int> stockItemId, int clientId);
	    List<IStockLevel> GetByCategoryId(int categoryId, int clientId);
	    List<IStockLevel> GetByCategoryId(List<int> categoryId, int clientId);
    }
}
