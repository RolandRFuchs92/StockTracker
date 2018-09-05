using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Clients
{
    public interface IAddClient
    {
	    bool AddClient(IClient newClient);
	    bool AddClient(bool isActive, string name, string email, int contactNumber);
    }
}
