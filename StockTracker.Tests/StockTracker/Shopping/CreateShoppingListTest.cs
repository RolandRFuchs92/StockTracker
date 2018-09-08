using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping;
using StockTracker.Context;
using StockTracker.Model.Shopping;

namespace StockTracker.Test.StockTracker.Shopping
{
    public class CreateShoppingListTest
    {
	    private StockTrackerContext _db;
	    private Mapper _map;
	    private ICreateShoppingList _createShoppingList;

	    public CreateShoppingListTest()
	    {
		    _db = TestDb.db;
		    _map = AutoMapperConfig.Get();
	    }

		[TestMethod]
		public void GenerateShoppingList_PassClientId_ExpectANewShoppingList()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _createShoppingList.GenerateShoppingList(clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(ShoppingList));
		}


    }
}
