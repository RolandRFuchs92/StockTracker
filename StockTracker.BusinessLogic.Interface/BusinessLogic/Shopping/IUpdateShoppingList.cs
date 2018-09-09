using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping
{
    public interface IUpdateShoppingList
    {
	    IShoppingList Add(int shoppingListId, int stockItemId);
	    IShoppingList Add(int shoppingListId, List<int> stockItemIdList);
	    IShoppingList Remove(int shoppingListId, int stockItemId);
	    IShoppingList Remove(int shoppingListId, List<int> stockIdList);
	    IShoppingList Update(int ShoppingListId, int stockItemId, int quantity);
    }
}
