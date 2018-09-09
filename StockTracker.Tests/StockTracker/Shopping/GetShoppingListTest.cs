using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;

namespace StockTracker.Test.StockTracker.Shopping
{
	[TestClass]
    public class GetShoppingListTest
    {
	    private StockTrackerContext _db;
	    private Mapper _map;
	    private IGetShoppingList _getShoppingList;

	    public GetShoppingListTest()
	    {
		    _db = TestDb.db;
		    _map = AutoMapperConfig.Get();
	    }


		[TestMethod]
		public void Get_PassedTheShoppingListId_ListOfShoppingItemsRelatedToListId()
		{
			//Arrange
			var shoppingListId = 1;

			//Act
			var result = _getShoppingList.Get(1);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(List<IShoppingListItem>));
			Assert.IsTrue(result.Count > 0);
		}

		[TestMethod]
		public void GetMember_PassedClientIdAndDate_GetAListOfShoppingListItems()
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
