using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Repository.Util;

namespace StockTracker.Repository.Test.Util
{
    [TestClass]
    public class ModelBinderTest
    {
        private readonly ModelBinder _binder;

        public ModelBinderTest()
        {
            _binder = new ModelBinder();
        }

        [TestMethod]
        public void Bind_PassthroughNullObject_ReturnOriginalObject()
        {
            //Arrange
            var originalModel = GetFakeClassById();
            var newModel = (FakeClassA)null;


            //Act
            var result = _binder.Bind(originalModel, newModel);

            //Assert
            Assert.AreEqual(originalModel.Id, result.Id);
        }

        [TestMethod]
        public void Bind_PassthroughNewObject_ReturnsNewObjectInformation()
        {
            //Arrange
            var originalModel = GetFakeClassById();
            var newModel = GetFakeClassById(1);

            //Act
            var result = _binder.Bind(originalModel, newModel);

            //Assert
            CompareValueAssert(result, newModel);
        }

        [TestMethod]
        public void Bind_PassthroughNewObjectWithNoID_ReturnNewObjectWithOldID()
        {
            //Arrange
            var originalModel = GetFakeClassById();
            var newModel = GetFakeClassById(1);
            newModel.Id = 0;

            //Act
            var result = _binder.Bind(originalModel, newModel);

            //Assert
            Assert.AreNotEqual(result.Id, newModel.Id);
            CompareValueAssert(result, newModel);
        }

        void CompareValueAssert(FakeClassA oldAssertValue, FakeClassA newAssertValues)
        {
            Assert.AreEqual(oldAssertValue.Birthdate, newAssertValues.Birthdate);
            Assert.AreEqual(oldAssertValue.Mobile, newAssertValues.Mobile);
        }

        FakeClassA GetFakeClassById(int id = 0)
        {
            switch(id)
            {
                case 0:
                    return new FakeClassA
                    {
                        Mobile = "012 345 6789",
                        Name = "Mr. Incredible",
                        Birthdate = new DateTime(1992, 3, 1),
                        Id = 1
                    };
                default:
                    return new FakeClassA
                    {
                        Mobile = "987 654 3210",
                        Name = "Mr. Average",
                        Birthdate = new DateTime(2000, 1, 12),
                        Id = 1
                    };
            }
        }

        private class FakeClassA
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public DateTime Birthdate { get; set; }
            public string Mobile { get; set; }
        }
    }
}
