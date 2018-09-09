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
using StockTracker.Model.Stock;

namespace StockTracker.BusinessLogic.ShoppingList
{
    public class CreateShoppingList : ICreateShoppingList
    {
	    private StockTrackerContext _db;
	    private IMapper _map;
	    private IGetStockItem _stock;
	    private IGetClient _client;
	    private IGetStockLevel _stockLevel;

	    public CreateShoppingList(StockTrackerContext db, IMapper map, IGetStockItem stock, IGetClient client, IGetStockLevel stockLevel)
	    {
		    _map = map;
		    _db = db;
		    _stock = stock;
		    _client = client;
		    _stockLevel = stockLevel;
	    }


	    public IShoppingList HighPriorityList(int memberId)
	    {
		    var clientId = _client.GetClientByMember(memberId).ClientId;
		    var shoppingList = GetShoppingList(memberId);

			var stockBlowPar = _stock.GetStockBelowPar(clientId);
		    var stockLevels = _stockLevel.Get(stockBlowPar.ToList<IStockItem>());
			//var stockPars = _stock
		    var shoppingItemList = new List<ShoppingListItem>();


		    try
		    {
			    foreach (var stockItem in stockBlowPar)
			    {
				    var stockItemLevel = stockLevels.FirstOrDefault(i => i.StockItemId == stockItem.StockItemId);
				
				    var shoppingItem = BuildShoppingListItem(stockItemLevel, shoppingList.ShoppingListId);

				    shoppingItemList.Add(shoppingItem);
			    }

			    _db.ShoppingListItems.AddRange(shoppingItemList);
			    _db.SaveChanges();

			    return shoppingList;
		    }
		    catch (Exception e)
		    {
			    return null;
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

	    private Model.Shopping.ShoppingList GetShoppingList(int memberId)
	    {
		    var shoppingList = BuildShoppingList(memberId);

			_db.ShoppingLists.Add(shoppingList);
		    _db.SaveChanges();

		    return shoppingList;
	    }

		private ShoppingListItem BuildShoppingListItem(IStockLevel stock, int stockListId)
	    {
			return new ShoppingListItem
			{
				StockItemId = stock.StockItemId,
				IsCollected = false,
				Quantity =  stock.Quantity,
				ShoppingListId = stockListId
		    };
	    }
    }
}
