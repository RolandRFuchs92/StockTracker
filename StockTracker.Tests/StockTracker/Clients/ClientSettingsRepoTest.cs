using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;
using StockTracker.Model.ClientStock;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Seed.Clients;
using StockTracker.Seed.Clients.Generic;

namespace StockTracker.Repository.Test.StockTracker.Clients
{
	[TestClass]
	public class ClientSettingsRepoTest
	{
		private IStockTrackerContext _db;
		private GenericClientSettings _genericSettings;
		private IClientSettingsRepo _clientSettingsRepo;
	    private ILoggerAdapter<ClientSettingsRepo> _logger;
		private GenericClients _clients;
        private Mock<ILoggerAdapter<ClientSettingsRepo>> _mock;


		public ClientSettingsRepoTest()
		{
			_db = new TestDbFactory().Db();
			_genericSettings = new GenericClientSettings();
            _mock = new Mock<ILoggerAdapter<ClientSettingsRepo>>();
		    _logger = _mock.Object;
			_clientSettingsRepo = new ClientSettingsRepo(_db, _logger);
			_clients = new GenericClients();
		}

		#region AddClientSettings Test
		[TestMethod]
		public void AddClientSettings_PassValidClientSettings_ReturnTrue()
		{
			//Arrange
			AddClient();

			var clientSettings = _genericSettings.One();

			//Act
			var result = _clientSettingsRepo.AddClientSettings(clientSettings);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IClientSettings));
			Assert.IsNotNull(result);
			Assert.AreSame(result, clientSettings);
		    VerifyLogInfo();

		}

		[TestMethod]
		public void AddClientSettings_PassInvalidClientId_ReturnsFalse()
		{
			//Arrange
			((StockTrackerContext)_db).Database.EnsureDeleted();
			var clientSettings = _genericSettings.One();

			//Act
			var result = _clientSettingsRepo.AddClientSettings(clientSettings);

			//Assert
			Assert.IsNull(result);
            VerifyLogError();
		}

        [TestMethod]
        public void AddClientSettings_PassSomethingThrowsError_LogErrorWithException()
        {
            //Arrange
            var moq = new Mock<IStockTrackerContext>();
            moq.Setup(i => i.ClientSettings).Throws(new Exception());
            var clientSettingsRepo = new ClientSettingsRepo(moq.Object, _logger);

            //Act
            var result = clientSettingsRepo.AddClientSettings(_genericSettings.One());

            //Assert
            Assert.IsNull(result);
            VerifyLogErrorException();
        }
		#endregion

		#region IsActive Test
		[TestMethod]
		public void IsActive_PassClientIdAndValidActive_True()
		{
			//Arrange
			var client = AddClient();
			var isActive = false;
			AddClientSettings();

			//Act
			var result = _clientSettingsRepo.IsActive(client, isActive);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IClientSettings));
			Assert.IsNotNull(result);
			Assert.AreEqual(result.IsActive, isActive);
            VerifyLogInfo();
		}


		[TestMethod]
		public void IsActive_PassInvalidClientId_false()
		{
			//Arrange
			var isActive = false;

			//Act
			var result = _clientSettingsRepo.IsActive(0, isActive);

			//Assert
			Assert.IsNull(result);
            VerifyLogError();
		}

        [TestMethod]
        public void IsActive_PassInvalidClientId_ThrowsError()
        {
            //Arrange
            var isActive = false;
            var moq = new Mock<IStockTrackerContext>();
            moq.Setup(i => i.ClientSettings).Throws(new Exception());
            var clientSettingsRepo = new ClientSettingsRepo(moq.Object, _logger);

            //Act
            var result = clientSettingsRepo.IsActive(0, isActive);

            //Assert
            Assert.IsNull(result);
            VerifyLogErrorException();
        }
		#endregion

		#region IsDeleted Test
		[TestMethod]
		public void IsDeleted_ValidClientIdAndFalse_ClientSettingsResult()
		{
			//Arrange
			var client = AddClient();
			var isDeleted = false;
			var clientSettings = _genericSettings.One();
			clientSettings.IsDeleted = true;
			clientSettings.DateDeleted = DateTime.Now.AddDays(-10);

			AddClientSettings(clientSettings);

			//Act
			var result = _clientSettingsRepo.IsDeleted(client, isDeleted);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IClientSettings));
			Assert.IsNotNull(result);
			Assert.AreEqual(result.IsDeleted, isDeleted);
			Assert.IsNull(result.DateDeleted);
            VerifyLogInfo();
		}

		[TestMethod]
		public void IsDeleted_InvalidClientIdAndFalse_Null()
		{
			//Arrange
			var client = AddClient();
			var isDeleted = false;

			//Act
			var result = _clientSettingsRepo.IsDeleted(0, isDeleted);

            //Assert
            Assert.IsNull(result);
            VerifyLogError();
		}

		[TestMethod]
		public void IsDeleted_TryDeleteDeletedClient_DateDeletedIsUnchanged()
		{
			//Arrange
			var client = AddClient();
			var isDeleted = true;
			var dateDeleted = DateTime.Now.AddDays(-10);

			var clientSettings = _genericSettings.One();
			clientSettings.IsDeleted = true;
			clientSettings.DateDeleted = dateDeleted;
			AddClientSettings(clientSettings);

			//Act
			var result = _clientSettingsRepo.IsDeleted(client, isDeleted);

			//Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(result.DateDeleted, dateDeleted);

            VerifyLogInfo();
		}
		#endregion

		#region Edit Test
		[TestMethod]
		public void Edit_NewClientSettingsValidClientId_true()
		{
			//Arrange
			AddClient();
			AddClientSettings();

			var clientSettings = _genericSettings.One();
			clientSettings.IsActive = false;
			clientSettings.CloseTime = DateTime.Now;
			clientSettings.TotalUsers = 10;

			//Act
			var result = _clientSettingsRepo.Edit(clientSettings);
		

			//Assert
			Assert.IsInstanceOfType(result, typeof(IClientSettings));
			Assert.IsNotNull(result);
			Assert.AreEqual(result.IsActive, clientSettings.IsActive);
            VerifyLogInfo();
		}

		[TestMethod]
		public void Edit_NewClientSettingsInvalidClientId_False()
		{
			//Arrange
			AddClient();
			AddClientSettings();

			var clientSettings = _genericSettings.One();
			clientSettings.ClientId = 0;
			clientSettings.OpenTime = DateTime.Now;

			//Act
			var result = _clientSettingsRepo.Edit(clientSettings);

			//Assert
			Assert.IsNull(result);
            VerifyLogError();
		}

		#endregion

		#region SetOpenClosedTimes Test
		[TestMethod]
		public void SetOpenClosedTimes_PassValidClientIdAndDateTime_ClientSettingsWithNewTimes()
		{
			//Arrange
			var openingTime = new DateTime(2018, 1, 1, 8, 0, 0);
			var closingTime = new DateTime(2018, 1, 1, 17, 0, 0);
			AddClient();
			AddClientSettings();

			//Act
			var result = _clientSettingsRepo.SetOpenClosedTimes(openingTime, closingTime, 1);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IClientSettings));
			Assert.IsNotNull(result);
			Assert.AreEqual(result.OpenTime, openingTime);
			Assert.AreEqual(result.CloseTime, closingTime);
		}

		[TestMethod]
		public void SetOpenClosedTimes_PassInvalidClientIdAndDateTime_Null()
		{
			//Arrange
			var openingTime = new DateTime(2018, 1, 1, 8, 0, 0);
			var closingTime = new DateTime(2018, 1, 1, 17, 0, 0);
			AddClient();
			AddClientSettings();

			//Act
			var result = _clientSettingsRepo.SetOpenClosedTimes(openingTime, closingTime, 0);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void SetOpenClosedTimes_PassNullOpenTime_ShouldNotReplaceOldTimes()
		{
			//Arrange
			var openingTime = new DateTime(2018, 1, 1, 8, 0, 0);
			var closingTime = new DateTime(2018, 1, 1, 17, 0, 0);
			var clientSettings = _genericSettings.One();
			clientSettings.CloseTime = closingTime.AddHours(2);
			clientSettings.OpenTime = openingTime;

			var clientId = AddClient();
			AddClientSettings(clientSettings);

			//Act
			var result = _clientSettingsRepo.SetOpenClosedTimes(null, closingTime, clientId);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IClientSettings));
			Assert.IsNotNull(result);
			Assert.AreEqual(result.OpenTime, openingTime);
			Assert.AreEqual(result.CloseTime, closingTime);
		}
		#endregion

		#region AddTotalUser Test

		[TestMethod]
		public void AddTotalUsers_AddNumberOfNewUsers_IClientSettingsWithAdjustedUserCount()
		{
			//Arrange
			var clientSettings = _genericSettings.One();
			var clientId = AddClient();
			var originalTotalUsers = 5;
			var addUsers = 2;

			clientSettings.TotalUsers = originalTotalUsers;
			AddClientSettings(clientSettings);

			//Act
			var result = _clientSettingsRepo.AddTotalUsers(clientId, addUsers);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IClientSettings));
			Assert.AreEqual(result.TotalUsers, originalTotalUsers + addUsers);
		}

		[TestMethod]
		public void AddTotalUsers_AddNumberToInvalidClient_Null()
		{
			//Arrange
			var originalTotalUsers = 5;

			//Act
			var result = _clientSettingsRepo.AddTotalUsers(0, 12);

			//Assert
			Assert.IsNull(result);
		}
		#endregion

		#region Generic Test Methods
		private int AddClient(Client client = null)
		{
			client = client ?? _clients.One(0);
			Reset();

			_db.Clients.Add(client);
			((StockTrackerContext)_db).SaveChanges();

			return client.ClientId;
		}

		private void AddClientSettings(ClientSettings clientSettings = null)
		{
			clientSettings = clientSettings ?? _genericSettings.One(0);

			_db.ClientSettings.Add(clientSettings);
			((StockTrackerContext)_db).SaveChanges();
		}

		private void Reset()
		{
			((StockTrackerContext)_db).Database.EnsureDeleted();
		}

	    private void VerifyLogInfo()
	    {
            _mock.Verify(i => i.LogInformation(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
	    }

	    private void VerifyLogError()
	    {
            _mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
	    }

	    private void VerifyLogErrorException()
	    {
            _mock.Verify(i => i.LogError(It.IsAny<int>(), It.IsAny<Exception>(), It.IsAny<string>()), Times.Once);
	    }

	    #endregion
	}
}
