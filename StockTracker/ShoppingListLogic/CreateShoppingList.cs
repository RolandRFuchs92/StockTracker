using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
		private IGetClient _client;

		public CreateShoppingList(StockTrackerContext db,  IGetClient client)
		{
			_db = db;
			_client = client;
		}


		public IShoppingList HighPriorityList(int memberId)
		{
			var clientId = _client.GetClientByMember(memberId).ClientId;
			var shoppingList = GetShoppingList(memberId);

			try
			{
				var shoppingListId = shoppingList.ShoppingListId;
				var today = DateTime.Today;

				var shoppingItemList = (from stockItem in _db.StockItems
										join stockPar in _db.StockPars
											on stockItem.StockItemId equals stockPar.StockItemId
										join stockLevel in _db.StockLevels
											on stockItem.StockItemId equals stockLevel.StockItemId
										where stockLevel.DateChecked > today
											  && stockLevel.ClientId == clientId
											  && stockLevel.Quantity < stockPar.MinStock
											  && stockPar.IsActive
										select new ShoppingListItem
										{
											StockItemId = stockItem.StockItemId,
											IsCollected = false,
											ShoppingListId = shoppingListId,
											Quantity = stockLevel.Quantity - stockPar.MinStock
										}).ToList();

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
    }
}
