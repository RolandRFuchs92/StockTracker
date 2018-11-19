using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Clients;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Seed.Clients;

namespace StockTracker.Repository.Test.StockTracker.Clients
{
		public class ClientSettingsRepoTest
		{
				private Mock<IStockTrackerContext> _db;
				private GenericClientSettings _genericSettings;
				private IClientSettingsRepo _clientSettingsRepo;

				public ClientSettingsRepoTest()
				{
						_db = new Mock<IStockTrackerContext>();
						_genericSettings = new GenericClientSettings();
				}

				#region AddClientSettings Test
				[TestMethod]
				public void AddClientSettings_PassValidClientSettings_ReturnTrue()
				{
						//Arrange
						var clientSettings = _genericSettings.One();


						//Act
						var result = _clientSettingsRepo.AddClientSettings(clientSettings);

						//Assert
						Assert.IsTrue(result);
				}

				[TestMethod]
				public void AddClientSettings_PassInvalidClientId_ReturnsFalse()
				{
						//Arrange
						var clientSettings = _genericSettings.One();

						clientSettings.ClientId = 0;

						//Act
						var result = _clientSettingsRepo.AddClientSettings(clientSettings);

						//Assert
						Assert.IsFalse(result);
				}
				#endregion

				#region IsActive Test
				[TestMethod]
				public void IsActive_PassClientIdAndValidActive_True()
				{
						//Arrange

						//Act
						var result = _clientSettingsRepo.IsActive(1, false);

						//Assert
						Assert.IsTrue(result);
				}


				[TestMethod]
				public void IsActive_PassInvalidClientId_false()
				{
						//Arrange


						//Act
						var result = _clientSettingsRepo.IsActive(0, false);


						//Assert
						Assert.IsTrue(result);
				}
				#endregion

				#region IsDeleted Test
				[TestMethod]
				public void IsDeleted_ValidClientIdAndFalse_True()
				{
						//Arrange


						//Act
						var result = _clientSettingsRepo.IsDeleted(1, false);

						//Assert
						Assert.IsTrue(result);
				}

				[TestMethod]
				public void IsDeleted_InvalidClientIdAndFalse_True()
				{
						//Arrange

						//Act
						var result = _clientSettingsRepo.IsDeleted(0, false);

						//Assert
						Assert.IsFalse(result);
				}
				#endregion

				#region Edit Test
				[TestMethod]
				public void Edit_NewClientSettingsValidClientId_true()
				{
						//Arrange
						var clientSettings = _genericSettings.One();

						//Act
						var result = _clientSettingsRepo.Edit(clientSettings, 1);

						//Assert
						Assert.IsTrue(result);
				}

				[TestMethod]
				public void Edit_NewClientSettingsInvalidClientId_False()
				{
						//Arrange
						var clientSettings = _genericSettings.One();

						//Act
						var result = _clientSettingsRepo.Edit(clientSettings, 0);

						//Assert
						Assert.IsFalse(result);
				}

				#endregion

				#region SetOpenClosedTimes Test
				[TestMethod]
				public void SetOpenClosedTimes_PassValidClientIdAndDateTime_True()
				{
						//Arrange
						var openingTime = new DateTime(2018, 1, 1, 8, 0, 0);
						var closingTime = new DateTime(2018, 1, 1, 17, 0, 0);

						//Act
						var result = _clientSettingsRepo.SetOpenClosedTimes(openingTime, closingTime, 1);

						//Assert
						Assert.IsInstanceOfType(result, typeof(IClientSettings));
						Assert.IsNotNull(result);
						Assert.AreSame(result.OpenTime, openingTime);
						Assert.AreSame(result.CloseTime, closingTime);
				}

				[TestMethod]
				public void SetOpenClosedTimes_PassInvalidClientIdAndDateTime_False()
				{
						//Arrange
						var openingTime = new DateTime(2018, 1, 1, 8, 0, 0);
						var closingTime = new DateTime(2018, 1, 1, 17, 0, 0);

						//Act
						var result = _clientSettingsRepo.SetOpenClosedTimes(openingTime, closingTime, 0);

						//Assert
						Assert.IsInstanceOfType(result, typeof(IClientSettings));
						Assert.IsNull(result);
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
		}
}
