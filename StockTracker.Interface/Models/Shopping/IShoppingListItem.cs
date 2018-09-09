using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Interface.Models.Shopping
{
    public interface IShoppingListItem
    {
        int ShoppingListItemId { get; set; }
		int StockItemId { get; set; }
		int Quantity { get; set; }
	    bool IsCollected { get; set; }
        int ShoppingListId { get; set; }
	}
}
