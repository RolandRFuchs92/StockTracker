using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context;
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
			var originalActiveItem = _db.StockLevels.FirstOrDefault(i => i.StockItemId == stockItemId && i.ClientId == clientId);

			//Act
			var result = _disable.Disable(stockItemId, clientId);
			var updateItem = _db.StockLevels.FirstOrDefault(i => i.StockItemId == stockItemId && i.ClientId == clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(StockLevel));
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void UoW_InitialCondition_ExpectedResult()
		{
			//Arrange


			//Act


			//Assert

		}
    }
}
