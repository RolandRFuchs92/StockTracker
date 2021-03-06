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
using StockTracker.BusinessLogic.Interface.Client;
using StockTracker.Context;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Seed.Clients.Generic;
using StockTracker.Tests.Utils.AbstractClasses;
using StockTracker.Tests.Utils.Context;
using StockTracker.ViewModel.Clients;

namespace StockTracker.API.Test.Clients
{
	[TestClass]
	public class AddClientsControllerTest : APITestUtils<IClientLogic>
	{
		private Mock<IClientLogic> _moq;
		private readonly ClientFormViewModel _client;
		private GenericClients _genericClients;
		private StockTrackerContext _db;

		private const string _getAll = nameof(IClientLogic.GetAll);

		public AddClientsControllerTest()
		{
			_moq = new Mock<IClientLogic>();
			_genericClients = new GenericClients();
			_client = CreateClientFormViewModle();
			_db = new TestDbFactory().Db();
		}

		private ClientFormViewModel CreateClientFormViewModle()
		{
			var model = _genericClients.One();
			return new ClientFormViewModel
			{
				Address = model.Address,
				ClientId = model.ClientId,
				ContactNumber = model.ContactNumber,
				Email = model.Email,
				Name = model.ClientName
			};
		}


		#region Add Client API
		[TestMethod]
		public void Add_PassValidClients_OK()
		{
			//Arrange
			_moq.Setup(i => i.Add(It.IsAny<IClient>())).Returns(new Result<bool>(true, "Added Successfully", "Failed..."));
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
			_moq.Setup(i => i.Add(It.IsAny<IClient>())).Returns(new Result<bool>(false));
			var logic = _moq.Object;
			var controller = new ClientsController(logic);

			//Act
			var result = controller.Add(_client);

			//Assert
			Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
		}
		#endregion

		#region GET Client API

		[TestMethod]
		public void Get_PassValidClientIdForGet_GetCorrectClient()
		{
			//Arrange
			var moqLoic = new Mock<IClientLogic>();
			var resultClient = new Result<IClient>()
			{
				Body = _genericClients.One(),
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
			var resultClient = new Result<IClient>()
			{
				Body = null,
				IsSuccess = false,
				Message = "Woops! Failed!"
			};
			var moqLogic = new Mock<IClientLogic>();
			moqLogic.Setup(i => i.GetClient(It.IsAny<int>())).Returns(resultClient);

			var controller = new ClientsController(moqLogic.Object);

			//Act
			var result = controller.Get(0);

			//Assert
			Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
		}
		#endregion

		#region Edit Client API
		[TestMethod]
		public void Edit_PassValidClient_True()
		{
			//Arrange
			var clientResult = new Result<bool>
			{
				Body = true,
				IsSuccess = true,
				Message = "Yay! We edited your client!"
			};

			var moqLogic = new Mock<IClientLogic>();
			moqLogic.Setup(i => i.EditClient(It.IsAny<IClient>())).Returns(clientResult);

			var controller = new ClientsController(moqLogic.Object);

			//Act
			var result = controller.Edit(_client) as OkObjectResult;
			var controllerResult = result.Value as Result<bool>;

			//Assert
			Assert.IsInstanceOfType(controllerResult, typeof(Result<bool>));
			Assert.IsTrue(controllerResult.Body);
			Assert.IsTrue(controllerResult.IsSuccess);
		}

		[TestMethod]
		public void Edit_PassInvalidClient_False()
		{
			//Arrange
			var clientResult = new Result<bool>
			{
				Body = false,
				IsSuccess = false,
				Message = "Woops! Not saved!"
			};

			var moqLogic = new Mock<IClientLogic>();
			moqLogic.Setup(i => i.EditClient(It.IsAny<IClient>())).Returns(clientResult);

			var controller = new ClientsController(moqLogic.Object);


			//Act
			var result = controller.Edit(_client) as BadRequestObjectResult;

			//Assert
			Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
		}
		#endregion

		#region GetAll API

		[TestMethod]
		public void GetAll_PassNothing_ReturnListOfClients()
		{
			//Arrange
			CreateService();

			//Act
			CreateResult(_getAll);

			//Assert
			Assert.AreEqual(GetAllListResult().Body.Count, Result<Result<List<IClient>>>().Body.Count);
		}

		#endregion

		#region Dry
		public override void CreateService()
		{
			var moq = new Mock<IClientLogic>();

			moq.Setup(i => i.GetAll()).Returns(GetAllListResult());
			
			_service = moq.Object;
		}

		Result<List<IClient>> GetAllListResult(bool isSuccess = false, string message = "Successfully retrieved Client LIst")
		{
			return new Result<List<IClient>>
			{
				Body = new GenericClients().All().ToList<IClient>(),
				IsSuccess = isSuccess,
				Message = message
			};
		}

		#endregion
	}
}
