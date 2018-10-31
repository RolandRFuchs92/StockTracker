using StockTracker.Context.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.Interface.Models.Client;

namespace StockTracker.BuisnessLogic.Client
{
    public class AddClients : IAddClient
    {
	    private readonly IStockTrackerContext _db;

	    public AddClients(IStockTrackerContext db)
		{
			_db = db;
		}

	    public bool AddClient(IClient newClient)
	    {
		    return false;
	    }

	    public bool AddClient(bool isActive, string name, string email, string contactNumber)
	    {
		    throw new NotImplementedException();
	    }
    }
}
