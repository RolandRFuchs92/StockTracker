using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context;
using StockTracker.Model.Stock;
using AutoMapper;
using Moq;
using StockTracker.BusinessLogic.AutoMapper;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Stock;
using StockTracker.BusinessLogic.Stock;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Test.StockTracker.Stock
{
	[TestClass]
    public class AddStockTest
    {
	    private StockTrackerContext _db;
	    private IMapper _map;
	    private IAddStock _addStock;

	    public AddStockTest()
	    {
		    _db = TestDb.db;
		    _map = AutoMapperConfig.Get();
		    _addStock = new AddStock(_db, _map);
	    }

		[TestMethod]
		public void AddStock_PassedValidStockItem_ReturnTrue()
		{
			//Arrange
			var stockItem = new StockItem
			{
				IsActive = true,
				DateCreated = DateTime.Now,
				StockCategoryId =  1,
				StockItemName = "Moon Juice",
				StockItemPrice	= 1000
			};

			var addStockCount = 0;
			var saveChangesCount = 0;

			var moq = new Mock<StockTrackerContext>();

			moq.Setup(stock => stock.StockItems.Add(It.IsAny<StockItem>())).Callback(() => addStockCount++);
			moq.Setup(stock => stock.SaveChanges()).Callback(() => saveChangesCount++);


			//Act
			var addStock = new AddStock(moq.Object,_map);
			var result = addStock.AddNew(stockItem);


			//Assert
			moq.Verify(x => x.StockItems.Add(It.IsAny<StockItem>()), Times.Once);
			moq.Verify(x => x.SaveChanges(), Times.Once);

			Assert.IsTrue(result);
			Assert.AreEqual(1, addStockCount);
			Assert.AreEqual(1, saveChangesCount);
		}
	}
}
