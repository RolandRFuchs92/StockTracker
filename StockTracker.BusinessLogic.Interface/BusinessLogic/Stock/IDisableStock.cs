using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IDisableStock
    {
	    bool Disable(int stockItemId, int clientId);
	    bool Disable(List<int> categoryIds, int clientId);
	    bool DisableAll(int clientId);
	    bool DisableAll(List<int> clientIds);
    }
}
