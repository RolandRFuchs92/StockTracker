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
		IStock GetStockByStockItem(int stockId);
	    List<IStock> GetStockCheckedToday();
	    List<IStock> GetStockNotCheckedToday();
	    List<IStock> GetStockBelowPar();
	    List<IStock> GetStockCheckedByMember(int memberId);
	    List<IStock> GetStockAbovePar();
    }
}
