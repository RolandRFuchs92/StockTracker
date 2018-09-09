using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Clients;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping;
using StockTracker.BusinessLogic.ShoppingList;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Clients;
using StockTracker.Model.Shopping;

namespace StockTracker.Test.StockTracker.Shopping
{
	[TestClass]
    public class CreateShoppingListTest
    {
	    private StockTrackerContext _db;
	    private Mapper _map;
	    private ICreateShoppingList _createShoppingList;

	    public CreateShoppingListTest()
	    {
		    _db = TestDb.db;
		    _map = AutoMapperConfig.Get();
		    var client = Client();
			_createShoppingList = new CreateShoppingList(_db, client);
	    }

	    private IGetClient Client()
	    {
		    var moqClient = new Mock<IGetClient>();
		    moqClient.Setup(i => i.GetClientByMember(It.IsAny<int>())).Returns(new Client
		    {
				ClientId = 1,
				IsActive = true,
				Address = "2 moo cow paddock",
				ClientName = "Dairy Bell",
				ContactNumber = "123",
				CreatedOn = DateTime.Now,
				LastCheckup = DateTime.Now,
				email = "cow@moo.com"
		    });

		    return moqClient.Object;
	    }

		[TestMethod]
		public void HighPriorityList_PassClientId_ExpectANewShoppingList()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _createShoppingList.HighPriorityList(clientId);
			var isBelowMin = MeetsRequirements(result, true);
			
			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
			Assert.IsTrue(isBelowMin);
		}


		[TestMethod]
		public void LowPriorityList_PassedInFirstShoppingList_ShouldReturnValidShoppingList()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _createShoppingList.HighPriorityList(clientId);
			var isBelowMax = MeetsRequirements(result, false);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
			Assert.IsTrue(isBelowMax);
		}

		[TestMethod]
		public void OutStandingShoppingList_PassedClientId1_ListOfOutstandingStockItemsNoOlderThan1Week()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _createShoppingList.OutStandingShoppingList(clientId);
			var isBelowMax = MeetsRequirements(result, false);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
			Assert.IsTrue(isBelowMax);
		}

	    private List<IShoppingListItem> GetShoppingList(IShoppingList listRef)
	    {
		    return _db.ShoppingListItems.Where(i => i.ShoppingListId == listRef.ShoppingListId).ToList<IShoppingListItem>();
	    }

	    private List<IStockLevel> GetStockLevels(List<IShoppingListItem> shoppingListItems)
	    {
		    var stockIdList = shoppingListItems.Select(i => i.StockItemId).ToList();
		    return _db.StockLevels.Where(i => stockIdList.Contains(i.StockItemId)).ToList<IStockLevel>();
	    }

	    private List<IStockPar> GetStockPar(List<IShoppingListItem> listRef)
	    {
		    var stockIdList = listRef.Select(i => i.StockItemId);
		    return _db.StockPars.Where(i => stockIdList.Contains(i.StockItemId)).ToList<IStockPar>();
	    }

	    private bool MeetsRequirements(IShoppingList listRef, bool isAboveMin)
	    {
		    var shoppingList = GetShoppingList(listRef);
		    var stockLevls = GetStockLevels(shoppingList);
		    var stockPars = GetStockPar(shoppingList);

		    foreach (var item in shoppingList)
		    {
			    var stockLevel = stockLevls.FirstOrDefault(i => i.StockItemId == item.StockItemId);
			    var stockPar = stockPars.FirstOrDefault(i => i.StockItemId == item.StockItemId);

			    if (isAboveMin && stockLevel.Quantity > stockPar.MinStock)
				    return false;
				if (!isAboveMin && stockLevel.Quantity < stockPar.MaxStock)
				    return false;
		    }

		    return true;
	    }

    }
}
