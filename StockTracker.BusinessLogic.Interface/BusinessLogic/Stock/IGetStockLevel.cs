using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Stock
{
    public interface IGetStockLevel
    {
	    IStockLevel Get(int stockItemId, int clientId);
	    IStockLevel Get(IStockItem stockItem);
	    List<IStockLevel> Get(List<int> stockItemId, int clientId);
	    List<IStockLevel> Get(List<IStockItem> stockItems);
    }
}
