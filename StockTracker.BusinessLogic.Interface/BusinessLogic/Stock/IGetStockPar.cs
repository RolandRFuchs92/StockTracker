using System.Collections.Generic;
using StockTracker.Interface.Models.ClientStock;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IGetStockPar
    {
	    IClientStockItem Get(int stockItemId, int clientId);
	    IClientStockItem Get(IClientStockLevel stockLevel);
	    List<IClientStockItem> Get(List<int> stockItems, int clientId);
		List<IClientStockItem> Get(List<IClientStockLevel> stockLevels);
    }
}
