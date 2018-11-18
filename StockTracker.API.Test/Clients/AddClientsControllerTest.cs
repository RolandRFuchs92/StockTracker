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
using StockTracker.Context;
using StockTracker.Interface.Models.Clients;
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


	    #region Add Client API
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
	    #endregion

		#region GET Client API



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

		//#region Remove Client API

		//[TestMethod]
		//public void Remove_PassValidClient_True()
		//{
		//	//Arrange
		//	var removeResult = new Result<bool>
		//	{
		//		Body = true,
		//		IsSuccess = true,
		//		Message = "Successfully Removed."
		//	};

		//	var moqLogic = new Mock<IClientLogic>();
		//	moqLogic.Setup(i => i.RemoveClient(It.IsAny<int>())).Returns(removeResult);
		//	var controller = new ClientsController(moqLogic.Object);

		//	//Act
		//	var result = controller.Remove(_client.ClientId) as OkObjectResult;
		//	var controllerResult = result.Value as Result<bool>;

		//	//Assert
		//	Assert.IsInstanceOfType(result, typeof(OkObjectResult));
		//	Assert.IsTrue(controllerResult.Body);
		//	Assert.IsTrue(controllerResult.IsSuccess);
		//}

		//[TestMethod]
		//public void Remove_PassinvalidClient_False()
		//{
		//	//Arrange
		//	var removeResult = new Result<bool>
		//	{
		//		Body = false,
		//		IsSuccess = false,
		//		Message = "Unable to Removed."
		//	};

		//	var moqLogic = new Mock<IClientLogic>();
		//	moqLogic.Setup(i => i.RemoveClient(It.IsAny<int>())).Returns(removeResult);
		//	var controller = new ClientsController(moqLogic.Object);

		//	//Act
		//	var result = controller.Remove(_client.ClientId) as BadRequestObjectResult;

		//	//Assert
		//	Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
		//}

		//#endregion

		//#region Toggle Client API

		//[TestMethod]
		//public void Toggle_PassValidClient_True()
		//{
		//	//Arrange
		//	var toggleResult = new Result<bool>
		//	{
		//		Body = true,
		//		IsSuccess = true,
		//		Message = "Toggle successful."
		//	};

		//	var moqLogic = new Mock<IClientLogic>();
		//	moqLogic.Setup(i => i.ToggleClient(It.IsAny<int>(), It.IsAny<bool>())).Returns(toggleResult);
		//	var controller = new ClientsController(moqLogic.Object);

		//	//Act
		//	var result = controller.Toggle(1, true) as OkObjectResult;
		//	var controllerResult = result.Value as Result<bool>;

		//	//Assert
		//	Assert.IsInstanceOfType(result, typeof(OkObjectResult));
		//	Assert.IsTrue(controllerResult.Body);
		//	Assert.IsTrue(controllerResult.IsSuccess);
		//}

		//[TestMethod]
		//public void Toggle_PassInvalidClient_False()
		//{
		//	//Arrange
		//	var toggleResult = new Result<bool>
		//	{
		//		Body = false,
		//		IsSuccess = false,
		//		Message = "Toggle failed!"
		//	};

		//	var moqLogic = new Mock<IClientLogic>();
		//	moqLogic.Setup(i => i.ToggleClient(It.IsAny<int>(), It.IsAny<bool>())).Returns(toggleResult);
		//	var controller = new ClientsController(moqLogic.Object);

		//	//Act
		//	var result = controller.Toggle(1, false);


		//	//Assert
		//	Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult), "unexpected result returned.");
		//}

		//#endregion
	}
}
