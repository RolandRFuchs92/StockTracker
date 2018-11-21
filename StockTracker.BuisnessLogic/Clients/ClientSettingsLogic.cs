using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.BusinessLogic.Inteface.Poco;
using StockTracker.Interface.Models.Clients;
using StockTracker.Repository.Interface.Clients;

namespace StockTracker.BuisnessLogic.Clients
{
    public class ClientSettingsLogic : IClientSettingsLogic
    {
	    private IClientSettingsRepo _repo;

	    public ClientSettingsLogic(IClientSettingsRepo repo)
	    {
		    _repo = repo;
	    }

	    public IResult<IClientSettings> Add(IClientSettings clientSettings)
	    {
		    throw new NotImplementedException();
	    }

	    public IResult<IClientSettings> IsActive(int clientId, bool isActive)
	    {
		    throw new NotImplementedException();
	    }

	    public IResult<IClientSettings> IsDeleted(int clientId, bool isDeleted)
	    {
		    throw new NotImplementedException();
	    }

	    public IResult<IClientSettings> Edit(IClientSettings clientSettings)
	    {
		    throw new NotImplementedException();
	    }

	    public IResult<IClientSettings> SetBusinessHours(DateTime? openTime, DateTime? closeTime, int clientId)
	    {
		    throw new NotImplementedException();
	    }

	    public IResult<IClientSettings> AddTotalUsers(int clientId, int AddUsers)
	    {
		    throw new NotImplementedException();
	    }
    }
}
