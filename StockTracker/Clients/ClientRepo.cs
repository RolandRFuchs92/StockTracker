using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Client;
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
				IsActive = isActive,
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

		public bool Edit(IClient client)
		{
			throw new NotImplementedException();
		}

		public IClient Get(int clientId)
		{
			throw new NotImplementedException();
		}

		public IClient Get(string name)
		{
			throw new NotImplementedException();
		}

		public bool Toggle(int clientId, bool isActive)
		{
			throw new NotImplementedException();
		}
	}
}
