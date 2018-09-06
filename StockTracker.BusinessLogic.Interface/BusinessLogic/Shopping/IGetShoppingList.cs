using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Shopping;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping
{
    public interface IGetShoppingList
    {
	    IShoppingList Get(int shoppingListId);
	    IShoppingList Get(int clientId, DateTime date);
	    IShoppingList GetMemberShoppingList(int memberId, DateTime date);
    }
}
