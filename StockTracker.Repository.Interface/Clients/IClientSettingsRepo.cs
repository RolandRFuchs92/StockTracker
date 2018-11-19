using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.Repository.Interface.Clients
{
    public interface IClientSettingsRepo
    {
	    bool AddClientSettings(IClientSettings settings);
	    bool IsActive(int clientId, bool isActive);
	    bool IsDeleted(int clientId, bool isDeleted);
	    bool Edit(IClientSettings settings, int clientId);
	    bool SetOpenClosedTimes(DateTime openTime, DateTime closedTime, int coreClientId);
	    int AddTotalUsers(int addUsers);
    }
}
