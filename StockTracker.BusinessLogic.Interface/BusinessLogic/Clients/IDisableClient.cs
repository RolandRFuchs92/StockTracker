using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models;
using StockTracker.Interface.Models.Client;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Clients
{
    public interface IDisableClient
    {
	    bool DisableClient(int clientId);
	    bool DisableClient(IClient client);
    }
}
