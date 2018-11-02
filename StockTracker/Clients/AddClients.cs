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
		public class AddClientRepo : IAddClientRepo
		{
				private IStockTrackerContext _db;

				public AddClientRepo(IStockTrackerContext db)
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
		}
}
