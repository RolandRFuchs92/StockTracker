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
	    IShoppingList Add(int shoppingListId, IStockItem stock);
	    IShoppingList Add(int shoppingListId, List<IStockItem> stockList);
	    IShoppingList Remove(int shoppingListId, IStockItem stock);
	    IShoppingList Remove(int shoppingListId, int stockItemId);
	    IShoppingList Remove(int shoppingListId, List<IStockItem> stockList);
	    IShoppingList Update(int ShoppingListId, int stockItemId, int quantity);
    }
}
