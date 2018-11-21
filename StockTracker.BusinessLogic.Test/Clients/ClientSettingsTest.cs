using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.BusinessLogic.Inteface.Poco;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Seed.Clients;

namespace StockTracker.BusinessLogic.Test.Clients
{
    public class ClientSettingsTest
    {
	    private IClientSettingsLogic _clientSettingsLogic;
		private GenericClientSettings _genericClientSettings;

		public ClientSettingsTest()
	    {
		    _genericClientSettings = new GenericClientSettings();
	    }

	    #region Edit Test
		[TestMethod]
		public void Edit_PassValidClientWithNewSettings_IClientSettingsWithSameResults()
		{
			//Arrange
			var clientId = 1;
			var isActive = false;
			var clientSettings = _genericClientSettings.One(clientId);
			var moq = new Mock<IClientSettingsRepo>();

			clientSettings.IsActive = isActive;
			moq.Setup(i => i.IsActive(It.IsAny<int>(), It.IsAny<bool>())).Returns(clientSettings);

			//Act
			var result = _clientSettingsLogic.IsActive(clientId, false);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
			Assert.IsTrue(result.IsSuccess);
			Assert.AreEqual(result.Body.IsActive, result);
		}

		[TestMethod]
		public void Edit_PassInvalidClientWithSettings_Null()
		{
			//Arrange
			var badClientId = 0;
			var isActive = false;

			var moq = new Mock<IClientSettingsRepo>();
			moq.Setup(i => i.IsActive(It.IsAny<int>(), It.IsAny<bool>())).Returns((IClientSettings)null);

			//Act
			var result = _clientSettingsLogic.IsActive(badClientId, isActive);

			//Assert
			Assert.IsNull(result);
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

			//Act
			var result = _clientSettingsLogic.Add(clientSettings);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
			Assert.AreSame(clientSettings, result.Body);
		}

		[TestMethod]
		public void Add_PassInvalidClientInfo_Null()
		{
			//Arrange
			var moq = new Mock<IClientSettingsRepo>();
			var clientSettings = _genericClientSettings.One();


			//Act
			var result = _clientSettingsLogic.Add(clientSettings);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsFalse(result.IsSuccess);
			Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
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

			//Act
			var result = _clientSettingsLogic.IsDeleted(0, true);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
			Assert.IsTrue(result.IsSuccess);
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsInstanceOfType(result.Body, typeof(IClientSettings));
			Assert.AreSame(result.Body, result);
		}

		[TestMethod]
		public void IsDeleted_InitialConditionas_ExpectedResult()
		{
			//Arrange
			var moq = new Mock<IClientSettingsRepo>();
			moq.Setup(i => i.IsDeleted(It.IsAny<int>(), It.IsAny<bool>())).Returns((IClientSettings) null);

			//Act
			var result = _clientSettingsLogic.IsDeleted(2, false);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
			Assert.IsFalse(result.IsSuccess);
			Assert.IsTrue(!string.IsNullOrEmpty(result.Message));
			Assert.IsNull(result.Body);
		}
		#endregion

		#region IsActive Test
		[TestMethod]
		public void Edit_PassValidChanges_ValidResults()
		{
			//Arrange
			var clientSettings = _genericClientSettings.One();
			var isActive = true;
			var moq = new Mock<IClientSettingsRepo>();
			moq.Setup(i => i.AddClientSettings(It.IsAny<IClientSettings>())).Returns(clientSettings);

			//Act
			var result = _clientSettingsLogic.IsActive(1, isActive);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result.IsSuccess);
			Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
			Assert.IsTrue(string.IsNullOrEmpty(result.Message));
			Assert.IsInstanceOfType(result.Body, typeof(IClientSettings));
		}


		[TestMethod]
		public void Edit_InitialCondition_ExpectedResult()
		{
			//Arrange
			var moq = new Mock<IClientSettingsRepo>();
			moq.Setup(i => i.Edit(It.IsAny<IClientSettings>())).Returns((IClientSettings) null);

			//Act
			var result = _clientSettingsLogic.IsActive(0, false);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(IResult<IClientSettings>));
			Assert.IsFalse(result.IsSuccess);
			Assert.IsFalse(string.IsNullOrEmpty(result.Message));
			Assert.IsNull(result.Body);
		}
		#endregion


	}
}
