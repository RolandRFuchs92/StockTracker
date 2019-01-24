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
        private readonly StockCategory _category;

        public StockTypeRepoTest()
        {
            _category = new StockCategory { StockCategoryName = "Shoes" };
        }

        #region Add
        [TestMethod]
        public void Add_NewObject_AddNewObjectLogSuccess()
        {
            // Arrange 
            var repo = GetRepo();

            //Act
            repo.CreateResult(nameof(IStockCategoryRepo.Add), _category);
            var result = repo.Result as StockCategory;

            //Assert
            Assert.AreEqual(result.StockCategoryName, _category.StockCategoryName);
            Assert.AreNotEqual(result.StockCategoryId, _category.StockCategoryId);
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
            repo.CreateResult(nameof(IStockCategoryRepo.Edit), category);
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
            repo.CreateResult(nameof(IStockCategoryRepo.Edit), _category);
            var result = repo.Result as StockCategory;

            //Assert
            Assert.AreNotEqual(result.StockCategoryId, _category.StockCategoryId);
            repo._loggerCheck.Success();
        }

        [TestMethod]
        public void Eidt_PassValidIdAndEmptyString_ReturnNullLogError()
        {
            //Arrange
            var repo = GetRepo();
            var category = _category;
            category.StockCategoryName = "";

            //Act
            repo.CreateResult(nameof(IStockCategoryRepo.Edit), category);
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
            repo.CreateResult(nameof(IStockCategoryRepo.IsValid), categoryId);
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
            repo.CreateResult(nameof(IStockCategoryRepo.IsValid), invalidCategoryId);
            var result = repo.Result;

            //Assert
            Assert.IsFalse(result);
            repo._loggerCheck.Error();
        }

        #endregion

        Repo<StockCategory> GetRepo()
        {
            var repo = new Repo<StockCategory>();
            _db = repo.db;
            return repo;
        }
    }
}
