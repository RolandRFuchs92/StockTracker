using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Stock;
using StockTracker.BusinessLogic.Stock;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Shopping;

namespace StockTracker.BusinessLogic.ShoppingList
{
    public class CreateShoppingList : ICreateShoppingList
    {
	    private StockTrackerContext _db;
	    private IMapper _map;
	    private IGetStock _stock;

	    public CreateShoppingList(StockTrackerContext db, IMapper map, IGetStock stock)
	    {
		    _map = map;
		    _db = db;
		    _stock = stock;
	    }


	    public IShoppingList HighPriorityList(int memberId)
	    {
			
		    var stockList = _stock.GetStockBelowPar(clientId);
		    foreach (var stockItem in stockList)
		    {
			    
		    }

	    }

	    public IShoppingList LowPriorityList(int clientId)
	    {
		    throw new NotImplementedException();
	    }

	    public IShoppingList OutStandingShoppingList(int clientId)
	    {
		    throw new NotImplementedException();
	    }

	    private ShoppingListItem BuildShoppingListItem(IStockLevel stock, int stockListId)
	    {
			return new ShoppingListItem
			{
				StockItemId = stock.StockItemId,
				IsCollected = false,
				Quantity = stock.Quantity,
				ShoppingListId = stockListId
		    };
	    }
    }
}
