using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Repository.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Seed.Clients;

namespace StockTracker.Repository.Test.StockTracker.Clients
{
	[TestClass]
	public class ClientsRepoTest
	{
		private IStockTrackerContext _db;
		private IClientRepo _clientRepo;

		public ClientsRepoTest()
		{
			Reset();
		}

		private void Reset()
		{
			_db = new TestDb().Db;
			_clientRepo = new ClientRepo(_db);
		}

		#region Add Tests
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
			var result = _clientRepo.Add(client);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Add_PassEmptyClient_False()
		{
			//Arrange
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

			//Act
			var result = _clientRepo.Add(true, "Roland", "roland@ix.co.za", "0730520624");

			//Assert
			Assert.IsTrue(result);
		}
		#endregion

		#region Remove Tests
		[TestMethod]
		public void Remove_PassvalidClientId_True()
		{
			//Arrange
			var clientTestIndex = 1;
			_db.Clients.Add(new GenericClients().One(clientTestIndex));
			((StockTrackerContext)_db).SaveChanges();
			var result = false;

			//Act
			result = _clientRepo.Remove(clientTestIndex);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Remove_PassInvalidClientId_False()
		{
			//Arrange
			var result = false;

			//Act
			result = _clientRepo.Remove(0);

			//Assert
			Assert.IsFalse(result);
		}
		#endregion

		#region Edit Tests
		[TestMethod]
		public void Edit_PassvalidClient_True()
		{
			//Arrange
			var selectedClientIndex = 1;
			var newClient = new GenericClients().One(selectedClientIndex);
			var result = false;

			_db.Clients.Add(newClient);
			((StockTrackerContext) _db).SaveChanges();
			newClient.Email = "unthasbeentest@goodtests.com";
			newClient.ContactNumber = "+271234567";
			newClient.IsActive = false;

			//Act
			result = _clientRepo.Edit(newClient);

			//Assert
			Assert.IsTrue(result);
		}

		[TestMethod]
		public void Edit_PassInvalidClient_False()
		{
			//Arrange
			var selectedClientIndex = 1;
			var newClient = new GenericClients().One(selectedClientIndex);
			var result = false;

			Reset();

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
		public void Get_InsertNewClientReturnSameClient_NewClient()
		{
			//Arrange
			var newCLient = new GenericClients().One();
			var result = new Client();

			Reset();

			_db.Clients.Add(newCLient);
			((StockTrackerContext) _db).SaveChanges();
			
			//Act
			result = (Client)_clientRepo.Get(newCLient.ClientId);
			
			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(Client));
		}
		#endregion

	}
}
