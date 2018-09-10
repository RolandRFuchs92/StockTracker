using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping;
using StockTracker.BusinessLogic.ShoppingListLogic;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;

namespace StockTracker.Test.StockTracker.Shopping
{
	[TestClass]
	public class UpdateShoppingListTests
	{
		private StockTrackerContext _db;
		private IUpdateShoppingList _updateShoppingList;

		public UpdateShoppingListTests()
		{
			_db = TestDb.db;
			_updateShoppingList = new UpdateShoppingList(_db);
		}
		//BusinesRule: If only items that the client is connected to can be added to their list... we need to implement this.

		[TestMethod]
		public void Add_PassedShoppingListItemIdAndStockItem_ReturnIshoppingListRef()
		{
			//Arrange
			var shoppingListId = 1;
			var stockItemId = 1;
			var quantity = 1000;

			//Act
			var result = _updateShoppingList.Add(shoppingListId, stockItemId, quantity);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
		}

		[TestMethod]
		public void Add_PassedListOfItemsReffedSingleItem_ReturnShoppingListRef()
		{
			//Arrange
			var shoppingListId = 1;
			var quantity = 1000;
			var currentShoppingList = _db.ShoppingListItems.Where(i => i.ShoppingListItemId == shoppingListId).ToList();

			var newShoppingItems = GenerateNewShoppingListTuple(currentShoppingList.Select(i => i.ShoppingListItemId).ToList());

			//Act
			var result = _updateShoppingList.Add(shoppingListId, newShoppingItems);
			var added = _db.ShoppingListItems.FirstOrDefault(i => i.ShoppingListId == shoppingListId && i.Quantity == quantity);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
			Assert.IsTrue(added != null);
		}

		[TestMethod]
		public void Remove_RemovedItemFromShoppingList_ShouldHaveDeletedAnItemFromShoppingList()
		{
			//Arrange
			var shoppingListId = 1;
			var shoppingListRef = _db.ShoppingLists.FirstOrDefault(i => i.ShoppingListId == shoppingListId);
			var originalList = _db.ShoppingListItems.Where(i => i.ShoppingListId == shoppingListRef.ShoppingListId).ToList();
			var stockItemId = originalList.FirstOrDefault().StockItemId;

			//Act
			var result = _updateShoppingList.Remove(shoppingListRef.ShoppingListId, stockItemId);
			var updatedList = _db.ShoppingListItems.Where(i => i.ShoppingListId == shoppingListRef.ShoppingListId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
			Assert.IsTrue(originalList.Count > updatedList.Count());
		}

		[TestMethod]
		public void Remove_PassedShoppingListRefAndAddedAListOfItemsToBeremoved_ShouldReturnAListExcludingReffedItems()
		{
			//Arrange
			var shoppingListId = 1;
			var shoppingListRef = _db.ShoppingLists.FirstOrDefault(i => i.ShoppingListId == shoppingListId);
			var originalList = _db.ShoppingListItems.Where(i => i.ShoppingListId == shoppingListId).ToList();
			var stockItemIds = originalList.Take(2).Select(i => i.StockItemId).ToList();

			//Act
			var result = _updateShoppingList.Remove(shoppingListRef.ShoppingListId, stockItemIds);
			var updatedList = _db.ShoppingListItems.Where(i => i.ShoppingListId == shoppingListRef.ShoppingListId).ToList();

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
			Assert.IsTrue(originalList.Count > updatedList.Count);
		}

		[TestMethod]
		public void Update_PassedShoppingListItemIdWithStockItemRefAndNewStockitem_ReturnShoppingListRef()
		{
			//Arrange
			var shoppingListId = 1;
			var shoppingListRef = _db.ShoppingLists.FirstOrDefault(i => i.ShoppingListId == shoppingListId);
			var originalList = _db.ShoppingListItems.Where(i => i.ShoppingListId == shoppingListRef.ShoppingListId).ToList();
			var originalShoppingItemIds = originalList.Select(i => i.ShoppingListId).ToList();
			var originShoppingItemId = originalList.FirstOrDefault(i => i.ShoppingListId == shoppingListId).ShoppingListId;
			var newShoppingItemId = GetNewShoppingListId(originalShoppingItemIds);

			//Act
			var result = _updateShoppingList.Update(shoppingListId, originShoppingItemId, newShoppingItemId);
			var newShoppingList = _db.ShoppingListItems.Where(i => i.ShoppingListId == shoppingListRef.ShoppingListId).ToList();

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
			Assert.IsTrue(IsIdenticalLists(originalList, newShoppingList));
		}

		private int GetNewShoppingListId(List<int> originalShoppingListId)
		{
			var newShoppingItemId = 1;
			while(originalShoppingListId.Contains(newShoppingItemId))
			{
				newShoppingItemId++;
			}

			return newShoppingItemId;
		}

		private bool IsIdenticalLists(List<ShoppingListItem> originalList, List<ShoppingListItem> updateList)
		{
			var difference = originalList.Except(updateList).Count();
			if (difference == 0)
				return true;
			return false;
		}

		private List<Tuple<int, int>> GenerateNewShoppingListTuple(List<int> CurrentShoppingList)
		{
			var newShoppingList = new List<int>(); 
			newShoppingList = CurrentShoppingList;

			var newTuppleList = new List<Tuple<int, int>>();
			newTuppleList.Add(new Tuple<int, int>(GetNewShoppingListId(newShoppingList),100));
			newTuppleList.Add(new Tuple<int, int>(GetNewShoppingListId(newShoppingList),100));
			newTuppleList.Add(new Tuple<int, int>(GetNewShoppingListId(newShoppingList),100));

			return newTuppleList;
		}
	}
}
