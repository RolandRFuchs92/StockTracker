using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.Models.User;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic
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
