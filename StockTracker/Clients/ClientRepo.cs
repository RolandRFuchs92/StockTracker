using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;
using StockTracker.Repository.Interface.Clients;


namespace StockTracker.Repository.Clients
{
	public class ClientRepo : IClientRepo
	{
		private IStockTrackerContext _db;

		public ClientRepo(IStockTrackerContext db)
		{
			_db = db;
		}

		public bool Add(IClient newClient)
		{
			try
			{
				if (newClient == null)
					return false;

				_db.Clients.Add((Client)newClient);
				((StockTrackerContext)_db).SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}

		}

		public bool Add(bool isActive, string name, string email, string contactNumber)
		{
			var client = new Client
			{
				ClientName = name,
				Email = email,
				ContactNumber = contactNumber
			};

			return Add(client);
		}

		public bool Remove(int clientId)
		{
			var client = _db.Clients.FirstOrDefault(i => i.ClientId == clientId);

			if (client == null)
				return false;

			try
			{
				client.IsDeleted = true;
				((StockTrackerContext) _db).SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}

		public bool Edit(IClient editClient)
		{
			if (editClient.ClientId == 0)
				return false;

			try
			{
				var client = _db.Clients.FirstOrDefault(i => i.ClientId == editClient.ClientId);

				client.ClientName = editClient.ClientName ?? client.ClientName;
				client.ContactNumber = editClient.ContactNumber ?? client.ContactNumber;
				client.Email = editClient.Email ?? client.Email;
				client.Address = editClient.Address ?? client.Address;
				client.LastCheckup = editClient.LastCheckup;

				((StockTrackerContext) _db).SaveChanges();
				return true;
			}
			catch (Exception E)
			{
				return false;
			}
		}

		public IClient Get(int clientId)
		{
			return _db.Clients.FirstOrDefault(i => i.ClientId == clientId);
		}

		public IClient Get(string name)
		{
			return _db.Clients.FirstOrDefault(i => name.Contains(i.ClientName));
		}

		public bool Toggle(int clientId, bool isActive)
		{
			try
			{
				var clientSettings = _db.ClientSettings.FirstOrDefault(i => i.ClientId == clientId);
				clientSettings.IsActive = isActive;

				((StockTrackerContext) _db).SaveChanges();
				return true;
			}
			catch (Exception e)
			{
				return false;
			}
		}
	}
}
