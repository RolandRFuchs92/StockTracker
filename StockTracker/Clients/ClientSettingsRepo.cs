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
		    throw new NotImplementedException();
	    }

	    public IClientSettings IsDeleted(int clientId, bool isDeleted)
	    {
		    throw new NotImplementedException();
	    }

	    public IClientSettings Edit(IClientSettings settings, int clientId)
	    {
		    throw new NotImplementedException();
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
