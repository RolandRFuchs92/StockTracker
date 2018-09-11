using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context;
using StockTracker.Interface.Models.Stock;
using StockTracker.Repository.Interface.BusinessLogic.Stock;

namespace StockTracker.Repository.Test.StockTracker.Stock
{
    public class GetStockLevelTests
    {
	    private IGetStockLevel _stocklevel;
	    private StockTrackerContext _db;

	    public GetStockLevelTests()
	    {
		    _db = TestDb.db;
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
			Assert.IsTrue(result.ClientId == clientId && result.StockItemId == stockItemid);
		}

		[TestMethod]
		public void Get_PassedAListOfStockItems_GotAListRelatedToThePassedParams()
		{
			//Arrange
			var clientId = 1;
			var stockItemIds = new List<int> {1, 2, 3};

			//Act
			var result = _stocklevel.Get(stockItemIds, clientId);
			var compareListLength = _db.StockLevels.Count(i => stockItemIds.Contains(i.StockItemId) && i.ClientId == clientId);

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
			var length = _db.StockLevels.Count(i => i.ClientId == clientId && categoryId == i.StockItem.StockCategoryId);

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
			var length = _db.StockLevels.Count(i => categoryIds.Contains(i.StockItem.StockCategoryId) && i.ClientId == clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count == length);
			Assert.IsInstanceOfType(result, typeof(List<IStockLevel>));
		}

    }
}
