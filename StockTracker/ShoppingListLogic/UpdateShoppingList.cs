using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;

namespace StockTracker.BusinessLogic.ShoppingListLogic
{
    public class UpdateShoppingList : IUpdateShoppingList
    {
	    private readonly StockTrackerContext _db;

	    public UpdateShoppingList(StockTrackerContext db)
	    {
		    _db = db;
	    }


	    public IShoppingList Add(int shoppingListId, int stockItemId)
	    {
		    try
		    {
				


		    }
		    catch (Exception e)
		    {
			    return null;
		    }
	    }

	    public IShoppingList Add(int shoppingListId, List<int> stockItemIdList)
	    {
		    throw new NotImplementedException();
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



    }
}
