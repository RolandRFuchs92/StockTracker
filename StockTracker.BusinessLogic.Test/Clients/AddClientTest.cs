﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
		private StockTrackerContext _db;
		private Mock<IClientRepo> _moqClientRepo;

		public AddClientTest()
		{
			var moqClientRepo = new Mock<IClientRepo>();
			moqClientRepo.Setup(i => i.Add(It.IsAny<IClient>())).Returns(true);
			_moqClientRepo = moqClientRepo;
		}

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
	}
}