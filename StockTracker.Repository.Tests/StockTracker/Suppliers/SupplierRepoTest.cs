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
using AutoMapper;

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
						PopulateSuppliers();
						var oldModel = DbSupplier();
						var newModel = GetSupplier(new Dictionary<string, dynamic>
						{
								{ nameof(ISupplier.SupplierId), oldModel.SupplierId },
								{ nameof(ISupplier.Address), "1 Moo Ville Minesota South Africa lakka" },
								{ nameof(ISupplier.Email), "godzilla@gmail.com" }
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
						PopulateSuppliers();
						Supplier oldModel = DbSupplier();
						var newModel = GetSupplier(new Dictionary<string, dynamic>
						{
								{ nameof(ISupplier.SupplierTypeId), 0 }
						}, oldModel);

						//Act
						repo.CreateResult(_edit, newModel);

						//Assert
						AssertIsNullLogError<ISupplier>();
				}

				[TestMethod]
				public void Edit_PassEmptyNumberAndEmail_ReturnNullLogError()
				{
						//Arrange
						var repo = GetRepo();
						PopulateSuppliers();
						var oldModel = DbSupplier();
						var newModel = GetSupplier(new Dictionary<string, dynamic>
						{
								{ nameof(ISupplier.ContactNumber), ""},
								{ nameof(ISupplier.Email), ""}
						}, oldModel);

						//Act
						repo.CreateResult(_edit, newModel);

						//Assert
						AssertIsNullLogError<ISupplier>();
				}

				[TestMethod]
				public void Edit_PassEmptyName_ReturNullLogError()
				{
						//Arrange
						var repo = GetRepo();
						PopulateSuppliers();
						var oldModel = DbSupplier();
						var newModel = GetSupplier(new Dictionary<string, dynamic>
						{
								{ nameof(ISupplier.SupplierName), "" }
						}, oldModel);

						//Act
						repo.CreateResult(_edit, newModel);

						//Assert
						AssertIsNullLogError<ISupplier>();
				}

				#endregion

				#region Delete

				[TestMethod]
				public void Delete_PassValidId_ReturnTrueLogSuccess()
				{
						//Arrange
						const int deleteId = 1;
						var repo = GetRepo();
						PopulateSuppliers();

						//Act
						repo.CreateResult(_delete, deleteId);

						//Assert
						AssertIsTrueLogSuccess();

						var supplierDoesExsist = _db.Suppliers.Any(i => i.SupplierId == deleteId);
						Assert.IsFalse(supplierDoesExsist);
				}

				[TestMethod]
				public void Delete_PassInvalidId_ReturnFalseLogError()
				{
						//Arrange
						const int deleteId = 100;
						var repo = GetRepo();
						PopulateSuppliers();

						//Act
						repo.CreateResult(_delete, deleteId);

						//Assert
						AssertIsFalseLogError();
				}
				#endregion

				#region Get
				[TestMethod]
				public void Get_PassValidId_ReturnSupplierWithSameIdNoLog()
				{
						//Arrange
						const int supplierId = 1;
						var repo = GetRepo();
						PopulateSuppliers();
						var supplier = DbSupplier(supplierId);

						//Act
						repo.CreateResult(_get, supplierId);

						//Assert
						AssertSameNoLog(supplier);
				}

				[TestMethod]
				public void Get_PassInvalidId_ReturnNullNoLog()
				{
						//Arrange
						var repo = GetRepo();
						PopulateSuppliers();

						//Act
						repo.CreateResult(_get, 1);

						//Assert
						AssertIsNotNullNoLog<ISupplier>();
				}
				#endregion

				#region List
				[TestMethod]
				public void List_PassNothing_ReturnListOfSuppliersNoLog()
				{
						//Arrange
						var repo = GetRepo();
						PopulateSuppliers();

						//Act
						repo.CreateResult(_list);

						//Assert
						AssertIsNotNullNoLog<List<ISupplier>>();
				}
				#endregion

				#region ListBySupplier
				[TestMethod]
				public void ListBySupplier_PassValidSupplierTypeId_ReturnListOfSuppliersNoLog()
				{
						//Arrange
						var repo = GetRepo();
						PopulateSuppliers();

						//Act
						repo.CreateResult(_listSuppliersByType, 1);

						//Assert
						AssertIsNotNullNoLog<List<ISupplier>>();
				}

				[TestMethod]
				public void ListBySupplier_PassInvalidSupplierTypeId_ReturnNullNoLog()
				{
						//Arrange
						var repo = GetRepo();
						PopulateSuppliers();

						//Act
						repo.CreateResult(_listSuppliersByType, 0);

						//Assert
						Assert.IsTrue(Result<List<ISupplier>>().Count == 0);
						_log.NoLog();
				}

				#endregion

				#region Dry
				ISupplier GetSupplier(Dictionary<string, dynamic> replaceVals, Supplier originalModel = null)
				{
						var config = new MapperConfiguration(cfg =>
						{
								cfg.CreateMap<Supplier, Supplier>();
						});

						var mapper = config.CreateMapper();

						var moo = new Supplier();
						moo = originalModel != null ? mapper.Map(originalModel, moo) : mapper.Map(_defaultSupplier.One(), moo);

						return moo.GetNewObject(replaceVals); 
				}

				private Supplier DbSupplier(int supplierId = 0)
				{
						if (supplierId == 0)
								return _db.Suppliers.FirstOrDefault();

						return _db.Suppliers.FirstOrDefault(i => i.SupplierId == supplierId);
				}

				void PopulateSuppliers()
				{
						_defaultSupplier.SeedContext(_db);
				}
				#endregion
		}
}
