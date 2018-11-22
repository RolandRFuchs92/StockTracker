using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.API.Interface.Clients;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.BusinessLogic.Inteface.Poco;
using StockTracker.Interface.Models.Clients;
using StockTracker.Seed.Clients;

namespace StockTracker.API.Test.Clients
{
    [TestClass]
    public class AddClientSettingsControllerTest
    {
        IClientSettingsController _clientSettingsController;
        GenericClientSettings _genericSettings;
        IClientSettings _setting;
        
        public AddClientSettingsControllerTest()
        {
            _genericSettings = new GenericClientSettings();
            _setting = _genericSettings.One();
        }

        #region Add Test
        [TestMethod]
        public void Add_IClientSettings_GetSuccessResultAsOkObject()
        {
            //Arrange
            var moqResult = GenericClientSettingsResult();
            var moq = new Mock<IClientSettingsLogic>();
            moq.Setup(i => i.Add(It.IsAny<IClientSettings>())).Returns(moqResult);

            //Act
            var result = _clientSettingsController.Add(_setting);
            var okResult = result as OkObjectResult;
            var okVal = okResult.Value as IResult<IClientSettings>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(okResult.Value, typeof(IResult<IClientSettings>));
            Assert.IsInstanceOfType(okVal.Body, typeof(IClientSettings));
            Assert.IsTrue(okVal.IsSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(okVal.Message));
        }

        [TestMethod]
        public void Add_PassInvalidInfo_GetBadResult()
        {
            //Arrange
            var moq = new Mock<IClientSettingsLogic>();
            moq.Setup(i => i.Add(It.IsAny<IClientSettings>())).Returns(null as IResult<IClientSettings>);

            //Act
            var result = _clientSettingsController.Add(_setting);
            var badResult = result as BadRequestObjectResult;
            var badVal = badResult as IResult<IClientSettings>;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(badResult.Value, typeof(BadRequestObjectResult));
            Assert.IsInstanceOfType(badVal, typeof(IResult<IClientSettings>));
            Assert.IsFalse(badVal.IsSuccess);
            Assert.IsFalse(string.IsNullOrEmpty(badVal.Message));
        }
        #endregion

        #region IsActive Test
        [TestMethod]
        public void IsActive_PassValidClient_PopulatedValuesOkResult()
        {
            //Arrange
            var clientSettingsController = GenericClientSettingsController(i => i.Add(It.IsAny<IClientSettings>()), GenericClientSettingsResult());

            //Act
            var result = clientSettingsController.IsActive(0, false);

            //Assert
            Assertions(result, true);
        }

        [TestMethod]
        public void IsActive_PassInvalidClient_EmptyValueBadResult()
        {
            //Arrange
            var clientSettingsController = GenericClientSettingsController(i => i.IsActive(It.IsAny<int>(), It.IsAny<bool>()), GenericClientSettingsResult(false));

            //Act
            var result = clientSettingsController.IsActive(0, false);

            //Assert
            Assertions(result, false);
        }
        #endregion

        #region IsDeleted Test
        [TestMethod]
        public void IsDeleted_PassValidClient_OkResultWithRelatedData()
        {
            //Arrange
            var genericClientSettingsController = GenericClientSettingsController(i => i.IsDeleted(It.IsAny<int>(), true), GenericClientSettingsResult());

            //Act
            var result = genericClientSettingsController.IsActive(1, true);

            //Assert
            Assertions(result);
        }

        [TestMethod]
        public void IsDeleted_PassInvalidClient_BadResultWithMessage()
        {
            //Arrange
            var genericClientSettingsController =
                GenericClientSettingsController(i => i.IsDeleted(It.IsAny<int>(), It.IsAny<bool>()),
                    GenericClientSettingsResult(false));

            //Act
            var result = genericClientSettingsController.IsDeleted(0, true);

            //Assert
            Assertions(result, false);
        }
        #endregion

        #region Edit Test
        [TestMethod]
        public void Edit_PassValidClientSettingsForEdit_OkResultAndValidBody()
        {
            //Arrange
            var genericClientSettingsController =
                GenericClientSettingsController(i => i.Edit(It.IsAny<IClientSettings>()),
                    GenericClientSettingsResult());

            //Act
            var result = genericClientSettingsController.Edit(_setting);

            //Assert
            Assertions(result);
        }

        [TestMethod]
        public void Edit_PassInvalidClientSettings_BadResultAndMessage()
        {
            //Arrange
            var genericClientSettingsController =
                GenericClientSettingsController(i => i.Edit(It.IsAny<IClientSettings>()),
                    GenericClientSettingsResult(false));

            //Act
            var result = GenericClientSettingsResult(false);

            //Assert
            Assertions(result, false);
        }

        #endregion

        #region SetBusinessHours Test

        [TestMethod]
        public void SetBusinessHours_PassValidClient_OkResult()
        {
            //Arrange
            var genericClientSettingsController = GenericClientSettingsController(
                i => i.SetBusinessHours(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), 1),
                GenericClientSettingsResult());

            //Act
            var result = genericClientSettingsController.SetBusinessHours(new DateTime(2000, 1, 1, 8, 0, 0),
                new DateTime(2000, 1, 1, 17, 0, 0), 1);

            //Assert
            Assertions(result);
        }

        [TestMethod]
        public void SetBusinessHours_PassValidClient_Badresult()
        {
            //Arrange
            var genericClientSettingsClientController = GenericClientSettingsController(
                i => i.SetBusinessHours(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), 1),
                GenericClientSettingsResult(false));

            //Act
            var result = genericClientSettingsClientController.SetBusinessHours(new DateTime(2000, 1, 1, 8, 0, 0),
            new DateTime(2000, 1, 1, 17, 0, 0), 1);

            //Assert
            Assertions(result, false);
        }
        #endregion

        #region AddTotalUsers Test

        [TestMethod]
        public void AddTotalUsers_PassValidClient_OkResult()
        {
            //Arrange
            var genericClientSettingsController =
                GenericClientSettingsController(i => i.AddTotalUsers(It.IsAny<int>(), It.IsAny<int>()),
                    GenericClientSettingsResult());

            //Act
            var result = genericClientSettingsController.AddTotalUsers(0, 1);

            //Assert

        }

        [TestMethod]
        public void AddTotalUsers_PassValidClient_BadResult()
        {
            //Arrange
            var genericClientSettingsController =
                GenericClientSettingsController(i => i.AddTotalUsers(It.IsAny<int>(), It.IsAny<int>()),
                    GenericClientSettingsResult(false));

            //Act
            var result = genericClientSettingsController.AddTotalUsers(0, 1);


            //Assert
            Assertions(result, false);
        }

        #endregion

        #region Dry Testing Mechanisims
        IResult<IClientSettings> GenericClientSettingsResult(bool isSuccess = true)
        {
            var settings = _genericSettings.One();
            var result = new Result<IClientSettings>
            {
                Body = isSuccess ? settings : (IClientSettings)null,
                IsSuccess = isSuccess,
                Message = isSuccess ? "" : "awww"
            };

            return result;
        }

        IClientSettingsController GenericClientSettingsController(Expression<Action<IClientSettingsLogic>> method, IResult<IClientSettings> result)
        {
            var moq = new Mock<IClientSettingsLogic>();
            moq.Setup(method);

            //_clientSettingsController = new ClientSettingsController(moq.Object);

            return _clientSettingsController;
        }

        void Assertions(object result, bool isSuccess = true)
        {
            if (isSuccess)
            {
                var okResult = result as OkObjectResult;
                var okVal = okResult.Value as IResult<IClientSettings>;

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(okResult.Value, typeof(IResult<IClientSettings>));
                Assert.IsInstanceOfType(okVal.Body, typeof(IClientSettings));
                Assert.IsTrue(okVal.IsSuccess);
                Assert.IsTrue(string.IsNullOrEmpty(okVal.Message));
            }
            else
            {
                var badResult = result as BadRequestObjectResult;
                var badVal = badResult as IResult<IClientSettings>;

                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(badResult.Value, typeof(BadRequestObjectResult));
                Assert.IsInstanceOfType(badVal, typeof(IResult<IClientSettings>));
                Assert.IsFalse(badVal.IsSuccess);
                Assert.IsFalse(string.IsNullOrEmpty(badVal.Message));
            }
        }
        #endregion
    }
}
