using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Clients;
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

	    public bool AddClientSettings(IClientSettings settings)
	    {
		    throw new NotImplementedException();
	    }

	    public bool IsActive(int clientId, bool isActive)
	    {
		    throw new NotImplementedException();
	    }

	    public bool IsDeleted(int clientId, bool isDeleted)
	    {
		    throw new NotImplementedException();
	    }

	    public bool Edit(IClientSettings settings, int clientId)
	    {
		    throw new NotImplementedException();
	    }

	    public bool SetOpenClosedTimes(DateTime openTime, DateTime closedTime)
	    {
		    throw new NotImplementedException();
	    }

	    public int AddTotalUsers(int addUsers)
	    {
		    throw new NotImplementedException();
	    }
    }
}
