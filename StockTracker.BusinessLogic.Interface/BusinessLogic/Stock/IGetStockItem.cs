using System.Collections.Generic;
using StockTracker.Model.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IGetStockItem
    {
	    StockCore GetStockByStockCore(int stockItemId, int clientId);
	    List<StockCore> GetStockCheckedToday(int clientId);
	    List<StockCore> GetStockNotCheckedToday(int clientId);
	    List<StockCore> GetStockBelowPar(int clientId);
	    List<StockCore> GetStockAbovePar(int clientId);
	    List<StockCore> GetAcceptableStock(int clientId);
    }
}
