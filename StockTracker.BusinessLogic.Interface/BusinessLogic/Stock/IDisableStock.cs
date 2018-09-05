using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Stock
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
