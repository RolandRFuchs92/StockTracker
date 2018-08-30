using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;

namespace StockTracker.Interface.BusinessLogic
{
    public interface IStockTake
    {
	    void StartStockTake(IMember member);
	    void LogStockCount(IStockLevel stock);
	    void LogStockCheck(IStockLevel stock);
	    void EditStockCount(IStockLevel stock);
	    void SuggestStockCount(IStockLevel stock);
	    void EndStockTake(IMember member);
    }
}
