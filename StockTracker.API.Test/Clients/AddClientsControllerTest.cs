using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.API.Controllers;
using StockTracker.BuisnessLogic.Clients;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.Interface.Models.Client;
using StockTracker.Model.Clients;
using StockTracker.Repository.Clients;
using StockTracker.Seed.Clients;

namespace StockTracker.API.Test.Clients
{
	[TestClass]
    public class AddClientsControllerTest
    {
	    private Mock<IClientLogic> _moq;
	    private Client _client;

	    public AddClientsControllerTest()
	    {
		    _moq = new Mock<IClientLogic>();
			_client = new GenericClients().One();
		}

	    [TestMethod]
		public void AddClient_PassValidClients_OK()
		{
			//Arrange
			_moq.Setup(i => i.AddClient(It.IsAny<IClient>())).Returns(new Result<bool>(true, "Added Successfully", "Failed..."));
			var logic = _moq.Object;
			var controller = new ClientsController(logic);

			//Act
			var result = controller.Add(_client);
			
			//Assert
			Assert.IsInstanceOfType(result, typeof(OkObjectResult));
		}

		[TestMethod]
		public void AddClient_PassInvalidClient_Badrequest()
		{
			//Arrange
			_moq.Setup(i => i.AddClient(It.IsAny<IClient>())).Returns(new Result<bool>(false));
			var logic = _moq.Object;
			var controller = new ClientsController(logic);

			//Act
			var result = controller.Add(_client);

			//Assert
			Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
		}
		
	}
}
