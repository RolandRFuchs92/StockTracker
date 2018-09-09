using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Clients;
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
	    private IGetClient _client;

	    public CreateShoppingList(StockTrackerContext db, IMapper map, IGetStock stock, IGetClient client)
	    {
		    _map = map;
		    _db = db;
		    _stock = stock;
		    _client = client;
	    }


	    public IShoppingList HighPriorityList(int memberId)
	    {
		    var clientId = _client.GetClientByMember(memberId).ClientId;
		    var stockList = _stock.GetStockBelowPar(clientId);


		    var shoppingList = _db.ShoppingLists.Add(BuildShoppingList(memberId));

		    foreach (var stockItem in stockList)
		    {
			    var shoppingListItem = BuildShoppingListItem(stockItem);

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

	    private Model.Shopping.ShoppingList BuildShoppingList(int memberId)
	    {
		    return new Model.Shopping.ShoppingList
		    {
				MemberId = memberId,
				DateCreated = DateTime.Now,
				HasNotified = false,
		    };
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
