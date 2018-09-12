using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Repository.Interface.BusinessLogic.Shopping;
using StockTracker.Repository.ShoppingListLogic;

namespace StockTracker.Repository.Test.StockTracker.Shopping
{
	[TestClass]
    public class GetShoppingListTest
    {
	    private StockTrackerContext _db;
	    private Mapper _map;
	    private IGetShoppingList _getShoppingList;

	    public GetShoppingListTest()
	    {
		    _db = new TestDb().Db;
		    _map = AutoMapperConfig.Get();
			_getShoppingList = new GetShoppingList(_db);
	    }


		[TestMethod]
		public void Get_PassedTheShoppingListId_ListOfShoppingItemsRelatedToListId()
		{
			//Arrange
			var shoppingListId = 1;

			//Act
			var result = _getShoppingList.Get(shoppingListId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(List<IShoppingListItem>));
			Assert.IsTrue(result.Count > 0,"Returned 0, should be more.");
		}

		[TestMethod]
		public void Get_PassedClientIdAndDate_GetAListOfShoppingListItems()
		{
			//Arrange
			var clientId = 1;
			var dateTime = DateTime.Now;

			//Act
			var result = _getShoppingList.Get(clientId, dateTime);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(List<IShoppingListItem>));
			Assert.IsTrue(result.Count > 0);
		}

		[TestMethod]
		public void GetMemberShoppingList_PassedMemberIdAndDate_GetAListOfShoppingListItems()
		{
			//Arrange
			var memberId = 1;
			var dateTime = DateTime.Now;

			//Act
			var result = _getShoppingList.GetMemberShoppingList(memberId, dateTime);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(List<IShoppingListItem>));
			Assert.IsTrue(result.Count > 0);
		}

    }
}
