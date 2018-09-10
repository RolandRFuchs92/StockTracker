using System;
using System.Collections.Generic;
using StockTracker.Interface.Models.Shopping;

namespace StockTracker.Repository.Interface.BusinessLogic.Shopping
{
    public interface IUpdateShoppingList
    {
	    IShoppingList Add(int shoppingListId, int stockItemId, int quantity);
	    IShoppingList Add(int shoppingListId, List<Tuple<int,int>> newShoppingItem);
	    IShoppingList Remove(int shoppingListId, int stockItemId);
	    IShoppingList Remove(int shoppingListId, List<int> stockIdList);
	    IShoppingList Update(int ShoppingListId, int stockItemId, int quantity);
    }
}
