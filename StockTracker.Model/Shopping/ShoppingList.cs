using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.User;

namespace StockTracker.Model.Shopping
{
    public class ShoppingList : IShoppingList
    {
	    public int ShoppingListId { get; set; }
	    public int MemberId { get; set; }
	    public bool HasNotified { get; set; }
	    public DateTime DateCreated { get; set; }
	    public IMember Member { get; set; }
    }
}
