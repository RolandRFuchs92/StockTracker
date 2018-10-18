using System;
using System.Collections.Generic;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Interface.Models.Shopping
{
    public interface IShoppingListItem
    {
        int ShoppingListItemId { get; set; }
		int ShoppingListId { get; set; }
		int StockCoreId { get; set; }
		int Quantity { get; set; }
	    bool IsCollected { get; set; }
		DateTime CreatedOn { get; set; }
	}
}
