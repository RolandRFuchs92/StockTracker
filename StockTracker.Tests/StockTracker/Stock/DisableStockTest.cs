using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using StockTracker.Repository.Interface.BusinessLogic.Stock;

namespace StockTracker.Repository.Test.StockTracker.Stock
{
    public class DisableStockTest
    {
	    private readonly IDisableStock _disable;
	    private readonly StockTrackerContext _db;
	    public DisableStockTest(StockTrackerContext db)
	    {
		    _db = db;
	    }

		[TestMethod]
		public void Disable_PassedStockItem_ReturnTrueIfSuccess()
		{
			//Arrange
			var stockItemId = 1;
			var clientId = 1;
			var originalActiveItem = _db.StockPars.FirstOrDefault(i => i.StockItemId == stockItemId && i.ClientId == clientId);

			//Act
			var result = _disable.Disable(stockItemId, clientId);
			var updateItem = _db.StockPars.FirstOrDefault(i => i.StockItemId == stockItemId && i.ClientId == clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(StockLevel));
			Assert.IsTrue(result);
			Assert.IsTrue(originalActiveItem.IsActive != updateItem.IsActive);
		}

		[TestMethod]
		public void Disable_PassedAListOfStockItems_ShouldHaveDisabledAllItemsSpecified()
		{
			//Arrange
			var clientId = 1;
			var listOfStockLevels= _db.StockPars.Where(i => i.ClientId == clientId).ToList();
			var listOfStockIds = listOfStockLevels.Select(i => i.StockItemId).ToList();


			//Act
			var result = _disable.Disable(listOfStockIds, clientId);
			var updateListOfStocks = _db.StockPars.Where(i => i.ClientId == clientId).ToList();

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result);
			Assert.IsNull(updateListOfStocks.FirstOrDefault(i => i.IsActive));
		}


	    [TestMethod]
	    public void DisableByCategory_PassedAcategoryId_ResultListIsSetToInactive()
	    {
		    //Arrange
		    var clientId = 1;
		    var categoryId = 1;


		    //Act
		    var result = _disable.DisableByCategory(categoryId, clientId);
		    var updatedList = _db.StockPars.Where(i => i.ClientId == clientId && i.StockItem.StockCategoryId == categoryId).ToList();

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result);
			Assert.IsNull(updatedList.FirstOrDefault(i => i.IsActive).IsActive);
	    }

		[TestMethod]
		public void DisableByCategory_PassedInAListOfCategories_AllListsShouldBeDisabled()
		{
			//Arrange
			var clientId = 1;
			var categoryIds = new List<int> {1, 2, 3};
			//should add a constant list to the Db generator so that we can test specifics.

			//Act
			var result = _disable.DisableByCategory(categoryIds, clientId);
			var updatedList =
				_db.StockPars.Where(i => categoryIds.Contains(i.StockItem.StockCategoryId) && i.ClientId == clientId).Select(i => i.IsActive);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result);
			Assert.IsNull(updatedList.FirstOrDefault());
		}
    }
}
