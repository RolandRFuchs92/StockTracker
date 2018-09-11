using System;
using System.Linq;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock.DTO;
using StockTracker.Repository.Interface.BusinessLogic.Clients;
using StockTracker.Repository.Interface.BusinessLogic.Shopping;

namespace StockTracker.Repository.ShoppingListLogic
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
			var shoppingList = GetShoppingList(memberId);

			try
			{
				var shoppingListId = shoppingList.ShoppingListId;
				var query = StockQuery(memberId);
				var shoppingItemList = (from stock in query
										where stock.MinStock > stock.Quantity
										select new ShoppingListItem
										{
											StockItemId = stock.StockItemId,
											IsCollected = false,
											ShoppingListId = shoppingListId,
											Quantity = stock.MinStock - stock.Quantity
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

		public IShoppingList LowPriorityList(int memberId)
		{
			try
			{
				var shoppingList = GetShoppingList(memberId);
				var query = StockQuery(memberId);
				var shoppingListItemList = (from stock in query
											where stock.MaxStock > stock.Quantity
											select new ShoppingListItem
											{
												StockItemId = stock.StockItemId,
												IsCollected = false,
												Quantity = stock.MaxStock - stock.Quantity,
												ShoppingListId = shoppingList.ShoppingListId
											}).ToList();

				_db.ShoppingListItems.AddRange(shoppingListItemList);
				_db.SaveChanges();

				return shoppingList;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public IShoppingList OutStandingShoppingList(int clientId)
		{
			throw new NotImplementedException();
		}

		private ShoppingList BuildShoppingList(int memberId)
		{
			return new ShoppingList
			{
				MemberId = memberId,
				DateCreated = DateTime.Now,
				HasNotified = false,
			};
		}

		private ShoppingList GetShoppingList(int memberId)
		{
			var shoppingList = BuildShoppingList(memberId);

			_db.ShoppingLists.Add(shoppingList);
			_db.SaveChanges();

			return shoppingList;
		}

		private IQueryable<StockDTO> StockQuery(int memberId)
		{
			var clientId = _client.GetClientByMember(memberId).ClientId;
			var today = DateTime.Today;

			return from stockItem in _db.StockItems
					join stockPar in _db.StockPars
						on stockItem.StockItemId equals stockPar.StockItemId
					join stockLevel in _db.StockLevels
						on stockItem.StockItemId equals stockLevel.StockItemId
					where stockLevel.DateChecked > today
						  && stockLevel.ClientId == clientId
						  && stockPar.IsActive
					select new StockDTO
					{
						StockItemId = stockItem.StockItemId,
						IsActive = stockPar.IsActive,
						ClientId = stockLevel.ClientId,
						MemberId = stockLevel.MemberId,
						MinStock = stockPar.MinStock,
						MaxStock = stockPar.MaxStock,
						Quantity = stockLevel.Quantity,
						DateSet = stockPar.DateSet,
						DateChecked = stockLevel.DateChecked,
						StockCategoryId = stockItem.StockCategoryId,
						DateCreated = stockItem.DateCreated,
						StockItemName = stockItem.StockItemName,
						StockItemPrice = stockItem.StockItemPrice,
						StockLevelId = stockLevel.StockLevelId,
						StockParId = stockPar.StockParId
					};
		}
    }
}
