using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Seed.Clients;
using StockTracker.Seed.Clients.Generic;

namespace StockTracker.Repository.Test.StockTracker.Clients
{
	[TestClass]
	public class ClientsRepoTest
	{
		private IStockTrackerContext _db;
		private IClientRepo _clientRepo;
		private GenericClients _genClient;

		public ClientsRepoTest()
		{
			_genClient = new GenericClients();
			_db = new TestDbFactory().Db;
			_clientRepo = new ClientRepo(_db);
		}

		private void Trunc(string tableName)
		{
			//((StockTrackerContext) _db).Database.ExecuteSqlCommand($"TRUNCATE TABLE {tableName}");
			((StockTrackerContext) _db).Database.EnsureDeleted(); ;
		}

		#region Add Tests
		[TestMethod]
		public void Add_PassNormalClientObject_True()
		{
			Trunc("Clients");
			//Arrange
			var client = new Client
			{
				Address = "1 Testvill place",
				ClientName = "Test the Cycles",
				ContactNumber = "+27 083 123 1456",
				CreatedOn = DateTime.Now,
				Email = "Roland@test.co.za",
				LastCheckup = null
			};

			//Act
			var result = _clientRepo.Add(client);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Add_PassEmptyClient_False()
		{
			//Arrange
			Trunc("Clients");
			Client client = null;

			//Act
			var result = _clientRepo.Add(client);

			//Assert
			Assert.IsFalse(result);
		}

		[TestMethod]
		public void Add_PassValidParams_True()
		{
			//Arrange
			Trunc("Clients");

			//Act
			var result = _clientRepo.Add(true, "Roland", "roland@ix.co.za", "0730520624");

			//Assert
			Assert.IsTrue(result);
		}
		#endregion


		#region Edit Tests
		[TestMethod]
		public void Edit_PassvalidClient_True()
		{
			//Arrange
			Trunc("Clients");
			var selectedClientIndex = 1;
			var newClient = _genClient.One(selectedClientIndex);
			var result = false;

			_db.Clients.Add(newClient);
			((StockTrackerContext) _db).SaveChanges();

			newClient.Email = "unthasbeentest@goodtests.com";
			newClient.ContactNumber = "+271234567";

			//Act
			result = _clientRepo.Edit(newClient);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Edit_PassInvalidClient_False()
		{
			//Arrange
			Trunc("Clients");
			var selectedClientIndex = 1;
			var newClient = _genClient.One(selectedClientIndex);
			var result = false;

			_db.Clients.Add(newClient);
			((StockTrackerContext) _db).SaveChanges();

			newClient.ClientId = 0;

			//Act
			result = _clientRepo.Edit(newClient);

			//Assert
			Assert.IsFalse(result);
		}
		#endregion

		#region Get Tests

		[TestMethod]
		public void Get_InsertNewClientReturnSameClientById_NewClient()
		{
			//Arrange
			Trunc("Clients");
			var newCLient = _genClient.One();
			var result = new Client();

			_db.Clients.Add(newCLient);
			((StockTrackerContext) _db).SaveChanges();
			
			//Act
			result = (Client)_clientRepo.Get(newCLient.ClientId);
			
			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(Client));
		}
		[TestMethod]
		public void Get_TryGetClientWhenNoneExsistById_null()
		{
			//Arrange
			Trunc("Clients");
			var result = new Client();

			//Act
			result = (Client) _clientRepo.Get(1);

			//Assert
			Assert.IsNull(result);
		}

		[TestMethod]
		public void Get_InsertNewClientReturnSameClientByName_NewClient()
		{
			//Arrange
			Trunc("Clients");
			var newClient = _genClient.One();

			_db.Clients.Add(newClient);
			((StockTrackerContext) _db).SaveChanges();
			//Act
			var result = _clientRepo.Get(newClient.ClientName);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(Client));
		}

		[TestMethod]
		public void Get_TryGetNewClientByName_Null()
		{
			//Arrange
			Trunc("Clients");

			//Act
			var result = _clientRepo.Get("");

			//Assert
			Assert.IsNull(result);
		}
		#endregion

	
	}
}
