using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;
using StockTracker.Repository.Interface.Clients;

namespace StockTracker.Repository.Clients
{
    public class ClientSettingsRepo : IClientSettingsRepo
    {
	    private IStockTrackerContext _db;

	    public ClientSettingsRepo(IStockTrackerContext db)
	    {
		    _db = db;
	    }


	    public IClientSettings AddClientSettings(IClientSettings settings)
	    {
		    try
		    {
			    var currentClient = GetClient(settings.ClientId);

			    if (currentClient == null)
				    return null;

			    _db.ClientSettings.Add((ClientSettings)settings);
				var result = ((StockTrackerContext) _db).SaveChanges();
			    if (result == 0)
				    return null;

			    return _db.ClientSettings.FirstOrDefault(i => i.ClientId == settings.ClientId);
		    }
		    catch (Exception e)
		    {
				//TODO: ADD LOGGING
			    return null;
		    }
	    }

	    public IClientSettings IsActive(int clientId, bool isActive)
	    {
		    try
		    {
			    var clientSettings = _db.Clients.Include(i => i.ClientSettings).FirstOrDefault(i => i.ClientId == clientId)?.ClientSettings;
			    if (clientSettings == null)
				    return null;

			    clientSettings.IsActive = isActive;
			    var result = ((StockTrackerContext) _db).SaveChanges();

			    return result > 0 ? clientSettings : null;
		    }
		    catch (Exception e)
		    {
				//TODO: ADD LOGGING
			    return null;
		    }
	    }

	    public IClientSettings IsDeleted(int clientId, bool isDeleted)
	    {
		    try
		    {
			    var clientSettings = _db.Clients.FirstOrDefault(i => i.ClientId == clientId)?.ClientSettings;
			    if (clientSettings == null)
				    return null;

			    clientSettings.IsDeleted = isDeleted;
			    if (isDeleted)
				    clientSettings.DateDeleted = DateTime.Now;
			    else
				    clientSettings.DateDeleted = null;

			    var result = ((StockTrackerContext) _db).SaveChanges();
			    return result > 0 ? clientSettings : null;
		    }
		    catch (Exception e)
		    {
				//TODO: ADD LOGGING
			    return null;
		    }

		}

	    public IClientSettings Edit(IClientSettings settings)
	    {
		    try
		    {
			    var clientSettings = _db.Clients.FirstOrDefault(i => i.ClientId == settings.ClientId)?.ClientSettings;
			    if (clientSettings == null)
				    return null;

			    clientSettings.IsActive = settings.IsActive;
			    clientSettings.CloseTime = settings.CloseTime;
			    clientSettings.OpenTime = settings.OpenTime;
			    clientSettings.DateDeleted = settings.DateDeleted;
			    clientSettings.TotalUsers = settings.TotalUsers;
			    clientSettings.CanAnyoneAddStock = settings.CanAnyoneAddStock;
			    clientSettings.CanEmailManagers = settings.CanEmailManagers;

			    var result = ((StockTrackerContext) _db).SaveChanges();
			    if (result > 0)
				    return settings;

			    return null;
		    }
		    catch (Exception e)
		    {
				//TODO: ADD LOGGING
			    return null;
		    }
	    }

	    public IClientSettings SetOpenClosedTimes(DateTime openTime, DateTime closedTime, int coreClientId)
	    {
		    throw new NotImplementedException();
	    }

	    public IClientSettings AddTotalUsers(int addUsers)
	    {
		    throw new NotImplementedException();
	    }

	    private IClient GetClient(int clientId)
	    {
		    return _db.Clients.FirstOrDefault( i=> i.ClientId == clientId);
	    }
    }
}
