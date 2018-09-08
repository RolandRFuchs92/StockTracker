using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Stock
{
    public interface IStockTake
    {
	    bool LogStockCount(IStockLevel stock);
	    bool StartStockTake(IMember memberId);
	    bool EndStockTake(IMember memberId);
    }
}
