using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;
using StockTracker.Interface.ViewModels;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Stock
{
    public interface IAddStock
    {
	    bool AddNew(IStockItem stockItem);
	    int AddNew(List<IStockItem> stockItems);
	    bool Add(IStockItem stockItemId, int clientId, int minPar);
	    int Add(List<IStockItem> stockItems, int clinetId, int minPar);
	    bool AddCategory(int categoryId, int clientId);
	    int AddCategory(List<int> categoryIds, int clientId);
	    bool CopyFromClient(int fromClientId, int toClientId);
	    int CopyFromClient(int fromClientId, List<int> toClientIds);
	    bool EnableAllOldStock(int clientId);
    }
}
