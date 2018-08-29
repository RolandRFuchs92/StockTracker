using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.User;

namespace StockTracker.Interface
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
