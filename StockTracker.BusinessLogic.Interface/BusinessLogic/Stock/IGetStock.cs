using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Stock
{
    public interface IGetStock
    {
	    StockItem GetStockByStockItem(int stockItemId, int clientId);
	    List<StockItem> GetStockCheckedToday(int clientId);
	    List<StockItem> GetStockNotCheckedToday(int clientId);
	    List<StockItem> GetStockBelowPar(int clientId);
	    List<StockItem> GetStockAbovePar(int clientId);
	    List<StockItem> GetAcceptableStock(int clientId);
    }
}
