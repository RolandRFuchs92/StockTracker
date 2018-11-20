using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.BusinessLogic.Inteface.Client
{
    public interface IClientSettings
    {
		//VAN - verbAjectiveNoun
	    IClientSettings Add(IClientSettings clientSettings);
	    IClientSettings IsActive(int clientId, bool isActive);
	    IClientSettings IsDeleted(int clientId, bool isDeleted);
	    IClientSettings Edit(IClientSettings clientSettings);
	    IClientSettings SetBusinessHours(DateTime? openTime, DateTime? closeTime);
	    IClientSettings AddTotalUsers(int clientId, int AddUsers);
    }
}
