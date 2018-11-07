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
		private GenericClients _genClient;

		public ClientsRepoTest()
		{
			_genClient = new GenericClients();
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
		public void Remove_PassValidClientId_True()
		{
			//Arrange
			var newCient = _genClient.One();
			_db.Clients.Add(newCient);
			((StockTrackerContext)_db).SaveChanges();
			var result = false;

			//Act
			result = _clientRepo.Remove(newCient.ClientId);

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
			var newClient = _genClient.One(selectedClientIndex);
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
			var newClient = _genClient.One(selectedClientIndex);
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
		public void Get_InsertNewClientReturnSameClientById_NewClient()
		{
			//Arrange
			var newCLient = _genClient.One();
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
		[TestMethod]
		public void Get_TryGetClientWhenNoneExsistById_null()
		{
			//Arrange
			var result = new Client();
			Reset();

			//Act
			result = (Client) _clientRepo.Get(1);

			//Assert
			Assert.IsInstanceOfType(result, typeof(Client));
			Assert.IsNull(result);
		}

		[TestMethod]
		public void Get_InsertNewClientReturnSameClientByName_NewClient()
		{
			//Arrange
			var newClient = _genClient.One();
			Reset();

			_db.Clients.Add(newClient);
			((StockTrackerContext) _db).SaveChanges();
			//Act
			var result = _clientRepo.Get(newClient.ClientName);

			//Assert
			Assert.IsNotNull(result);
			Assert.IsInstanceOfType(result, typeof(Client));
		}

		[TestMethod]
		public void Get_TryGetNewClientR_ExpectedResult()
		{
			//Arrange
			Reset();

			//Act
			var result = _clientRepo.Get("");

			//Assert
			Assert.IsInstanceOfType(result, typeof(Client));
			Assert.IsNull(result);
		}
		#endregion


		#region Toggle Tests
		[TestMethod]
		public void Toggle_EnableDisableClient_True()
		{
			//Arrange
			var client = _genClient.One();
			client.IsActive = false;
			Reset();

			_db.Clients.Add(client);
			((StockTrackerContext) _db).SaveChanges();

			//Act
			var enableResult = _clientRepo.Toggle(client.ClientId, true);
			var disableResult = _clientRepo.Toggle(client.ClientId, false);

			//Assert
			Assert.IsTrue(enableResult);
			Assert.IsTrue(disableResult);
		}

		[TestMethod]
		public void Toggle_DisableEnabledClient_True()
		{
			//Arrange
			Reset();

			//Act
			var result = _clientRepo.Toggle(1, false);

			//Assert
			Assert.IsNull(result);
		}

		#endregion
	}
}
