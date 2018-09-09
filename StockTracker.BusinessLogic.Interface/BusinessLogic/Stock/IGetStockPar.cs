using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Stock
{
    public interface IGetStockPar
    {
	    IStockPar Get(int stockItemId, int clientId);
	    IStockPar Get(IStockLevel stockLevel);
	    List<IStockPar> Get(List<int> stockItems, int clientId);
		List<IStockPar> Get(List<IStockLevel> stockLevels);
    }
}
