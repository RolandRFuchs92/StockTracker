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
		public void AddNew_PassedValidStockItem_ReturnTrue()
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

		[TestMethod]
		public void Add_AddedNewSingleItem_ReturnTrueAndSaveChangesWasSuccess()
		{
			//Arrange
			var addStockCount = 0;
			var saveChangesCount = 0;

			var moq = new Mock<StockTrackerContext>();

			moq.Setup(stock => stock.StockLevels.Add(It.IsAny<StockLevel>())).Callback(() => addStockCount++);
			moq.Setup(stock => stock.SaveChanges()).Callback(() => saveChangesCount++);

			//Act
			var addStock = new AddStock(moq.Object, _map);
			var result = addStock.Add(singleStockLevel());

			//Assert
			moq.Verify(x => x.StockLevels.Add(It.IsAny<StockLevel>()), Times.Exactly(1));
			moq.Verify(x => x.SaveChanges(), Times.Exactly(1));

			Assert.IsTrue(result);
			Assert.AreEqual(addStockCount, 1);
			Assert.AreEqual(saveChangesCount, 1);
		}

	    [TestMethod]
	    public void Add_AddedNewList_ReturnTrueAndSaveChangesWasSuccess()
	    {
		    //Arrange
		    var addStockCount = 0;
		    var saveChangesCount = 0;

		    var moq = new Mock<StockTrackerContext>();

		    moq.Setup(stock => stock.StockLevels.Add(It.IsAny<StockLevel>())).Callback(() => addStockCount++);
		    moq.Setup(stock => stock.SaveChanges()).Callback(() => saveChangesCount++);

		    //Act
		    var addStock = new AddStock(moq.Object, _map);
		    var result = addStock.Add(SmallListOfStockLevels());

		    //Assert
		    moq.Verify(x => x.StockLevels.Add(It.IsAny<StockLevel>()), Times.Exactly(2));
		    moq.Verify(x => x.SaveChanges(), Times.Exactly(2));

		    Assert.IsTrue(result == 0);
		    Assert.AreEqual(addStockCount, 2);
		    Assert.AreEqual(saveChangesCount, 2);
	    }

		[TestMethod]
		public void AddCategory_AddedSingleCategoryToClient_ReturnTrue()
		{
			//Arrange
			var addStock = new AddStock(_db, _map);

			//Act
			var result = addStock.AddCategory(1, 1);

			//Assert
			Assert.IsTrue(result);
		}

	    [TestMethod]
	    public void AddCategory_AddedListOfCategoryToClient_ReturnTrue()
	    {
		    //Arrange
		    var addStock = new AddStock(_db, _map);

		    //Act
		    var result = addStock.AddCategory(new List<int> { 1, 2, 3 }, 1);

		    //Assert
		    Assert.IsTrue(result);
	    }

	    [TestMethod]
	    public void CopyFromClient_client1To2_ShouldReturnTrue()
	    {
		    //Arrange

		    //Act
		    var result = _addStock.CopyFromClient(1, 2);

		    //Assert
		    Assert.IsTrue(result);
	    }

		[TestMethod]
		public void CopyFromClient_client1To2List_ShouldReturnTrue()
		{
			//Arrange
			
			//Act
			var result = _addStock.CopyFromClient(1, new List<int> { 1, 2, 3 });

			//Assert
			Assert.IsTrue(result > 0);
		}

	    [TestMethod]
	    public void EnableAllOldStock_PassedClientId_ShouldReturnTrue()
	    {
		    //Arrange
		

		    //Act
		    var result = _addStock.EnableAllOldStock(1);

		    //Assert
		    Assert.IsTrue(result);
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

	    private IStockLevel singleStockLevel()
	    {
		    return new StockLevel
		    {
				ClientId = 1,
				DateChecked = DateTime.Now,
				MemberId = 1,
				Quantity = 100,
				StockItemId = 1
		    };
	    }

	    private List<IStockLevel> SmallListOfStockLevels()
	    {
		    var stockLevels = new List<IStockLevel>();

			stockLevels.Add(singleStockLevel());
		    stockLevels.Add(new StockLevel
		    {
				MemberId = 2,
				ClientId = 2,
				DateChecked = DateTime.Now,
				Quantity = 5,
				StockItemId = 2
		    });

		    return stockLevels;
	    }
	}
}
