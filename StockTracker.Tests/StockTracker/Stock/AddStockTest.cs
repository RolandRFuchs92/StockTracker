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
			var addStockCount = 0;
			var saveChangesCount = 0;
			var moq = new Mock<StockTrackerContext>();

			moq.Setup(stock => stock.StockItems.Add(It.IsAny<StockItem>())).Callback(() => addStockCount++);
			moq.Setup(stock => stock.SaveChanges()).Callback(() => saveChangesCount++);

			//Act
			var addStock = new AddStock(moq.Object,_map);
			var result = addStock.AddNew(SingleStockItem());


			//Assert
			moq.Verify(x => x.StockItems.Add(It.IsAny<StockItem>()), Times.Once);
			moq.Verify(x => x.SaveChanges(), Times.Once);

			Assert.IsTrue(result);
			Assert.AreEqual(1, addStockCount);
			Assert.AreEqual(1, saveChangesCount);
		}

		[TestMethod]
		public void AddNew_ListOfStockItems_GetATrueResult()
		{
			//Arrange
			var addStockCount = 0;
			var saveChangesCount = 0;

			var moq = new Mock<StockTrackerContext>();

			moq.Setup(stock => stock.StockItems.Add(It.IsAny<StockItem>())).Callback(() => addStockCount++);
			moq.Setup(stock => stock.SaveChanges()).Callback(() => saveChangesCount++);

			//Act
			var addStock = new AddStock(moq.Object, _map);
			var result = addStock.AddNew(SmallListOfStockItems());

			//Assert
			moq.Verify(x => x.StockItems.Add(It.IsAny<StockItem>()), Times.Exactly(2));
			moq.Verify(x => x.SaveChanges(), Times.Exactly(2));

			Assert.IsTrue(result == 0);
			Assert.AreEqual(addStockCount, 2);
			Assert.AreEqual(saveChangesCount, 2);
		}




	    private IStockItem SingleStockItem()
	    {
		    return new StockItem
		    {
			    IsActive = true,
			    DateCreated = DateTime.Now,
			    StockCategoryId = 1,
			    StockItemName = "Moon Juice",
			    StockItemPrice = 1000
			};
	    }

	    private List<IStockItem> SmallListOfStockItems()
	    {
		    var stockItems = new List<IStockItem>();

			stockItems.Add(SingleStockItem());
		    stockItems.Add(new StockItem
		    {
				IsActive = true,
				DateCreated = DateTime.Now,
				StockCategoryId = 2,
				StockItemName = "Camel Pie",
				StockItemPrice = 9999
		    });

		    return stockItems;
	    }
	}
}
