﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;
using StockTracker.Repository.Enums;
using StockTracker.Repository.Interface.Clients;

namespace StockTracker.Repository.Clients
{
		public class ClientSettingsRepo : IClientSettingsRepo
		{
				private IStockTrackerContext _db;
				private ILoggerAdapter<ClientSettingsRepo> _log;

				public ClientSettingsRepo(IStockTrackerContext db, ILoggerAdapter<ClientSettingsRepo> log)
				{
						_db = db;
						_log = log;
				}

				public IClientSettings AddClientSettings(IClientSettings settings)
				{
						try
						{
								var currentClient = GetClient(settings.ClientId);

								if (currentClient == null)
										return LogError(LoggingEvent.BadParameters, $"Client[{settings.ClientId}] is invalid.");

								_db.ClientSettings.Add((ClientSettings)settings);
								var result = ((StockTrackerContext)_db).SaveChanges();

								if (result == 0)
										return LogError(LoggingEvent.Create, $"Error creating ClientSettings for Client[{settings.ClientId}].");

								var clientSettings = _db.ClientSettings.FirstOrDefault(i => i.ClientId == settings.ClientId);
								return LogSuccess(clientSettings, LoggingEvent.Create, $"Created new ClientSettings[{clientSettings.ClientSettingsId}] for Client[{clientSettings.ClientId}]"); ;
						}
						catch (Exception e)
						{
								return LogError(LoggingEvent.Create, e, $"Error was thrown while creating ClientSettings for client[{settings.ClientId}]");
						}
				}

				public IClientSettings IsActive(int clientId, bool isActive)
				{
						try
						{
								var clientSettings = _db.Clients.Include(i => i.ClientSettings).FirstOrDefault(i => i.ClientId == clientId)?.ClientSettings;
								if (clientSettings == null)
										return LogError(LoggingEvent.BadParameters, $"Client[{clientId}] is invalid or doesn't have ClientSettings.");

								clientSettings.IsActive = isActive;
								var result = ((StockTrackerContext)_db).SaveChanges();

								return result > 0
																				? LogSuccess(clientSettings, LoggingEvent.Update, $"Updated Client[{clientId}] to IsActive={isActive}")
																				: LogError(LoggingEvent.Update, $"Did not update Client[{clientId}] to IsActive={isActive}");
						}
						catch (Exception e)
						{
								return LogError(LoggingEvent.Update, e, $"Unable to update Client[{clientId}] to IsActive=[{isActive}]");
						}
				}

				public IClientSettings IsDeleted(int clientId, bool isDeleted)
				{
						try
						{
								var clientSettings = _db.Clients.FirstOrDefault(i => i.ClientId == clientId)?.ClientSettings;
								if (clientSettings == null)
										return LogError(LoggingEvent.Delete, $"ClientId[{clientId}] is Invalid");

								if (clientSettings.IsDeleted == isDeleted)
										return LogSuccess(clientSettings, LoggingEvent.Delete, $"Client[{clientId}] is unaffected");

								clientSettings.IsDeleted = isDeleted;
								if (isDeleted)
										clientSettings.DateDeleted = DateTime.Now;
								else
										clientSettings.DateDeleted = null;

								var result = ((StockTrackerContext)_db).SaveChanges();
								return result > 0
																									? LogSuccess(clientSettings, LoggingEvent.Delete, $"Flagged Client[{clientId}] as IsDeleted={isDeleted}")
																: LogError(LoggingEvent.Delete, $"Unabled to flag Client[{clientId} as IsDeleted={isDeleted}]");
						}
						catch (Exception e)
						{
								return LogError(LoggingEvent.Delete, e, $"Error occured when trying to flag Client[{clientId}] as IsDeleted[{isDeleted}]");
						}

				}

				public IClientSettings Edit(IClientSettings settings)
				{
						try
						{
								var clientSettings = _db.Clients.FirstOrDefault(i => i.ClientId == settings.ClientId)?.ClientSettings;
								if (clientSettings == null)
										return LogError(LoggingEvent.Update, $"Client[{settings.ClientId}] is invalid");

								clientSettings.IsActive = settings.IsActive;
								clientSettings.CloseTime = settings.CloseTime;
								clientSettings.OpenTime = settings.OpenTime;
								clientSettings.DateDeleted = settings.DateDeleted;
								clientSettings.TotalUsers = settings.TotalUsers;
								clientSettings.CanAnyoneAddStock = settings.CanAnyoneAddStock;
								clientSettings.CanEmailManagers = settings.CanEmailManagers;

								var result = ((StockTrackerContext)_db).SaveChanges();
								clientSettings = _db.Clients.FirstOrDefault(i => i.ClientId == settings.ClientId).ClientSettings;

								if (result > 0)
										return LogSuccess(clientSettings, LoggingEvent.Update, $"Updated Client[{settings.ClientId}] with new settings");

								return LogError(LoggingEvent.Update, $"Unabled to edit Client{settings.ClientId} with new Settings");
						}
						catch (Exception e)
						{
								return LogError(LoggingEvent.Update, e, $"Error occured when trying to edit Client[{settings.ClientId}] with new ClientSettings");
						}
				}

				public IClientSettings SetOpenClosedTimes(DateTime? openTime, DateTime? closedTime, int clientId)
				{
						try
						{
								var clientSettings = _db.Clients.FirstOrDefault(i => i.ClientId == clientId)?.ClientSettings;
								if (clientSettings == null)
										return LogError(LoggingEvent.Update, $"Client[{clientId}] is invalid.");

								clientSettings.OpenTime = openTime ?? clientSettings.OpenTime;
								clientSettings.CloseTime = closedTime ?? clientSettings.CloseTime;

								return ((StockTrackerContext)_db).SaveChanges() > 0
																? LogSuccess(clientSettings, LoggingEvent.Update, $"Updated Opening and Closing times for client[{clientId}]")
																: LogError(LoggingEvent.Update, $"Unabled to update Client[{clientId}] Opening and Closing times.");
						}
						catch (Exception e)
						{
								return LogError(LoggingEvent.Update, e, $"Error occured when trying to update Client[{clientId}] open and closing times.");
						}
				}

				public IClientSettings AddTotalUsers(int clientId, int addUsers)
				{
						try
						{
								var clientSettings = _db.Clients.FirstOrDefault(i => i.ClientId == clientId)?.ClientSettings;

								if ((clientSettings.TotalUsers - addUsers) < 0)
										clientSettings.TotalUsers = 0;
								else
										clientSettings.TotalUsers += addUsers;

								return ((StockTrackerContext)_db).SaveChanges() > 0
												? LogSuccess(clientSettings, LoggingEvent.Update, $"Added to Client[{clientId}] Total Users")
												: LogError(LoggingEvent.Update, $"Unable to Add user count to Client[{clientId}]");
						}
						catch (Exception e)
						{
								return LogError(LoggingEvent.Update, e, $"An error occured when trying to Add Total Users to Client[{clientId}]");
						}
				}

				private IClient GetClient(int clientId)
				{
						return _db.Clients.FirstOrDefault(i => i.ClientId == clientId);
				}

				private IClientSettings LogSuccess(IClientSettings clientSettings, LoggingEvent evt, string message)
				{
						_log.LogInformation((int)evt, message);

						return clientSettings;
				}

				private IClientSettings LogError(LoggingEvent evt, Exception e, string message)
				{
						_log.LogError((int)evt, e, message);

						return (IClientSettings)null;
				}

				private IClientSettings LogError(LoggingEvent evt, string message)
				{
						_log.LogError((int)evt, message);

						return (IClientSettings)null;
				}
		}
}
