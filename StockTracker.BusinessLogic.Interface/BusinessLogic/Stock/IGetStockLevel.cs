using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.ClientStock;
using StockTracker.Model.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IGetStockLevel
    {
	    ClientStockLevel Get(int stockItemId, int clientId);
	    List<ClientStockLevel> Get(List<int> stockItemId, int clientId);
	    List<ClientStockLevel> GetByCategoryId(int categoryId, int clientId);
	    List<ClientStockLevel> GetByCategoryId(List<int> categoryId, int clientId);
    }
}
