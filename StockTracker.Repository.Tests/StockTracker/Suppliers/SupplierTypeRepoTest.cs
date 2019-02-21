using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context;
using StockTracker.Interface.Models.Suppliers;
using StockTracker.Model.Suppliers;
using StockTracker.Repository.Interface.Stock;
using StockTracker.Repository.Suppliers;
using StockTracker.Tests.Utils.AbstractClasses;
using StockTracker.Tests.Utils.Context;

namespace StockTracker.Repository.Test.StockTracker.Suppliers
{
	[TestClass]
	public class SupplierTypeRepoTest : TestUtils<SupplierTypeRepo>
	{

		private const string _add = nameof(SupplierTypeRepo.Add);
		private const string _edit = nameof(SupplierTypeRepo.Edit);
		private const string _list = nameof(SupplierTypeRepo.List);
		private const string _isValid = nameof(SupplierTypeRepo.IsValid);


		#region Add
		[TestMethod]
		public void Add_PassValidNewTypeRepo_ReturnNewRepoIdAndLogSuccess()
		{
			//Arrange
			var repo = GetRepo();
			var newSupplierType = DefaultSupplierType();
			newSupplierType.SupplierTypeId = 0;

			//Act
			repo.CreateResult(_add, newSupplierType);

			//Assert
			AssertIsNotNullLogSuccess<ISupplierType>();
		}

		[TestMethod]
		public void Add_PassAPopulatedId_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var newSupplierType = DefaultSupplierType();

			//Act
			repo.CreateResult(_add, newSupplierType);

			//Assert
			AssertIsNullLogError<ISupplierType>();
		}

		[TestMethod]
		public void Add_PassEmptyName_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var newSupplierType = DefaultSupplierType(supplierType: "");

			//Act
			repo.CreateResult(_add, newSupplierType);

			//Assert
			AssertIsNullLogError<ISupplierType>();
		}

		[TestMethod]
		public void Add_PassNameThatAlreadyExisits_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var preExistingSupplierType = _db.SupplierTypes.FirstOrDefault().SupplierTypeName;
			var newSupplierType = DefaultSupplierType(supplierType: preExistingSupplierType);

			//Act
			repo.CreateResult(_add, newSupplierType);

			//Assert
			AssertIsNullLogError<ISupplierType>();
		}
		#endregion

		#region Edit
		[TestMethod]
		public void Edit_PassValidIdNewName_ReturnNewStockTypeLogSuccess()
		{
			//Arrange
			var repo = GetRepo();
			var model = DefaultSupplierType();

			//Act
			repo.CreateResult(_edit, model);

			//Assert
			AssertIsNotNullLogSuccess<ISupplierType>();
		}

		[TestMethod]
		public void Edit_PassValidIdNoName_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var model = DefaultSupplierType(supplierType: "");

			//Act
			repo.CreateResult(_edit, model);

			//Assert
			AssertIsNullLogError<ISupplierType>();
		}

		[TestMethod]
		public void Edit_PassInvalidIdWithName_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var model = DefaultSupplierType();
			model.SupplierTypeId = 1000;

			//Act
			repo.CreateResult(_edit, model);

			//Assert
			AssertIsNullLogError<ISupplierType>();
		}
		#endregion

		#region List
		[TestMethod]
		public void List_PassNothing_ReturnListOfSupplierTypeRepoNoLog()
		{
			//Arrange
			var repo = GetRepo();

			//Act
			repo.CreateResult(_list);

			//Assert
			Assert.IsTrue(Result<List<ISupplierType>>().Count > 0);
			_log.NoLog();
		}
		#endregion

		#region IsValid
		[TestMethod]
		public void IsValid_PassValidId_ReturnTrueNoLog()
		{
			//Arrange
			var repo = GetRepo();
			var validId = _db.SupplierTypes.FirstOrDefault().SupplierTypeId;

			//Act
			repo.CreateResult(_isValid, validId);

			//Assert
			AssertIsTrueNoLog();
		}

		[TestMethod]
		public void IsValid_PassInvalidId_ReturnFalseNoLog()
		{
			//Arrange
			var repo = GetRepo();
			var invalidId = 10000;

			//Act
			repo.CreateResult(_isValid, invalidId);

			//Assert
			AssertIsFalseNoLog();
		}
		#endregion

		#region Dry
		ISupplierType DefaultSupplierType(int id = 1, string supplierType = "Grass Monger")
		{
			return new SupplierType
			{
				SupplierTypeId = id,
				SupplierTypeName = supplierType
			};
		}
		#endregion
	}
}
