using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Clients;
using StockTracker.Repository.Interface.Clients;

namespace StockTracker.Repository.Clients
{
    public class ClientSettingsRepo 
    {
	    private IStockTrackerContext _db;

	    public ClientSettingsRepo(IStockTrackerContext db)
	    {
		    _db = db;
	    }

	 
    }
}
