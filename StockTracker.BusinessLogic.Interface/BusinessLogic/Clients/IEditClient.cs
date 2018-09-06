using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Clients
{
    public interface IEditClient
    {
	    IClient RenameClient(int clientId, string name);
	    IClient RenameClient(IClient client, string name);
	    IClient Address(int clientId, string address);
	    IClient Address(IClient client, string address);
	    IClient Email(int clientId, string email);
	    IClient Email(IClient clientId, string email);
	    IClient Mobile(int clientId, string mobile);
	    IClient Mobile(IClient client, string mobile);
	    bool Disable(int clientId, bool isActive);

    }
}
