using System;
using System.Collections.Generic;
using System.Linq;
using StockTracker.Context;
using StockTracker.Extensions;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Repository.Interface.BusinessLogic.Shopping;

namespace StockTracker.Repository.ShoppingListLogic
{
	public class GetShoppingList : IGetShoppingList
	{
		private StockTrackerContext _db;

		public GetShoppingList(StockTrackerContext db)
		{
			_db = db;
		}

		public List<IShoppingListItem> Get(int shoppingListId)
		{
			return (from item in _db.ShoppingListItems
					where item.ShoppingListId == shoppingListId
					select item).ToList<IShoppingListItem>();
		}

		public List<IShoppingListItem> Get(int clientId, DateTime date)
		{
			var midnightDate = date.Time(0, 0, 1);
			return (from item in _db.ShoppingListItems
				join shoppingList in _db.ShoppingLists
					on item.ShoppingListId equals shoppingList.ShoppingListId
				join member in _db.Members
					on shoppingList.MemberId equals member.MemberId
				where member.ClientId == clientId
					  && shoppingList.DateCreated > midnightDate
				select item).ToList<IShoppingListItem>();
		}

		public List<IShoppingListItem> GetMemberShoppingList(int memberId, DateTime date)
		{
			var midnightDate = date.Time(0, 0, 1);
			return (from item in _db.ShoppingListItems
				join shoppingList in _db.ShoppingLists
					on item.ShoppingListId equals shoppingList.ShoppingListId
				where shoppingList.MemberId == memberId
				      && shoppingList.DateCreated > midnightDate
				select item).ToList<IShoppingListItem>();
		}
	}
}
