using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Interface.Models.Suppliers;
using StockTracker.Repository.Interface.Suppliers;
using StockTracker.Repository.Suppliers;
using StockTracker.Tests.Utils.AbstractClasses;
using StockTracker.Model.Suppliers;
using StockTracker.Seed.Suppliers;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using StockTracker.Tests.Utils.Extension;

namespace StockTracker.Repository.Test.StockTracker.Suppliers
{
	[TestClass]
	public class SupplierRepoTest : TestUtils<SupplierRepo>
	{
		public const string _add = nameof(ISupplierRepo.Add);
		public const string _edit = nameof(ISupplierRepo.Edit);
		public const string _list = nameof(ISupplierRepo.List);
		public const string _listSuppliersByType = nameof(ISupplierRepo.ListSuppliersByType);
		public const string _get = nameof(ISupplierRepo.Get);
		public const string _delete = nameof(ISupplierRepo.Delete);
		private readonly GenericSupplier _defaultSupplier;

		public SupplierRepoTest()
		{
			_defaultSupplier = new GenericSupplier();
		}

		#region Add
		[TestMethod]
		public void Add_PassValidSupplier_ReturnNewSupplierLogSuccess()
		{
			//Arrange
			var repo = GetRepo();
			var newSupplier = GetSupplier(new Dictionary<string, dynamic> { { nameof(ISupplier.SupplierId), 0 } });

			//Act
			repo.CreateResult(_add, newSupplier);

			//Assert
			AssertIsNotNullLogSuccess<ISupplier>();
		}

		[TestMethod]
		public void Add_PassInvalidSupplierType_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var newSupplier = GetSupplier(new Dictionary<string, dynamic> { { nameof(ISupplier.SupplierTypeId), 1000 } });

			//Act
			repo.CreateResult(_add, newSupplier);

			//Assert
			AssertIsNullLogError<ISupplier>();
		}

		[TestMethod]
		public void Add_PassEmptySupplierName_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var newSupplier = GetSupplier(new Dictionary<string, dynamic> { { nameof(ISupplier.SupplierName), "" } });

			//Act
			repo.CreateResult(_add, newSupplier);

			//Assert
			AssertIsNullLogError<ISupplier>();
		}

		[TestMethod]
		public void Add_PassEmptyEmailAndEmptyContactNumber_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var newSupplier =
				GetSupplier(new Dictionary<string, dynamic>
				{
					{ nameof(ISupplier.ContactNumber), "" },
					{ nameof(ISupplier.Email), "" }
				});

			//Act
			repo.CreateResult(_add, newSupplier);

			//Assert
			AssertIsNullLogError<ISupplier>();
		}
		#endregion

		#region Edit

		[TestMethod]
		public void Edit_PassValidEditRequest_ReturnModifiedSupplierLogSuccess()
		{
			//Arrange
			var repo = GetRepo();
			var oldModel = DbSupplier();
			var newModel = GetSupplier(new Dictionary<string, dynamic>
			{
				{ nameof(ISupplier.SupplierId), oldModel.SupplierId }
			}, oldModel);

			//Act
			repo.CreateResult(_edit, newModel);

			//Assert
			AssertSameLogSuccess(oldModel);
		}

		[TestMethod]
		public void Edit_PassInvalidId_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			Supplier oldModel = DbSupplier();
			var newModel = GetSupplier(new Dictionary<string, dynamic>
			{
				{ nameof(ISupplier.SupplierTypeId), 0 }
			}, oldModel);

			//Act
			repo.CreateResult(_edit, newModel);

			//Assert
			AssertDiffLogError(oldModel);
		}

		[TestMethod]
		public void Edit_PassEmptyNumberAndEmail_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var oldModel = DbSupplier();
			var newModel = GetSupplier(new Dictionary<string, dynamic>
			{
				{ nameof(ISupplier.ContactNumber), ""},
				{ nameof(ISupplier.Email), ""}
			}, oldModel);

			//Act
			repo.CreateResult(_edit, newModel);

			//Assert
			AssertDiffLogError(oldModel);
		}

		[TestMethod]
		public void Edit_PassEmptyName_ReturNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var oldModel = DbSupplier();
			var newModel = GetSupplier(new Dictionary<string, dynamic>
			{
				{ nameof(ISupplier.SupplierName), "" }
			}, oldModel);

			//Act
			repo.CreateResult(_edit, newModel);

			//Assert
			AssertDiffLogError(oldModel);
		}

		#endregion

		#region Dry
		ISupplier GetSupplier(Dictionary<string, dynamic> replaceVals, Supplier originalModel = null)
		{
			return originalModel != null 
				? originalModel.GetNewObject(replaceVals) 
				: _defaultSupplier.One().GetNewObject(replaceVals);
		}

		private Supplier DbSupplier()
		{
			return _db.Suppliers.FirstOrDefault();
		}
		#endregion
	}
}
