using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Interface.Models.Shopping
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
