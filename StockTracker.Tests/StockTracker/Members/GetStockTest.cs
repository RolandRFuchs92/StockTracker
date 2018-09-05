using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.BusinessLogic.Interface.BusinessLogic;
using StockTracker.BusinessLogic.Interface.BusinessLogic.Stock;
using StockTracker.Context;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Test.StockTracker.Members
{
	public class GetStockTest
	{
		private readonly IGetStock _getStock;
		private StockTrackerContext _db;

		public GetStockTest()
		{
			_db = TestDb.db;
		}

		#region GetStockByStockItem

		[TestMethod]
		public void GetStockByStockItem_Passed1_GetSingleItem()
		{
			//Arrange
			var stockItemid = 1;

			//Act
			var result = _getStock.GetStockByStockItem(stockItemid);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IStockItem));
		}

		[TestMethod]
		public void GetStockByStockItem_Passed0_ShouldReturnNull()
		{
			//Arrange
			var stockItemId = 0;

			//Act
			var result = _getStock.GetStockByStockItem(stockItemId);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void GetStockByStockItem_Passed10000000_ReturnNull()
		{
			//Arrange
			var stockitemId = 10000000;

			//Act
			var result = _getStock.GetStockByStockItem(stockitemId);

			//Assert
			Assert.IsNull(result);
		}

		#endregion

		#region GetStockCheckedToday

		[TestMethod]
		public void GetStockCheckedToday_NothingToPass_ShouldReturnAList()
		{
			//Arrange


			//Act
			var result = _getStock.GetStockCheckedToday();

			//Assert

			if (result != null)
			{
				Assert.IsInstanceOfType(result, typeof(List<IStockLevel>));
				Assert.IsTrue(result.Count > 0);
			}
		}

		#endregion

		#region GetStockNotCheckedToDay

		[TestMethod]
		public void GetStockNotCheckedToday_NoParametersPassed_ReturnsAList()
		{
			//Arrange


			//Act
			var result = _getStock.GetStockNotCheckedToday();

			//Assert
			if (result != null)
			{
				Assert.IsTrue(result.Count > 0);
				Assert.IsInstanceOfType(result, typeof(List<IStockItem>));
			}
		}

		#endregion

		#region GetStockBelowPar
		[TestMethod]
		public void GetStockBelowPar_NotParametersPassed_ShouldReturnAList()
		{
			//Arrange


			//Act
			var result = _getStock.GetStockBelowPar();

			//Assert
			if (result != null)
			{
				Assert.IsTrue(result.Count > 0);
				Assert.IsInstanceOfType(result, typeof(List<IStockItem>));
			}
		}

		[TestMethod]
		public void GetStockBelowPar_NoParametersPassed_ShouldReturnAListWithItemsBelowPar()
		{
			//Arrange


			//Act
			var result = _getStock.GetStockBelowPar();

			//Assert
			if (result != null)
			{
				Assert.IsTrue(DoesStockMeetRequireMent(result, IsBelow));
				Assert.IsInstanceOfType(result, typeof(List<IStockItem>));
			}
		}
		#endregion

		#region GetStockAbovePar
		[TestMethod]
		public void GetStockAbovePar_CantPassParams_ShouldReturnAListWithItemsAbovePar()
		{
			//Arrange


			//Act
			var result = _getStock.GetStockAbovePar();

			//Assert
			if (result != null)
			{
				Assert.IsTrue(DoesStockMeetRequireMent(result, IsAbove));
				Assert.IsInstanceOfType(result, typeof(List<IStockItem>));
			}
		}

		[TestMethod]
		public void GetStockAbovePar_CantPassParams_ShouldReturnAList()
		{
			//Arrange


			//Act
			var result = _getStock.GetStockAbovePar();

			//Assert
			if (result != null)
			{
				Assert.IsTrue(result.Count > 0);
				Assert.IsInstanceOfType(result, typeof(List<IStockItem>));
			}
		}
		#endregion

		private bool DoesStockMeetRequireMent(List<IStockItem> stockItems, Func<bool, int, int, bool> check)
		{
			var stockItemList = stockItems.Select(stockItem => stockItem.StockItemId);
			var stockItemParLevels = _db.StockLevels.Where(i => stockItemList.Contains(i.StockItemId)).ToList();
			var stockPars = _db.StockPars.Where(i => stockItemList.Contains(i.StockItemId)).ToList();

			foreach (var stockItem in stockItems)
			{
				var stockId = stockItem.StockItemId;
				var isToday = stockItem.DateCreated.ToString("d") == DateTime.Now.ToString("d");
				var goalPar = stockPars.FirstOrDefault(i => i.StockItemId == stockId).MinStock;
				var currentPar = stockItemParLevels.FirstOrDefault(i => i.StockItemId == stockId).Quantity;

				if (!check(isToday, goalPar, currentPar))
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