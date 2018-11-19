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
				IClientSettings AddClientSettings(IClientSettings settings);
				IClientSettings IsActive(int clientId, bool isActive);
				IClientSettings IsDeleted(int clientId, bool isDeleted);
				IClientSettings Edit(IClientSettings settings, int clientId);
				IClientSettings SetOpenClosedTimes(DateTime openTime, DateTime closedTime, int coreClientId);
				IClientSettings AddTotalUsers(int addUsers);
    }
}
