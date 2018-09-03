using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic
{
    public interface IGetStock
    {
		IStockItem GetStockByStockItem(int stockId);
	    List<IStockItem> GetStockCheckedToday();
	    List<IStockItem> GetStockNotCheckedToday();
	    List<IStockItem> GetStockBelowPar();
	    List<IStockItem> GetStockCheckedByMember(int memberId);
	    List<IStockItem> GetStockAbovePar();
    }
}
