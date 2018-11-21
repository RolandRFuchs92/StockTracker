using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.BusinessLogic.Inteface.Poco;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.BusinessLogic.Inteface.Client
{
    public interface IClientSettingsLogic
    {
		//VAN - verbAjectiveNoun
	    IResult<IClientSettings> Add(IClientSettings clientSettings);
		IResult<IClientSettings> IsActive(int clientId, bool isActive);
		IResult<IClientSettings> IsDeleted(int clientId, bool isDeleted);
		IResult<IClientSettings> Edit(IClientSettings clientSettings);
		IResult<IClientSettings> SetBusinessHours(DateTime? openTime, DateTime? closeTime, int clientId);
		IResult<IClientSettings> AddTotalUsers(int clientId, int AddUsers);
    }
}
