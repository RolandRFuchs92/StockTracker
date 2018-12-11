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
using StockTracker.Context.Interface;
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
        private IStockTrackerContext _db;
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
            var testValues = new Dictionary<string, string>
            {
                { nameof(StockCore.StockCategoryId), "2" },
                { nameof(StockCore.StockSupplierDetailId), "2" }
            };

            Edit_Tests_Success(testValues);
        }


        [TestMethod]
        public void Edit_PassOnlyStockCoreIdAndNewCategoryId_ReturnFullStockItemAndLogSuccess()
        {
            var testValues = new Dictionary<string, string>
            {
                { nameof(StockCore.StockCategoryId), "2" },
                { nameof(StockCore.StockSupplierDetailId), "0" },
                { nameof(StockCore.StockTypeId), "0" }
            };

            Edit_Tests_Success(testValues);
        }

        [TestMethod]
        public void Edit_PassOnlyStockCoreIdAndStockName_ReturnFullStockItemAndLogSuccess()
        {
            var testValues = new Dictionary<string, string>
            {
                { nameof(StockCore.StockCoreName), "Gooey Nectar" },
                { nameof(StockCore.StockCategoryId), "0" },
                { nameof(StockCore.StockSupplierDetailId), "0" },
                { nameof(StockCore.StockTypeId), "0" }
            };

            Edit_Tests_Success(testValues);
        }

        [TestMethod]
        public void Edit_PassInvalidStockCode_ReturnNullLogError()
        {
            var testValues = new Dictionary<string, string>
            {
                { nameof(StockCore.StockCoreId), "1000"}
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
            var result = repo.Edit(stockItem);

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
            var repo = GetRepo(i => i.StockCores.Select(It.IsAny<Func<StockCore, StockCore>>()));
            var stockItem = _genericStock.One();

            foreach (var item in propertyValues)
            {
                var isInt = int.TryParse(item.Value, out int intVal);

                if(isInt)
                    stockItem.GetType().GetProperty(item.Key).SetValue(stockItem.GetType(), intVal);
                else
                    stockItem.GetType().GetProperty(item.Key).SetValue(stockItem.GetType(), item.Value);
            }


            //Act
            var result = repo.Edit(stockItem);

            //Assert
            Asserts(result,false);
            if(isExceptionCheck)
                _check.ErrorException();
            else
                _check.Error();
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


        private IStockCoreRepo GetRepo(Expression<Action<IStockTrackerContext>> customContextBehavior) 
        {
            var repo = new Mock<IStockCoreRepo>().Object;

            var db = new Mock<IStockTrackerContext>();
            db.Setup(customContextBehavior).Throws(new Exception());

            return repo;
        }

        #endregion

    }
}
