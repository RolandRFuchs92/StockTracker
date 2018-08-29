using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface
{
    public interface IShoppingListItems
    {
        int ShoppingListItemId { get; set; }
		int StockId { get; set; }
		int Quantity { get; set; }
	    bool IsCollected { get; set; }

		List<IStock> Stocks { get; set; }
    }
}
