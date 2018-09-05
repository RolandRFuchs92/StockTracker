using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Stock
{
    public interface IEditStock
    {
	    bool Edit(int stockItemId, int par, bool isMin);
	    bool Edit(int stockItemId, int categoryId);
	    bool Edit(int stockItemId, string stockName);
	    bool Edit(int stockItemId, decimal price);
    }
}
