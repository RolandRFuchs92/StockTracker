using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Adapter.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;
using StockTracker.Repository.Enums;
using StockTracker.Repository.Interface.Clients;


namespace StockTracker.Repository.Clients
{
		public class ClientRepo : IClientRepo
		{
				private IStockTrackerContext _db;
				private ILoggerAdapter<ClientRepo> _log;

				public ClientRepo(IStockTrackerContext db, ILoggerAdapter<ClientRepo> log)
				{
						_db = db;
						_log = log;
				}

				public bool Add(IClient newClient)
				{
						try
						{
								newClient.CreatedOn = DateTime.MinValue == newClient.CreatedOn ? DateTime.Now : newClient.CreatedOn;
								_db.Clients.Add((Client)newClient);
								var clientId = ((StockTrackerContext)_db).SaveChanges();

								return LogSuccess(LoggingEvent.Create, $"Added Client[{clientId}]"); ;
						}
						catch (Exception e)
						{
								return LogError(LoggingEvent.Create, e, "Error creating new Client");
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

				public bool Edit(IClient editClient)
				{
						if (editClient.ClientId == 0)
								return LogError(LoggingEvent.Update, "Invalid ClientId");

						try
						{
								var client = _db.Clients.FirstOrDefault(i => i.ClientId == editClient.ClientId);

								client.ClientName = editClient.ClientName ?? client.ClientName;
								client.ContactNumber = editClient.ContactNumber ?? client.ContactNumber;
								client.Email = editClient.Email ?? client.Email;
								client.Address = editClient.Address ?? client.Address;
								client.LastCheckup = editClient.LastCheckup;

								var clientId = ((StockTrackerContext)_db).SaveChanges();

								return LogSuccess(LoggingEvent.Update, $"Updated Client[{clientId}]");
						}
						catch (Exception e)
						{
								return LogError(LoggingEvent.Update, e, $"Unable to edit Client[{editClient.ClientId}]");
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

								((StockTrackerContext)_db).SaveChanges();
								return LogSuccess(LoggingEvent.Update, $"Toggled Client[{clientId}] to Active={isActive}");
						}
						catch (Exception e)
						{
								return LogError(LoggingEvent.Update, e, $"Error toggling Client[{clientId}] to Active={isActive}");
						}
				}

				bool LogError(LoggingEvent evt, string message)
				{
						_log.LogError((int)evt, message);
						return false;
				}

				bool LogError(LoggingEvent evt, Exception e, string message)
				{
						_log.LogError((int)evt, e, message);
						return false;
				}

				bool LogSuccess(LoggingEvent evt, string message)
				{
						_log.LogInformation((int)evt, message);
						return true;
				}
		}
}
