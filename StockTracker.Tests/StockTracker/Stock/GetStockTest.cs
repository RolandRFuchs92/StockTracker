using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Stock;
using StockTracker.BusinessLogic.Stock;
using StockTracker.Context;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;

namespace StockTracker.Test.StockTracker.Stock
{
	[TestClass]
	public class GetStockTest
	{
		private readonly IGetStockItem _getStock;
		private StockTrackerContext _db;
		private Mapper _map;


		public GetStockTest()
		{
			_db = TestDb.db;
			_map = AutoMapperConfig.Get();
			_getStock = new GetStockItem(_db, _map);
		}

		#region GetStockCheckedToday
		[TestMethod]
		public void GetStockCheckedToday_NothingToPass_ShouldReturnAList()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _getStock.GetStockCheckedToday(clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(List<StockItem>));
			Assert.IsTrue(result.Count > 0);
		}
		#endregion

		#region GetStockNotCheckedToDay

		[TestMethod]
		public void GetStockNotCheckedToday_NoParametersPassed_ReturnsAList()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _getStock.GetStockNotCheckedToday(clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
			Assert.IsInstanceOfType(result, typeof(List<StockItem>));

		}

		#endregion

		#region GetStockBelowPar
		[TestMethod]
		public void GetStockBelowPar_NoParametersPassed_ShouldReturnAListWithItemsBelowPar()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _getStock.GetStockBelowPar(clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(DoesStockMeetRequirement(result, IsBelow, false));
			Assert.IsInstanceOfType(result, typeof(List<StockItem>));

		}
		#endregion

		#region GetStockAbovePar
		[TestMethod]
		public void GetStockAbovePar_CantPassParams_ShouldReturnAListWithItemsAbovePar()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _getStock.GetStockAbovePar(clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(DoesStockMeetRequirement(result, IsAbove, true));
			Assert.IsInstanceOfType(result, typeof(List<StockItem>));
		}
		#endregion

		[TestMethod]
		public void GetAcceptableStock_PassClientId_ShouldReturnAValidList()
		{
			//Arrange
			var clientId = 1;

			//Act
			var result = _getStock.GetAcceptableStock(clientId);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
			Assert.IsInstanceOfType(result, typeof(List<StockItem>));
		}

		private bool DoesStockMeetRequirement(List<StockItem> stockItems, Func<bool, int, int, bool> check, bool isAbove)
		{
			var stockItemList = stockItems.Select(stockItem => stockItem.StockItemId);
			var stockItemParLevels = _db.StockLevels.Where(i => stockItemList.Contains(i.StockItemId)).ToList();
			var stockPars = _db.StockPars.Where(i => stockItemList.Contains(i.StockItemId)).ToList();

			foreach (var stockItem in stockItems)
			{
				var stockId = stockItem.StockItemId;
				var isToday = stockItem.DateCreated.ToString("d") == DateTime.Now.ToString("d");
				var goalPar = 0;
				if(isAbove)
					goalPar = stockPars.FirstOrDefault(i => i.StockItemId == stockId).MinStock;
				else 
					goalPar = (int)stockPars.FirstOrDefault(i => i.StockItemId == stockId).MaxStock;

				var currentPar = stockItemParLevels.FirstOrDefault(i => i.StockItemId == stockId).Quantity;

				if (!check(isToday, currentPar, goalPar))
					return false;
			}

			return true;
		}

		private bool IsBelow(bool isToday, int currentPar, int minPar)
		{
			return currentPar <= minPar && isToday;
		}

		private bool IsAbove(bool isToday, int currentPar, int maxPar)
		{
			return currentPar >= maxPar && isToday;
		}
	}
}