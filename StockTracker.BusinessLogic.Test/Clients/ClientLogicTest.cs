using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Model.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Moq;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.BuisnessLogic.Clients;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.BusinessLogic.Interface.Poco;
using StockTracker.Context;
using StockTracker.Interface.Models.Clients;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Seed.Clients.Generic;
using StockTracker.Tests.Utils.MockVerifiers;
using Microsoft.Extensions.Logging;

namespace StockTracker.BusinessLogic.Test.Clients
{
    [TestClass]
    public class ClientLogicTest
    {
        private Mock<IClientRepo> _moqClientRepo;
        private GenericLoggerCheck<ClientLogic> _genericLogger;
        private ILoggerAdapter<ClientLogic> _logger;

        public ClientLogicTest()
        {
            _genericLogger = new GenericLoggerCheck<ClientLogic>();
            _logger = _genericLogger.Mock.Object;

            var moqClientRepo = new Mock<IClientRepo>();
            moqClientRepo.Setup(i => i.Add(It.IsAny<IClient>())).Returns(true);
            _moqClientRepo = moqClientRepo;
        }

        #region AddClient Tests
        [TestMethod]
        public void AddClient_PassValidClients_True()
        {
            //Arrange
            var newClientList = new GenericClients().All();
            var addClient = new ClientLogic(_moqClientRepo.Object, _logger);
            var result = new Result<bool>();
            var lastClient = 0;

            //Act
            foreach (var client in newClientList)
            {
                result = (Result<bool>)addClient.Add(client);
                if (!result.IsSuccess)
                {
                    lastClient = client.ClientId;
                    break;
                }
            }

            //Assert
            Assert.IsTrue(result.IsSuccess, $"The last client checked was {lastClient}");
            _genericLogger.Success(newClientList.Length);
        }

        [TestMethod]
        public void AddClient_PassInvalidClients_false()
        {
            //Arrange
            var addClient = new ClientLogic(_moqClientRepo.Object, _logger);
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
                result = (Result<bool>)addClient.Add(client);
                if (result.IsSuccess)
                {
                    lastClient = client.ClientId;
                    break;
                }
            }

            //Assert
            Assert.IsFalse(result.IsSuccess, $"The last client checked was {lastClient}");
            _genericLogger.Error(clientList.Count);
        }
        #endregion

        #region GetClient
        [TestMethod]
        public void GetClient_GetAClientbyClientId_GetClient()
        {
            //Arrange
            var client = new GenericClients().One();
            _moqClientRepo.Setup(i => i.Get(It.IsAny<int>())).Returns(client);
            var clientLogic = new ClientLogic(_moqClientRepo.Object, _logger);

            //Act
            var result = clientLogic.GetClient(client.ClientId);

            //Assert
            Assert.IsInstanceOfType(result.Body, typeof(IClient));
            Assert.IsTrue(result.IsSuccess);

            _genericLogger.Success();
        }

        [TestMethod]
        public void GetClient_GetAClientByIdThatDoesntExsist_NullFail()
        {
            //Arrange
            var moqRepo = new Mock<IClientRepo>();
            moqRepo.Setup(i => i.Get(It.IsAny<int>())).Returns((Client)null);

            //Act
            var result = new ClientLogic(moqRepo.Object, _logger).GetClient(123);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IResult<IClient>));
            _genericLogger.Error();
        }
        #endregion

        #region EditClient Tests
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
            var result = new ClientLogic(moqRepo.Object, _logger).EditClient(client);

            //Assert
            Assert.IsTrue(result.IsSuccess);
            _genericLogger.Success();
        }

        [TestMethod]
        public void EditClient_EditClientWithInvalidDetails_Fail()
        {
            //Arrange
            var client = new GenericClients().One();
            client.Email = "Roland..@ix.web";

            //Act
            var result = new ClientLogic(_moqClientRepo.Object, _logger).EditClient(client);

            //Assert
            Assert.IsInstanceOfType(result, typeof(IResult<bool>));
            Assert.IsFalse(result.IsSuccess);

            _genericLogger.Error();
        }


		#endregion

		#region ListAll

		[TestMethod]
		public void ListAll_PassNothing_ReturnEverythingNoLog()
		{
			//Arrange


			//Act


			//Assert

		}

	    #endregion

	}
}
