using System;

namespace StockTracker.Interface.Models.Shopping
{
    public interface IShoppingList
    {
        int ShoppingListId { get; set; }
		int MemberId { get; set; }
		bool HasNotified { get; set; }
		DateTime CreatedOn { get; set; }
    }
}
