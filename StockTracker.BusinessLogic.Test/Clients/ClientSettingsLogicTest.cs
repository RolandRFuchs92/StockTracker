using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.BuisnessLogic.Clients;
using StockTracker.BusinessLogic.Interface.Client;
using StockTracker.BusinessLogic.Interface.Poco;
using StockTracker.Interface.Models.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Seed.Clients.Generic;

namespace StockTracker.BusinessLogic.Test.Clients
{
    [TestClass]
    public class ClientSettingsLogicTest
    {
        private IClientSettingsLogic _clientSettingsLogic;
        private GenericClientSettings _genericClientSettings;
        private GenericLoggerCheck<ClientSettingsLogic> _genericLog;
        private ILoggerAdapter<ClientSettingsLogic> _log;

        public ClientSettingsLogicTest()
        {
            _genericClientSettings = new GenericClientSettings();

            _genericLog = new GenericLoggerCheck<ClientSettingsLogic>();
            _log = _genericLog.Mock.Object;
        }

        #region Edit Test
        [TestMethod]
        public void Edit_PassValidClientWithNewSettings_IClientSettingsWithSameResults()
        {
            //Arrange
            var clientId = 1;
            var clientSettings = _genericClientSettings.One(clientId);
            var moq = new Mock<IClientSettingsRepo>();

            moq.Setup(i => i.Edit(It.IsAny<IClientSettings>())).Returns(clientSettings);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.Edit(clientSettings);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsTrue(result.IsSuccess);
            Assert.AreEqual(result.Body.IsActive, result.Body.IsActive);

            _genericLog.Success();
        }

        [TestMethod]
        public void Edit_PassInvalidClientWithSettings_Null()
        {
            //Arrange
            var clientSettings = _genericClientSettings.One();
            var moq = new Mock<IClientSettingsRepo>();
            moq.Setup(i => i.Edit(It.IsAny<IClientSettings>())).Returns((IClientSettings)null);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.Edit(clientSettings);

            //Assert
            Assert.IsFalse(result.IsSuccess);
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsFalse(string.IsNullOrEmpty(result.Message));
            Assert.IsNull(result.Body);
            _genericLog.Error();
        }
        #endregion

        #region Add Test
        [TestMethod]
        public void Add_PassValidClientInfo_ClientSettings()
        {
            //Arrange
            var moq = new Mock<IClientSettingsRepo>();
            var clientSettings = _genericClientSettings.One();
            moq.Setup(i => i.AddClientSettings(It.IsAny<IClientSettings>())).Returns(clientSettings);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.Add(clientSettings);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.AreSame(clientSettings, result.Body);
            _genericLog.Success();
        }

        [TestMethod]
        public void Add_PassInvalidClientInfo_Null()
        {
            //Arrange
            var moq = new Mock<IClientSettingsRepo>();
            var clientSettings = _genericClientSettings.One();
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.Add(clientSettings);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsSuccess);
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            _genericLog.Error();
        }
        #endregion

        #region IsDeleted Test

        [TestMethod]
        public void IsDeleted_PassValidClientIdDeactivate_ReturnSuccessAndCorrespondingBody()
        {
            //Arrange
            var clientSettings = _genericClientSettings.One();

            var moq = new Mock<IClientSettingsRepo>();
            moq.Setup(i => i.IsDeleted(It.IsAny<int>(), It.IsAny<bool>())).Returns(clientSettings);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.IsDeleted(0, true);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(result.Message));
            Assert.IsInstanceOfType(result.Body, typeof(IClientSettings));
            _genericLog.Success();
        }

        [TestMethod]
        public void IsDeleted_InitialConditionas_ExpectedResult()
        {
            //Arrange
            var moq = new Mock<IClientSettingsRepo>();
            moq.Setup(i => i.IsDeleted(It.IsAny<int>(), It.IsAny<bool>())).Returns((IClientSettings)null);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.IsDeleted(2, false);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsFalse(result.IsSuccess);
            Assert.IsTrue(!string.IsNullOrEmpty(result.Message));
            Assert.IsNull(result.Body);
            _genericLog.Error();
        }
        #endregion

        #region IsActive Test
        [TestMethod]
        public void IsActive_PassValidChanges_ValidResults()
        {
            //Arrange
            var clientSettings = _genericClientSettings.One();
            var isActive = true;
            var moq = new Mock<IClientSettingsRepo>();
            moq.Setup(i => i.IsActive(It.IsAny<int>(), isActive)).Returns(clientSettings);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.IsActive(1, isActive);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsSuccess);
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsTrue(string.IsNullOrEmpty(result.Message));
            Assert.IsInstanceOfType(result.Body, typeof(IClientSettings));
            _genericLog.Success();
        }


        [TestMethod]
        public void IsActive_PassinvalidClient_BadResult()
        {
            //Arrange
            var isActive = true;
            var moq = new Mock<IClientSettingsRepo>();
            moq.Setup(i => i.IsActive(It.IsAny<int>(), isActive)).Returns((IClientSettings)null);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.IsActive(0, false);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsFalse(result.IsSuccess);
            Assert.IsFalse(string.IsNullOrEmpty(result.Message));
            Assert.IsNull(result.Body);
            _genericLog.Error();
        }
        #endregion

        #region SetBusinessHours Test
        [TestMethod]
        public void SetBusinessHours_PassValidBusinessHours_ReturnResultIClientSettings()
        {
            //Arrange
            var clientSettings = _genericClientSettings.One();
            var moq = new Mock<IClientSettingsRepo>();
            moq.Setup(i => i.SetOpenClosedTimes(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(), clientSettings.ClientId)).Returns(clientSettings);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            var openingTime = new DateTime(2018, 1, 1, 8, 0, 0);
            var closingTime = new DateTime(2018, 1, 1, 17, 0, 0);

            //Act
            var result = _clientSettingsLogic.SetBusinessHours(openingTime, closingTime, clientSettings.ClientId);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsTrue(result.IsSuccess);
            Assert.IsTrue(string.IsNullOrEmpty(result.Message));
            Assert.IsInstanceOfType(result.Body, typeof(IClientSettings));
            _genericLog.Success();
        }

        [TestMethod]
        public void SetBusinessHours_PassinvalidBusinessHours_ReturnsFalse()
        {
            //Arrange
            var clientId = 0;
            var openingTime = new DateTime(2018, 1, 1, 18, 0, 0);
            var closingTime = new DateTime(2018, 1, 1, 7, 0, 0);
            var clientSettings = _genericClientSettings.One();

            var moq = new Mock<IClientSettingsRepo>();
            moq.Setup(i => i.SetOpenClosedTimes(openingTime, closingTime, 0)).Returns((IClientSettings)null);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.SetBusinessHours(openingTime, closingTime, clientId);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsFalse(result.IsSuccess);
            Assert.IsNull(result.Body);
            Assert.IsFalse(string.IsNullOrEmpty(result.Message));
            _genericLog.Error();
        }
        #endregion

        #region AddTotalUsers
        [TestMethod]
        public void AddTotalUsers_AddACertainAmountOfUsers_ValidUsersReturned()
        {
            //Arrange
            var clientSettings = _genericClientSettings.One();

            var moq = new Mock<IClientSettingsRepo>();
            moq.Setup(i => i.AddTotalUsers(It.IsAny<int>(), It.IsAny<int>())).Returns(clientSettings);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.AddTotalUsers(1, 5);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsTrue(result.IsSuccess);
            Assert.IsInstanceOfType(result.Body, typeof(IClientSettings));
            Assert.IsTrue(string.IsNullOrEmpty(result.Message));
            _genericLog.Success();
        }

        [TestMethod]
        public void AddTotalUsers_AddCertainAmountOfUsersBadClient_ErrorResult()
        {
            //Arrange
            var moq = new Mock<IClientSettingsRepo>();
            moq.Setup(i => i.AddTotalUsers(It.IsAny<int>(), It.IsAny<int>())).Returns((IClientSettings)null);
            _clientSettingsLogic = new ClientSettingsLogic(moq.Object, _log);

            //Act
            var result = _clientSettingsLogic.AddTotalUsers(0, 100);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
            Assert.IsFalse(result.IsSuccess);
            Assert.IsNull(result.Body);
            Assert.IsFalse(string.IsNullOrEmpty(result.Message));
            _genericLog.Error();
        }
        #endregion
    }
}
