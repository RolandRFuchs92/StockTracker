using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IDisableStock
    {
	    bool Disable(IStockItem stock, int clientId);
	    bool Disable(List<IStockItem> stock, int clientId);
	    bool Disable(List<int> categoryIds, int clientId);
	    bool Disable(List<IStockCategory> categories, int clientId);
	    bool DisableAll(List<int> clientIds);
	    bool DisableAll(int clientId);
    }
}
