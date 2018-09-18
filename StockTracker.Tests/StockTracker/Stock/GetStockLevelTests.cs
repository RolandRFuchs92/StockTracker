using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context;
using StockTracker.Interface.Models.Stock;
using StockTracker.Repository.Interface.BusinessLogic.Stock;
using StockTracker.Repository.Stock;

namespace StockTracker.Repository.Test.StockTracker.Stock
{
	[TestClass]
    public class GetStockLevelTests
    {
	    private IGetStockLevel _stocklevel;
	    private StockTrackerContext _db;

	    public GetStockLevelTests()
	    {
			_db = new TestDb().Db;
			_stocklevel = new GetStockLevel(_db);
	    }


		[TestMethod]
		public void Get_PassedStockIdAndClientId_GotStocklevel()
		{
			//Arrange
			var stockItemid = 1;
			var clientId = 1;

			//Act
			var result = _stocklevel.Get(stockItemid, clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IStockLevel));
			Assert.IsTrue(result.StockPar.ClientId == clientId && result.StockPar.StockItemId == stockItemid);
		}

		[TestMethod]
		public void Get_PassedAListOfStockItems_GotAListRelatedToThePassedParams()
		{
			//Arrange
			var clientId = 1;
			var stockItemIds = new List<int> {1, 2, 3};

			//Act
			var result = _stocklevel.Get(stockItemIds, clientId);
			var compareListLength = _db.StockLevels.Count(i => stockItemIds.Contains(i.StockPar.StockItemId) && i.StockPar.ClientId == clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(compareListLength == result.Count);
			Assert.IsInstanceOfType(result, typeof(List<IStockLevel>));
		}

		[TestMethod]
		public void GetbyCategoryId_PassedACategoryIdAndAClientId_GetAListThatCorespondsWithTheParamsPassed()
		{
			//Arrange
			var clientId = 1;
			var categoryId = 1;

			//Act
			var result = _stocklevel.GetByCategoryId(categoryId, clientId);
			var length = _db.StockLevels.Count(i => i.StockPar.ClientId == clientId && categoryId == i.StockPar.StockItem.StockCategoryId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count == length);
			Assert.IsInstanceOfType(result, typeof(List<IStockLevel>));
		}

		[TestMethod]
		public void GetCategoryById_PassedAListOfCategoriesAndAclientId_GetAListThatCorespondsWithTheParamsPased()
		{
			//Arrange
			var clientId = 1;
			var categoryIds = new List<int> {1, 2, 3};

			//Act
			var result = _stocklevel.GetByCategoryId(categoryIds, clientId);
			var length = _db.StockLevels.Count(i => categoryIds.Contains(i.StockPar.StockItem.StockCategoryId) && i.StockPar.ClientId == clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count == length);
			Assert.IsInstanceOfType(result, typeof(List<IStockLevel>));
		}

    }
}
