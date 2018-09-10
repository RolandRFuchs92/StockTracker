using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Repository.Interface.BusinessLogic.Stock
{
    public interface IGetStockPar
    {
	    IStockPar Get(int stockItemId, int clientId);
	    IStockPar Get(IStockLevel stockLevel);
	    List<IStockPar> Get(List<int> stockItems, int clientId);
		List<IStockPar> Get(List<IStockLevel> stockLevels);
    }
}
