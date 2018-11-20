using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;
using StockTracker.Model.ClientStock;
using StockTracker.Model.Member;
using StockTracker.Model.Person;
using StockTracker.Model.Shopping;
using StockTracker.Model.Stock;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Seed.Clients;

namespace StockTracker.Repository.Test.StockTracker.Clients
{
	[TestClass]
	public class ClientSettingsRepoTest
	{
		private IStockTrackerContext _db;
		private GenericClientSettings _genericSettings;
		private IClientSettingsRepo _clientSettingsRepo;
		private GenericClients _clients;

		public ClientSettingsRepoTest()
		{
			_db = new TestDb().Db;
			_genericSettings = new GenericClientSettings();
			_clientSettingsRepo = new ClientSettingsRepo(_db);
			_clients = new GenericClients();
		}

		#region AddClientSettings Test
		[TestMethod]
		public void AddClientSettings_PassValidClientSettings_ReturnTrue()
		{
			//Arrange
			AddClient();

			var clientSettings = _genericSettings.One();
			var clientSettingsRepo = new ClientSettingsRepo(_db);

			//Act
			var result = (ClientSettings)clientSettingsRepo.AddClientSettings(clientSettings);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IClientSettings));
			Assert.IsNotNull(result);
			Assert.AreSame(result, clientSettings);
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
		}


		[TestMethod]
		public void IsActive_PassInvalidClientId_false()
		{
			//Arrange
			var isActive = false;
			var clientId = AddClient();
			AddClientSettings();

			//Act
			var result = _clientSettingsRepo.IsActive(0, isActive);

			//Assert
			Assert.IsNull(result);
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
			Assert.AreEqual(result, clientSettings);
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
		public void AddTotalUsers_AddNumberOfNewUsers_True()
		{
			//Arrange
			var clientSettings = _genericSettings.One();

			//Act


			//Assert

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
		#endregion
	}
}
