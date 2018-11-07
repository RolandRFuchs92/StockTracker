using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Model.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Moq;
using StockTracker.BuisnessLogic.Clients;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.BusinessLogic.Inteface.Poco;
using StockTracker.Context;
using StockTracker.Interface.Models.Client;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Repository.Test;
using StockTracker.Seed.Clients;

namespace StockTracker.BusinessLogic.Test.Clients
{
	[TestClass]
	public class AddClientTest
	{
		private Mock<IClientRepo> _moqClientRepo;

		public AddClientTest()
		{
			var moqClientRepo = new Mock<IClientRepo>();
			moqClientRepo.Setup(i => i.Add(It.IsAny<IClient>())).Returns(true);
			_moqClientRepo = moqClientRepo;
		}

		#region AddClient Tests
		[TestMethod]
		public void AddClient_PassValidClients_False()
		{
			//Arrange
			var newClientList = new GenericClients().All();
			var addClient = new ClientLogic(_moqClientRepo.Object);
			var result = new Result<bool>();
			var lastClient = 0;

			//Act
			foreach (var client in newClientList)
			{
				result = (Result<bool>)addClient.AddClient(client);
				if (!result.IsSuccess)
				{
					lastClient = client.ClientId;
					break;
				}
			}

			//Assert
			Assert.IsTrue(result.IsSuccess, $"The last client checked was {lastClient}");
		}

		[TestMethod]
		public void AddClient_PassInvalidClients_false()
		{
			//Arrange
			var addClient = new ClientLogic(_moqClientRepo.Object);
			var result = new Result<bool>();
			var lastClient = 0;


			var clientList = new GenericClients().All().ToList();
			clientList.Add(clientList[0]);
			clientList[0].Email = "moo..@doo.web";//Pass bad email address
			clientList[1].ContactNumber = "abc123";
			clientList[2].Email = "";
			clientList[3].ContactNumber = "";

			//Act
			foreach (var client in clientList)
			{
				result = (Result<bool>)addClient.AddClient(client);
				if (result.IsSuccess)
				{
					lastClient = client.ClientId;
					break;
				}
			}

			//Assert
			Assert.IsFalse(result.IsSuccess, $"The last client checked was {lastClient}");
		}
		#endregion

		#region GetClient
		[TestMethod]
		public void GetClient_GetAClientbyClientId_GetClient()
		{
			//Arrange
			var client = new GenericClients().One();
			_moqClientRepo.Setup(i => i.Get(It.IsAny<int>())).Returns(client);
			var clientLogic = new ClientLogic(_moqClientRepo.Object);

			//Act
			var result = clientLogic.GetClient(client.ClientId);

			//Assert
			Assert.IsInstanceOfType(result.Body, typeof(IClient));
			Assert.IsTrue(result.IsSuccess);
		}

		[TestMethod]
		public void GetClient_GetAClientByIdThatDoesntExsist_NullFail()
		{
			//Arrange
			var moqRepo = new Mock<IClientRepo>();
			moqRepo.Setup(i => i.Get(It.IsAny<int>())).Returns(new Client());

			//Act
			var result = new ClientLogic(moqRepo.Object).GetClient(123);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IResult<IClient>));
		}
		#endregion

		#region EditClient Tests
		[TestMethod]
		public void EditClient_EditClientWithInvalidDetails_Fail()
		{
			//Arrange
			var client = new GenericClients().One();
			client.Email = "Roland..@ix.web";

			//Act
			var result = new ClientLogic(_moqClientRepo.Object).EditClient(client);

			//Assert
			Assert.IsInstanceOfType(result, typeof(IResult<bool>));
			Assert.IsFalse(result.IsSuccess);
		}

		[TestMethod]
		public void EditClient_EditClientWithValidDetails_Success()
		{
			//Arrange
			var client = new GenericClients().One();
			var moqRepo = new Mock<IClientRepo>();
			moqRepo.Setup(i => i.Get(It.IsAny<int>())).Returns(client);
			moqRepo.Setup(i => i.Edit(It.IsAny<IClient>())).Returns(true);

			client.Email = "hello@world.co.za";

			//Act
			var result = new ClientLogic(moqRepo.Object).EditClient(client);
			
			//Assert
			Assert.IsTrue(result.IsSuccess);
		}
		#endregion

		#region RemoveClient Tests
		[TestMethod]
		public void RemoveClient_PassValidClient_True()
		{
			//Arrange
			var moqRepo = new Mock<IClientRepo>();
			moqRepo.Setup(i => i.Remove(It.IsAny<int>())).Returns(true);
			var clientLogic = new ClientLogic(moqRepo.Object);

			//Act
			var result = clientLogic.RemoveClient(1);

			//Assert
			Assert.IsTrue(result.IsSuccess);
			Assert.IsTrue(result.Body);
			Assert.IsInstanceOfType(result, typeof(IResult<bool>));
		}

		[TestMethod]
		public void RemoveClient_PassInvalidClient_False()
		{
			//Arrange
			var moqRepo = new Mock<IClientRepo>();
			moqRepo.Setup(i => i.Remove(It.IsAny<int>())).Returns(false);
			var clientLogic = new ClientLogic(moqRepo.Object);


			//Act
			var result = clientLogic.RemoveClient(1);

			//Assert
			Assert.IsFalse(result.IsSuccess);
			Assert.IsFalse(result.Body);
			Assert.IsInstanceOfType(result, typeof(IResult<bool>));
		}


		#endregion

		#region ToggleClient Tests

		[TestMethod]
		public void ToggleClient_PassValidClient_True()
		{
			//Arrange
			var moq = new Mock<IClientRepo>();
			moq.Setup(i => i.Toggle(It.IsAny<int>(), It.IsAny<bool>())).Returns(true);
			var clientLogic = new ClientLogic(moq.Object);
			
			//Act
			var result = clientLogic.ToggleClient(1, true);

			//Assert
			Assert.IsTrue(result.IsSuccess);
			Assert.IsTrue(result.Body);
			Assert.IsInstanceOfType(result, typeof(IResult<bool>));
		}

		[TestMethod]
		public void ToggleClient_PassInvalidClient_True()
		{
			//Arrange
			var moq = new Mock<IClientRepo>();
			moq.Setup(i => i.Toggle(It.IsAny<int>(), It.IsAny<bool>())).Returns(false);
			var clientLogic = new ClientLogic(moq.Object);

			//Act
			var result = clientLogic.ToggleClient(1, true);

			//Assert
			Assert.IsFalse(result.IsSuccess);
			Assert.IsFalse(result.Body);
			Assert.IsInstanceOfType(result, typeof(IResult<bool>));
		}
		#endregion
	}
}
