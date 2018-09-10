using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IGetStockLevel
    {
	    IStockLevel Get(int stockItemId, int clientId);
	    IStockLevel Get(IStockItem stockItem);
	    List<IStockLevel> Get(List<int> stockItemId, int clientId);
	    List<IStockLevel> Get(List<IStockItem> stockItems);
    }
}
