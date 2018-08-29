using System;
using StockTracker.Interface.Models.User;

namespace StockTracker.Interface.Models.Shopping
{
    public interface IShoppingList
    {
        int ShoppingListId { get; set; }
		int MemberId { get; set; }
		bool HasNotified { get; set; }
		DateTime DateCreated { get; set; }

		IMember Member { get; set; }
    }
}
