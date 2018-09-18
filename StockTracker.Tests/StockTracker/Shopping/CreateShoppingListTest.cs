using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Context;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Clients;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;
using StockTracker.Repository.Interface.BusinessLogic.Clients;
using StockTracker.Repository.Interface.BusinessLogic.Shopping;
using StockTracker.Repository.ShoppingListLogic;

namespace StockTracker.Repository.Test.StockTracker.Shopping
{
	[TestClass]
	public class CreateShoppingListTest
	{
		private StockTrackerContext _db;
		private Mapper _map;
		private ICreateShoppingList _createShoppingList;

		public CreateShoppingListTest()
		{
			_db = new TestDb().Db;
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
			var isBelowMin = MeetsRequirements(result, clientId, true);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
			Assert.IsTrue(isBelowMin, "Result may not have been below the minimum");
		}


		[TestMethod]
		public void LowPriorityList_PassedInFirstShoppingList_ShouldReturnValidShoppingList()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _createShoppingList.LowPriorityList(clientId);
			var isBelowMax = MeetsRequirements(result, clientId, false);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IShoppingList));
			Assert.IsTrue(isBelowMax);
		}

		private List<ShoppingListItem> GetShoppingList(ShoppingList listRef)
		{
			return _db.ShoppingListItems.Where(i => i.ShoppingListId == listRef.ShoppingListId).ToList<ShoppingListItem>();
		}

		private List<StockLevel> GetStockLevels(List<ShoppingListItem> shoppingListItems, int clientId)
		{
			var stockIdList = shoppingListItems.Select(i => i.StockItemId).ToList();
			return _db.StockLevels.Where(i => stockIdList.Contains(i.StockPar.StockItemId) && i.Member.ClientId == clientId).ToList<StockLevel>();
		}

		private List<StockPar> GetStockPar(List<ShoppingListItem> listRef, int clientId)
		{
			var stockIdList = listRef.Select(i => i.StockItemId);
			return _db.StockPars.Where(i => stockIdList.Contains(i.StockItemId) && i.ClientId == clientId).ToList<StockPar>();
		}

		private bool MeetsRequirements(ShoppingList listRef, int clientId,  bool isBelowMin)
		{
			var shoppingList = GetShoppingList(listRef);
			var stockLevls = GetStockLevels(shoppingList, clientId);
			var stockPars = GetStockPar(shoppingList, clientId);

			foreach (var item in shoppingList)
			{
				var stockLevel = stockLevls.FirstOrDefault(i => i.StockPar.StockItemId == item.StockItemId);
				var stockPar = stockPars.FirstOrDefault(i => i.StockItemId == item.StockItemId);

				if (isBelowMin && stockLevel.Quantity > stockPar.MinStock)
					return false;
				if (!isBelowMin && stockLevel.Quantity > stockPar.MaxStock)
					return false;
			}

			return true;
		}

		public void ClassCleanup()
		{
			_db.Dispose();
		}

	}
}
