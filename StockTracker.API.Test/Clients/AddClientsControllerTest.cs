﻿using System;
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
using StockTracker.Context;
using StockTracker.Interface.Models.Client;
using StockTracker.Model.Clients;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Repository.Test;
using StockTracker.Seed.Clients;

namespace StockTracker.API.Test.Clients
{
	[TestClass]
    public class AddClientsControllerTest
    {
	    private Mock<IClientLogic> _moq;
	    private Client _client;
	    private StockTrackerContext _db;

	    public AddClientsControllerTest()
	    {
		    _moq = new Mock<IClientLogic>();
			_client = new GenericClients().One();
		    _db = new TestDb().Db;
	    }

	    [TestMethod]
		public void Add_PassValidClients_OK()
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
		public void Add_PassInvalidClient_Badrequest()
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

		[TestMethod]
		public void Get_PassValidClientIdForGet_GetCorrectClient()
		{
			//Arrange
			var moqLoic = new Mock<IClientLogic>();
			var resultClient = new Result<IClient>()
			{
				Body = _client,
				IsSuccess = true,
				Message = "Wow look how cool you are!"
			};
			moqLoic.Setup(i => i.GetClient(It.IsAny<int>())).Returns(resultClient);
			var logic = moqLoic.Object;
			var controller = new ClientsController(logic);


			//Act
			var result = controller.Get(_client.ClientId) as OkObjectResult;
			var controllerResult = result.Value as Result<IClient>;

			//Assert
			Assert.IsInstanceOfType(result, typeof(OkObjectResult));
			Assert.IsTrue(controllerResult.IsSuccess);
		}

		[TestMethod]
		public void Get_PassInvalidClientForGet_BadRequest()
		{
			//Arrange
			var moqLogic = new Mock<IClientLogic>();
				moqLogic.Setup(i => i.GetClient(_client.ClientId)).Returns(new Result<IClient>(false));

			var controller = new ClientsController(moqLogic.Object);

			//Act
			var result = controller.Get(0);

			//Assert
			Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
		}

		[TestMethod]
		public void Edit_PassValidClient_EditedClient()
		{
			//Arrange
			var moqLogic = new Mock<IClientLogic>();

			//Act


			//Assert

		}

	}
}
