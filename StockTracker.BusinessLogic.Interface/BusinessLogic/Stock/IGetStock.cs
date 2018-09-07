using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Stock
{
    public interface IGetStock
    {
		IStockItem GetStockByStockItem(int stockId, int clientId);
	    List<IStockItem> GetStockCheckedToday();
	    List<IStockItem> GetStockNotCheckedToday();
	    List<IStockItem> GetStockBelowPar();
	    List<IStockItem> GetStockAbovePar();
    }
}
