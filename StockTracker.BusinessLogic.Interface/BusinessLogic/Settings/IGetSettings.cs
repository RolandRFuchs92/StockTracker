using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models;
using StockTracker.Interface.Models.Client;
using StockTracker.Interface.Models.Settings;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Settings
{
    public interface IGetSettings
    {
	    bool IsAnyoneAbleToAddStock(int clientId);
	    bool IsAnyoneAbleToAddStock(IClient client);
	    DateTime OpenTime(int clientId);
	    DateTime CloseTime(int clientId);
	    IClientSettings ClientSettings(int clientId);
	    bool CanEmailManagers(int clientId);
    }
}
