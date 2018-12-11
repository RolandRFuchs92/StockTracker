using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.BusinessLogic.Test.Utils;
using StockTracker.Context;
using StockTracker.Model.Stock;
using StockTracker.Repository.Interface.Stock;
using StockTracker.Repository.Stock;
using StockTracker.Seed.Stock;

namespace StockTracker.Repository.Test.StockTracker.Stock
{
    [TestClass]
    public class StockCoreRepoTest
    {
        private IStockCoreRepo _repo;
        private StockTrackerContext _db;
        private GenericLoggerCheck<StockCoreRepo> _check;
        private Mock<ILoggerAdapter<StockCoreRepo>> _log;
        private GenericStockCore _genericStock;

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
            var repo = GetRepo();
            var stockItem = _genericStock.One();

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
            var repo = GetRepo();
            stockItem.GetType().GetProperty(propertyName).SetValue(stockItem, val);

            //Act
            var result = repo.Add(stockItem);

            //Assert
            Asserts(result, false);
            _check.Error();
        }
        #endregion

        #region Edit Test

        [TestMethod]
        public void Edit_PassValidStockObject_ReturnModifiedStockItem()
        {
            //Arrange
            var repo = GetRepo();
            var stockItem = _genericStock.One();
            var categoryId = 2;
            var detailId = 2;

            _db.StockCores.Add(stockItem);
            ((StockTrackerContext) _db).SaveChanges();

            stockItem.StockSupplierDetailId = categoryId;
            stockItem.StockCategoryId = detailId;

            //Act
            var result = repo.Edit(stockItem);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(StockCore));
            Assert.AreEqual(result.StockCategoryId, categoryId);
            Assert.AreEqual(result.StockCategoryId, detailId);

            _check.Success();
        }

        private void Edit_Tests()
        {
            //Arrange

            //Act

            //Assert
        }

        #endregion

        #region MyRegion
        private void Asserts(StockCore result , bool isSuccess = true)
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


        private IStockCoreRepo GetRepo()
        {
            var moq = new Mock<IStockCoreRepo>();

            return moq.Object;
        }

        #endregion

    }
}
