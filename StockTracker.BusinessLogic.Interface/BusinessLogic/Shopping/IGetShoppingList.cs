using System;
using System.Collections.Generic;
using StockTracker.Interface.Models.Shopping;

namespace StockTracker.Repository.Interface.BusinessLogic.Shopping
{
    public interface IGetShoppingList
    {
	    List<IShoppingListItem> Get(int shoppingListId);
	    List<IShoppingListItem> Get(int clientId, DateTime date);
	    List<IShoppingListItem> GetMemberShoppingList(int memberId, DateTime date);
    }
}
