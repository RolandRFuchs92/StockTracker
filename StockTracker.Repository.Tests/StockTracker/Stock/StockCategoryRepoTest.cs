using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using StockTracker.Repository.Interface.Stock;
using StockTracker.Repository.Stock;
using StockTracker.Tests.Utils.AbstractClasses;

namespace StockTracker.Repository.Test.StockTracker.Stock
{
	[TestClass]
	public class StockCategoryRepoTest : TestUtils<StockCategoryRepo>
	{
		private const string _add = nameof(IStockCategoryRepo.Add);
		private const string _edit = nameof(IStockCategoryRepo.Edit);
		private const string _List = nameof(IStockCategoryRepo.List);
		private const string _isValid = nameof(IStockCategoryRepo.IsValid);


		#region Add
		[TestMethod]
		public void Add_PassNewName_CreateNewResultLogInfo()
		{
			//Arrange
			var repo = GetRepo();

			//Act
			repo.CreateResult(_add, "NewTestCategory");

			//Assert
			AssertIsNotNullLogSuccess<IStockCategory>();
		}

		[TestMethod]
		public void Add_PassAlreadyUsedName_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();

			//Act
			repo.CreateResult(_add, "Meat");

			//Assert
			AssertIsNullLogError<IStockCategory>();
		}

		[TestMethod]
		public void Add_PassEmptyString_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();

			//Act
			repo.CreateResult(_add, "");

			//Assert
			AssertIsNullLogError<IStockCategory>();
		}
		#endregion

		#region Edit
		[TestMethod]
		public void Edit_PassNewNameWithId_ReturnNewResulWithSameIdLogSuccess()
		{
			//Arrange
			var repo = GetRepo();
			var category = CreateStockCategory(1, "FruitAndVegies");

			//Act
			repo.CreateResult(_edit, category);

			//Assert
			AssertSameLogSuccess(category);
		}

		[TestMethod]
		public void Edit_PassNewNameWithNoId_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var category = CreateStockCategory();

			//Act
			repo.CreateResult(_edit, category);

			//Assert
			AssertIsNullLogError<IStockCategory>();
		}

		[TestMethod]
		public void Edit_PassEmptyNameWithId_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var category = CreateStockCategory(1, "");

			//Act
			repo.CreateResult(_edit, category);

			//Assert
			AssertIsNullLogError<IStockCategory>();
		}
		#endregion

		#region List

		[TestMethod]
		public void List_PassNothing_GetListNoLog()
		{
			//Arrange
			var repo = GetRepo();

			//Act
			repo.CreateResult(_List);

			//Assert
			AssertIsNotNullNoLog<List<IStockCategory>>();
		}

		#endregion

		#region IsValid

		[TestMethod]
		public void IsValid_PassValidId_ReturnTrueNoLog()
		{
			//Arrange
			var repo = GetRepo();

			//Act
			repo.CreateResult(_isValid, 1);

			//Assert
			AssertIsTrueLogError();
		}

		[TestMethod]
		public void IsValid_PassInvalidId_ReturnTrueNoLog()
		{
			//Arrange
			var repo = GetRepo();

			//Act
			repo.CreateResult(_isValid, 1000);

			//Assert
			AssertIsFalseNoLog();
		}
		#endregion

		IStockCategory CreateStockCategory(int id = 0, string name = "Meat")
		{
			return new StockCategory
			{
				StockCategoryId = id,
				StockCategoryName = name
			};
		}
	}
}
