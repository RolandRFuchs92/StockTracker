using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Model.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StockTracker.BuisnessLogic.Clients;
using StockTracker.Context;
using StockTracker.Interface.Models.Client;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Repository.Test;

namespace StockTracker.BusinessLogic.Test.Clients
{
	[TestClass]
	public class AddClientTest
	{
		private StockTrackerContext _db;

		public AddClientTest()
		{
			_db = new TestDb().Db;
		}

		[TestMethod]
		public void AddClient_PassValidClients_False()
		{
			//Arrange
			var newClientList = new[]
			{
								new Client{
										ClientId = 1,
										Address ="Test address",
										ClientName ="Cammel Patrol",
										CreatedOn = DateTime.Now,
										ContactNumber = "0730730258",
										IsActive = false,
										Email = "moo@moo.co.za"
								},
								new Client{
										ClientId = 2,
										Address ="Test address 2",
										ClientName ="Cammel Dog lane",
										CreatedOn = DateTime.Now,
										ContactNumber = "111 023 1234",
										IsActive = true,
										Email = "moo@mooo.gov.za"
								},
								new Client{
										ClientId = 2,
										Address ="Test address",
										ClientName ="Camel Patrol",
										CreatedOn = DateTime.Now,
										ContactNumber = "(011) 023 1234",
										IsActive = true,
										Email = "moo@111.111.111.111"
								}
						};


			var moqClientRepo = new Mock<IAddClientRepo>();
			moqClientRepo.Setup(i => i.Add(It.IsAny<IClient>())).Returns(true);

			var addClient = new AddClients(moqClientRepo.Object);
			var result = false;
			var lastClient = 0;

			//Act
			foreach (var client in newClientList)
			{
				result = addClient.AddClient(client);
				if (!result)
				{
					lastClient = client.ClientId;
					break;
				}
			}

			//Assert
			Assert.IsTrue(result, $"The last client checked was {lastClient}");
		}

	}
}
