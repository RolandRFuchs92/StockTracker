using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;

namespace StockTracker.Repository.Test.StockTracker.Clients
{
		[TestClass]
		public class AddClientsTest
		{
				private IStockTrackerContext _db;
				private readonly IClientRepo _addClient;

				public AddClientsTest()
				{
						_db = new TestDb().Db;
						_addClient = new ClientRepo(_db);
				}

				[TestMethod]
				public void Add_PassNormalClientObject_True()
				{
						//Arrange
						var client = new Client
						{
								IsActive = true,
								Address = "1 Testvill place",
								ClientName = "Test the Cycles",
								ContactNumber = "+27 083 123 1456",
								CreatedOn = DateTime.Now,
								Email = "Roland@test.co.za",
								LastCheckup = null
						};

						//Act
						var result = _addClient.Add(client);

						//Assert
						Assert.IsTrue(result);
				}

				[TestMethod]
				public void Add_PassEmptyClient_False()
				{
						//Arrange
						Client client = null;

						//Act
						var result = _addClient.Add(client);

						//Assert
						Assert.IsFalse(result);
				}

				[TestMethod]
				public void Add_PassValidParams_True()
				{
						//Arrange

						//Act
						var result = _addClient.Add(true, "Roland", "roland@ix.co.za", "0730520624");

						//Assert
						Assert.IsTrue(result);
				}
		}
}
