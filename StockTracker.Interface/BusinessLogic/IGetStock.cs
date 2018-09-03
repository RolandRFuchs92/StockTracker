using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Interface.BusinessLogic
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
