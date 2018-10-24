using StockTracker.Interface.Models.ClientStock;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IStockTake
    {
	    bool LogStockCount(IClientStockLevel stock);
	    bool StartStockTake(IMember memberId);
	    bool EndStockTake(IMember memberId);
    }
}
