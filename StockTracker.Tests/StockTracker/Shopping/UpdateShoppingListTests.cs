using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;

namespace StockTracker.Test.StockTracker.Shopping
{
	public class UpdateShoppingListTests
	{
		private StockTrackerContext _db;
		private IUpdateShoppingList _updateShoppingList;

		public UpdateShoppingListTests()
		{
			_db = TestDb.db;
		}


		//BusinesRule: If only items that the client is connected to can be added to their list... we need to implement this.

		[TestMethod]
		public void Add_PassedShoppingListItemIdAndStockItem_ReturnIshoppingListRef()
		{
			//Arrange
			var shoppingListId = 1;
			var stockItemId = 1;

			//Act
			var result = _updateShoppingList.Add(shoppingListId, stockItemId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
		}

		[TestMethod]
		public void Add_PassedListOfItemsReffedSingleItem_ReturnShoppingListRef()
		{
			//Arrange
			var shoppingListItemIds = new List<int> {1, 2, 3, 4};
			var shoppingListId = 1;

			//Act
			var result = _updateShoppingList.Add(shoppingListId, shoppingListItemIds);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
		}
	}
}
