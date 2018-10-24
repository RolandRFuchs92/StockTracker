using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IAddStock
    {
	    bool AddNew(IStockCore stockItem);
	    int AddNew(List<IStockCore> stockItems);
	    bool Add(IStockCore stockItemId);
	    int Add(List<IStockCore> stockLevels);
	    bool AddCategory(int categoryId, int clientId);
	    bool AddCategory(List<int> categoryIds, int clientId);
	    bool CopyFromClient(int fromClientId, int toClientId);
	    int CopyFromClient(int fromClientId, List<int> toClientIds);
	    bool EnableAllOldStock(int clientId);
    }
}
