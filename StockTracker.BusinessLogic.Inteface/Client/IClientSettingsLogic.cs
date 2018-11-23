using System;
using StockTracker.BusinessLogic.Interface.Poco;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.BusinessLogic.Interface.Client
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
