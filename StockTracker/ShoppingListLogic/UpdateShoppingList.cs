using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Model.Shopping;

namespace StockTracker.BusinessLogic.ShoppingListLogic
{
    public class UpdateShoppingList : IUpdateShoppingList
    {
	    private readonly StockTrackerContext _db;

	    public UpdateShoppingList(StockTrackerContext db)
	    {
		    _db = db;
	    }


	    public IShoppingList Add(int shoppingListId, int stockItemId, int quantity)
	    {
		    try
		    {
			    _db.ShoppingListItems.Add(BuildNewShoppingListItem(shoppingListId, stockItemId, quantity));
			    _db.SaveChanges();
			    return _db.ShoppingLists.FirstOrDefault(i => i.ShoppingListId == shoppingListId);
		    }
		    catch (Exception e)
		    {
			    return null;
		    }
	    }

	    public IShoppingList Add(int shoppingListId, List<Tuple<int,int>> newShoppingItem)
	    {
		    try
		    {
				_db.ShoppingListItems.AddRange(GenerateShoppingList(shoppingListId,newShoppingItem));
			    _db.SaveChanges();
			    return _db.ShoppingLists.FirstOrDefault(i => i.ShoppingListId == shoppingListId);
		    }
		    catch (Exception e)
		    {
			    return null;
		    }

	    }

	    public IShoppingList Remove(int shoppingListId, int stockItemId)
	    {
		    throw new NotImplementedException();
	    }

	    public IShoppingList Remove(int shoppingListId, List<int> stockIdList)
	    {
		    throw new NotImplementedException();
	    }

	    public IShoppingList Update(int ShoppingListId, int stockItemId, int quantity)
	    {
		    throw new NotImplementedException();
	    }

	    private ShoppingListItem BuildNewShoppingListItem(int shoppingListId,int stockItemId , int quantity)
	    {
		    return new ShoppingListItem
		    {
				IsCollected = false,
				Quantity = quantity,
				ShoppingListId = shoppingListId,
				StockItemId = stockItemId
		    };
	    }

	    private List<ShoppingListItem> GenerateShoppingList(int shoppingListId, List<Tuple<int, int>> newShoppingItemsList)
	    {
		    var shoppingList = new List<ShoppingListItem>();

		    foreach (var shoppingListItem in newShoppingItemsList)
		    {
			    shoppingList.Add(BuildNewShoppingListItem(shoppingListId, shoppingListItem.Item1, shoppingListItem.Item2));
		    }

		    return shoppingList;
	    }
    }
}
