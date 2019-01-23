using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;
using StockTracker.Model.StockSupplier;
using StockTracker.Repository.Interface.Stock;
using StockTracker.Repository.Stock;
using StockTracker.Seed.Stock;
using StockTracker.Seed.StockSupplier;
using StockTracker.Tests.Utils.Acts;
using StockTracker.Tests.Utils.Context;
using StockTracker.Tests.Utils.MockVerifiers;

namespace StockTracker.Repository.Test.StockTracker.Stock
{
		[TestClass]
		public class StockCoreRepoTest
		{
				private IStockCoreRepo _repo;
				private IStockTrackerContext _db;
				private GenericLoggerCheck<StockCoreRepo> _check;
				private Mock<ILoggerAdapter<StockCoreRepo>> _log;
				private GenericStockCore _genericStock;

				private const string _changeStockType = nameof(StockCoreRepo.ChangeStockType);
				private const string _changeCategory = nameof(StockCoreRepo.ChangeCategory);
				private const string _add = nameof(StockCoreRepo.Add);
				private const string _edit = nameof(StockCoreRepo.Edit);
				private const string _changeStockDetail = nameof(StockCoreRepo.ChangeStockDetail);

				public StockCoreRepoTest()
				{
						_db = new TestDbFactory().Db();
						_check = new GenericLoggerCheck<StockCoreRepo>();
						_genericStock = new GenericStockCore();
						_log = _check.Mock;
				}

				#region Add Test

				[TestMethod]
				public void Add_ValidStockCoreObject_ReturnNewStockCoreItem()
				{
						//Arrange
						var categoryRepo = GetStockCategoryRepo("IsValid", true);
						var stockTypeRepo = GetStockTypeRepo("IsValid", true);
						var repo = new StockCoreRepo(_db, _log.Object, categoryRepo, stockTypeRepo);
						var stockItem = _genericStock.One();

						new GenericStockSupplier().SeedContext(_db);

						//Act
						var result = repo.Add(stockItem);

						//Assert
						Asserts(result);
						_check.Success();
				}

				[TestMethod]
				public void Add_InvalidStockCategory_ReturnNullAndLogError()
				{
						Add_Tests("StockCategoryId", 0);
				}

				[TestMethod]
				public void Add_InvalidStockSupplierDetailId_ReturnNullAndLogError()
				{
						Add_Tests("StockSupplierDetailId", 0);
				}

				[TestMethod]
				public void Add_InvalidStockTypeId_ReturnNullAndLogError()
				{
						Add_Tests("StockTypeId", 0);
				}

				private void Add_Tests(string propertyName, int val)
				{
						//Arrange
						var stockItem = _genericStock.One();
						var repo = GetRepo(GetStockTypeRepo(nameof(IStockTypeRepo.Add), null));
						repo.CreateResult(nameof(IStockCoreRepo.Add), stockItem);
						stockItem.GetType().GetProperty(propertyName).SetValue(stockItem, val);

						//Act
						var result = repo.Result;

						//Assert
						Asserts(result, false);
						repo._loggerCheck.Error();
				}

				#endregion

				#region Edit Test

				[TestMethod]
				public void Edit_PassValidStockObject_ReturnModifiedStockItem()
				{
						var testValues = new Dictionary<string, string>
												{
																{nameof(StockCore.StockCategoryId), "2"},
																{nameof(StockCore.StockSupplierDetailId), "2"}
												};

						Edit_Tests_Success(testValues);
				}

				[TestMethod]
				public void Edit_PassOnlyStockCoreIdAndNewCategoryId_ReturnFullStockItemAndLogSuccess()
				{
						var testValues = new Dictionary<string, string>
												{
																{nameof(StockCore.StockCategoryId), "2"},
																{nameof(StockCore.StockSupplierDetailId), "0"},
																{nameof(StockCore.StockTypeId), "0"}
												};

						Edit_Tests_Success(testValues);
				}

				[TestMethod]
				public void Edit_PassOnlyStockCoreIdAndStockName_ReturnFullStockItemAndLogSuccess()
				{
						var testValues = new Dictionary<string, string>
												{
																{nameof(StockCore.StockCoreName), "Gooey Nectar"},
																{nameof(StockCore.StockCategoryId), "0"},
																{nameof(StockCore.StockSupplierDetailId), "0"},
																{nameof(StockCore.StockTypeId), "0"}
												};

						Edit_Tests_Success(testValues);
				}

				[TestMethod]
				public void Edit_PassInvalidStockCode_ReturnNullLogError()
				{
						var testValues = new Dictionary<string, string>
												{
																{nameof(StockCore.StockCoreId), "1000"}
												};

						Edit_Tests_Error(testValues);
				}

				[TestMethod]
				public void Edit_PassInvalidStockCodeStockCategoryId_ReturnNullLogError()
				{
						var testValues = new Dictionary<string, string>
												{
																{nameof(StockCore.StockCategoryId), "1000"},
																{nameof(StockCore.StockSupplierDetailId), "1000"},
												};

						Edit_Tests_Error(testValues);
				}

				[TestMethod]
				public void Edit_StockTrackerContextThrowsError_ReturnNullLogException()
				{
						Edit_Tests_Error(new Dictionary<string, string>(), true);
				}

				private void Edit_Tests_Success(Dictionary<string, string> stockPropertyChanges)
				{
						//Arrange
						var repo = GetRepo();
						var stockItem = _genericStock.One();

						_db.StockCores.Add(stockItem);
						((StockTrackerContext)_db).SaveChanges();

						//was gonna use a linq statement here to save lines of code, but this is easier to read.
						foreach (var item in stockPropertyChanges)
						{
								var isInt = int.TryParse(item.Key, out int val);

								if (isInt)
										stockItem.GetType().GetProperty(item.Key).SetValue(stockItem.GetType(), val);
								else
										stockItem.GetType().GetProperty(item.Key).SetValue(stockItem.GetType(), item.Value);
						}

						//Act
						repo.CreateResult(nameof(IStockCoreRepo.Edit), stockItem);
						var result = repo.Result;

						//Assert
						Assert.IsNotNull(result);
						Assert.IsInstanceOfType(result, typeof(StockCore));

						foreach (var item in stockPropertyChanges)
						{
								var isInt = int.TryParse(item.Key, out int val);


								if (isInt)
										Assert.AreNotEqual(result.GetType().GetProperty(item.Key).GetValue(result), val);
								else
										Assert.AreEqual(result.GetType().GetProperty(item.Key).GetValue(result), item.Value);
						}

						_check.Success();
				}

				private void Edit_Tests_Error(Dictionary<string, string> propertyValues, bool isExceptionCheck = false)
				{
						//Arrange
						var repo = GetRepo();
						var stockItem = _genericStock.One();

						foreach (var item in propertyValues)
						{
								var isInt = int.TryParse(item.Value, out int intVal);

								if (isInt)
										stockItem.GetType().GetProperty(item.Key).SetValue(stockItem.GetType(), intVal);
								else
										stockItem.GetType().GetProperty(item.Key).SetValue(stockItem.GetType(), item.Value);
						}

						//Act
						repo.CreateResult(nameof(IStockCoreRepo.Edit), stockItem);
						var result = repo.Result;

						//Assert
						Asserts(result, false);
						if (isExceptionCheck)
								_check.ErrorException();
						else
								_check.Error();
				}

				#endregion

				#region ChangeCategory Test

				[TestMethod]
				public void ChangeCategory_PassValidStockIdAndDifferentCategory_NewStockItemAndLogSuccess()
				{
						ChangeCategory_Test(new Dictionary<string, string> { { "StockCategoryId", "3" } });
				}

				[TestMethod]
				public void ChangeCategory_PassInvalidCategoryId_ReturnNullLogGenericError()
				{
						ChangeCategory_Test(new Dictionary<string, string> { { "StockCategoryId", "1" } }, false);
				}

				[TestMethod]
				public void ChangeCategory_ThrowsException_ReturnNullLogGenericErrorException()
				{
						ChangeCategory_Test(new Dictionary<string, string> { { "StockCategoryId", "1" } }, false);
				}

				private void ChangeCategory_Test(Dictionary<string, string> newVals, bool isSuccess = true)
				{
						//Arrange
						var stockCategoryRepo = GetStockCategoryRepo(result: isSuccess);
						var repo = GetRepo(null, stockCategoryRepo);
						var stockCore = ModifyStockCore(newVals);

						if (isSuccess)
								new GenericStockCore().SeedContext(repo._db);

						repo.CreateResult(nameof(IStockCoreRepo.ChangeCategory), stockCore.StockCoreId, int.Parse(newVals["StockCategoryId"]));

						//Act
						var result = repo.Result;

						//Assert
						Asserts(result, isSuccess);
						if (isSuccess)
								repo._loggerCheck.Success();
						else
								repo._loggerCheck.Error();
				}

				#endregion

				#region ChangeStockType Test

				[TestMethod]
				public void ChangeStockType_PassValidStockCodeIdAndValidStockType_LogSuccessReturnNewStockCode()
				{
						//Arrange
						var stockTypeRepo = new Mock<IStockTypeRepo>();
						stockTypeRepo.Setup(i => i.IsValid(It.IsAny<int>())).Returns(true);
						new AddSeed(_db, "StockCores");
						var repo = new Repo<StockCoreRepo>(parameter: stockTypeRepo.Object);
						repo.CreateResult(_changeStockType, 1, 2);

						//Act
						var result = repo.Result;

						//Assert
						Assert.IsInstanceOfType(result, typeof(StockCore));
						Assert.AreEqual((result as StockCore).StockCategoryId, 2);

						repo._loggerCheck.Success();
				}

				[TestMethod]
				public void ChangeStockType_PassInvalidStockCodeIdAndValidStockType_ReturnNullLogError()
				{
						//Arrange
						var fake = new Mock<IStockTypeRepo>();
						fake.Setup(i => i.IsValid(It.IsAny<int>())).Returns(true);
						var repo = new Repo<StockCoreRepo>(parameter: fake.Object);
						repo.CreateResult(_changeStockType, 0, 2);

						//Act
						var result = repo.Result;

						//Assert
						Assert.IsNull(result);
						repo._loggerCheck.Error();
				}

				#endregion

				#region ChangeStockDetail Test

				[TestMethod]
				public void
								ChangeStockDetail_PassValidStockIdAndValidStockSupplierDetail_ReturnStockObjectWithNewStockDetailId()
				{
						//Arrange
						var moq = new Mock<IStockTypeRepo>();
						moq.Setup(i => i.IsValid(It.IsAny<int>())).Returns(true);

						var repo = new Repo<StockCoreRepo>(parameter: moq.Object);
						var originalResult = _genericStock.One();

						repo.CreateResult(nameof(StockCoreRepo.ChangeStockDetail), 1, 2);

						//Act
						var result = repo.Result;

						//Assert
						Assert.IsNotNull(result);
						Assert.AreEqual(originalResult.StockSupplierDetailId, ((StockCore)result).StockSupplierDetail);

						repo._loggerCheck.Success();
				}

				#endregion

				#region Dry Code

				private void Asserts(StockCore result, bool isSuccess = true)
				{
						if (isSuccess)
						{
								Assert.IsNotNull(result);
						}
						else
						{
								Assert.IsNull(result);
						}
				}

				private void Asserts(StockCore result, Dictionary<string, string> compare, bool isSuccess = true)
				{
						if (isSuccess)
						{
								Assert.IsNotNull(result);
								foreach (var item in compare)
								{
										var initialValue = result.GetType().GetProperty(item.Key).GetValue(result);
										var newValue = item.Value;
										Assert.AreEqual(initialValue, newValue);
								}
						}
						else
						{
								Assert.IsNull(result);
						}
				}

				private StockCore ModifyStockCore(Dictionary<string, string> newVals)
				{
						var stockCore = _genericStock.One();

						foreach (var item in newVals)
						{
								var isInt = int.TryParse(item.Value, out int itemInt);

								if (isInt)
										stockCore.GetType().GetProperty(item.Key).SetValue(stockCore, itemInt);
								else
										stockCore.GetType().GetProperty(item.Key).SetValue(stockCore, item.Value);
						}

						return stockCore;
				}

				private Repo<StockCoreRepo> GetRepo(IStockTypeRepo stockTypeRepo = null, IStockCategoryRepo stockCategoryRepo = null)
				{
						if (stockTypeRepo == null && stockCategoryRepo == null)
								return new Repo<StockCoreRepo>();

						if (stockTypeRepo != null && stockCategoryRepo == null)
								return new Repo<StockCoreRepo>(parameter: stockTypeRepo);

						if (stockTypeRepo == null && stockCategoryRepo != null)
								return new Repo<StockCoreRepo>(parameter: stockCategoryRepo);

						return new Repo<StockCoreRepo>();
				}

				private IStockTypeRepo GetStockTypeRepo(string methodName, object result)
				{
						var mockStockTypeRepo = new Mock<IStockTypeRepo>();

						switch (methodName)
						{
								case "Add":
										mockStockTypeRepo.Setup(i => i.Add(It.IsAny<string>())).Returns((IStockType)result);
										break;
								case "Edit":
										mockStockTypeRepo.Setup(i => i.Edit(It.IsAny<int>(), It.IsAny<string>()))
														.Returns((IStockType)result);
										break;
								case "IsValid":
										mockStockTypeRepo.Setup(i => i.IsValid(It.IsAny<int>())).Returns((bool)result);
										break;
								default:
										throw new Exception("Unrecognized Method related to IStockTypeRepo");
						}

						return mockStockTypeRepo.Object;
				}

				private IStockCategoryRepo GetStockCategoryRepo(string methodName = "IsValid", object result = null)
				{
						var mockCategoryRepo = new Mock<IStockCategoryRepo>();

						if (methodName.Equals("IsValid") && result == null)
								result = true;

						switch (methodName)
						{
								case (nameof(IStockCategoryRepo.Add)):
										mockCategoryRepo.Setup(i => i.Add(It.IsAny<string>())).Returns((IStockCategory)result);
										break;
								case nameof(IStockCategoryRepo.Edit):
										mockCategoryRepo.Setup(i => i.Edit(It.IsAny<int>(), It.IsAny<string>()))
														.Returns((IStockCategory)result);
										break;
								case nameof(IStockCategoryRepo.IsValid):
										mockCategoryRepo.Setup(i => i.IsValid(It.IsAny<int>())).Returns((bool)result);
										break;
								default:
										throw new Exception("Unrecognized Method related to IStockCategoryRepo");
						}

						return mockCategoryRepo.Object;
				}

				#endregion
		}
}