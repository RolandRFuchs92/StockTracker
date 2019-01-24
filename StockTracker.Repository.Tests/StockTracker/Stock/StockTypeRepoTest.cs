using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using StockTracker.Repository.Interface.Stock;
using StockTracker.Tests.Utils.Acts;
using StockTracker.Tests.Utils.Context;

namespace StockTracker.Repository.Test.StockTracker.Stock
{
	[TestClass]
	public class StockTypeRepoTest
	{
		private IStockTrackerContext _db;
		private readonly StockType _stockType;
		private const string _isValid = nameof(IStockTypeRepo.IsValid);
		private const string _edit = nameof(IStockTypeRepo.Edit);
		private const string _add = nameof(IStockTypeRepo.Add);
		private const string _list = nameof(IStockTypeRepo.List);

		public StockTypeRepoTest()
		{
			_stockType = new StockType { StockTypeName = "Shoes" };
		}

		#region Add
		[TestMethod]
		public void Add_NewObject_AddNewObjectLogSuccess()
		{
			// Arrange 
			var repo = GetRepo();

			//Act
			repo.CreateResult(_add, _stockType);
			var result = repo.Result as StockType;

			//Assert
			Assert.AreEqual(result.StockTypeName, _stockType.StockTypeName);
			Assert.AreNotEqual(result.StockTypeId, _stockType.StockTypeId);
			repo._loggerCheck.Success();
		}
		#endregion

		#region Edit
		[TestMethod]
		public void Edit_PassInvalidId_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var category = new StockCategory { StockCategoryId = 100, StockCategoryName = "failed" };

			//Act
			repo.CreateResult(_edit, category);
			var result = repo.Result;

			//Assert
			Assert.IsNull(result);
			repo._loggerCheck.Error();
		}

		[TestMethod]
		public void Edit_PassValidIdAndString_ReturnNewCategoryWithIdAndLogSuccess()
		{
			//Arrange
			var repo = GetRepo();

			//Act
			repo.CreateResult(_edit, _stockType);
			var result = repo.Result as StockType;

			//Assert
			Assert.AreNotEqual(result.StockTypeId, _stockType.StockTypeId);
			repo._loggerCheck.Success();
		}

		[TestMethod]
		public void Eidt_PassValidIdAndEmptyString_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var stockType = _stockType;
			stockType.StockTypeName = "";

			//Act
			repo.CreateResult(_edit, stockType);
			var result = repo.Result as StockCategory;

			//Assert
			Assert.IsNull(result);
			repo._loggerCheck.Error();
		}
		#endregion

		#region IsValid

		[TestMethod]
		public void IsValid_PassValidId_LogSuccessReturnTrue()
		{
			//Arrange
			var repo = GetRepo();
			const int categoryId = 1;

			//Act
			repo.CreateResult(_isValid, categoryId);
			var result = repo.Result;

			//Assert
			Assert.IsTrue(result);
			repo._loggerCheck.Success();
		}

		[TestMethod]
		public void IsValid_PassInvalidId_LogErrorReturnFalse()
		{
			//Arrange
			var repo = GetRepo();
			const int invalidCategoryId = 100;

			//Act
			repo.CreateResult(_isValid, invalidCategoryId);
			var result = repo.Result;

			//Assert
			Assert.IsFalse(result);
			repo._loggerCheck.Error();
		}

		#endregion

		#region List

		[TestMethod]
		public void List_PassNothing_OnlyGetListOfStockTypes()
		{
			//Arrange
			var repo = GetRepo();

			//Act
			repo.CreateResult(nameof(IStockTypeRepo.List));
			var result = repo.Result as List<IStockType>;

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.Count > 0);
		}
		#endregion

		Repo<StockType> GetRepo()
		{
			var repo = new Repo<StockType>();
			_db = repo.db;
			return repo;
		}
	}
}
