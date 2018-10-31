using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Interface.Models.Client;
using StockTracker.Model.Clients;
using StockTracker.Repository.Interface.BusinessLogic.Clients;

namespace StockTracker.Repository.Clients
{
    public class AddClients : IAddClient
    {
	    private IStockTrackerContext _db;

	    public AddClients(IStockTrackerContext db)
	    {
		    _db = db;
	    }

	    public bool AddClient(IClient newClient)
	    {
		    try
		    {
			    _db.Clients.Add((Client)newClient);
			    ((StockTrackerContext)_db).SaveChanges();
			    return true;
		    }
		    catch (Exception e)
		    {
			    return false;
		    }

		}

		public bool AddClient(bool isActive, string name, string email, string contactNumber)
	    {
		    throw new NotImplementedException();
	    }
    }
}
