using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTracker.BusinessLogic.Inteface.Poco;
using StockTracker.Interface.Models.Client;

namespace StockTracker.API.Interface
{
    public interface IClientsController
    {
	    IActionResult Add(IClient client);
	    IActionResult Add(bool isActive, string name, string email, string contactNumber);
	    IActionResult Get(int clientId);
	    IActionResult Edit(IClient client);
	    IActionResult Remove(int clientId);
	    IActionResult Toggle(int clientId, bool isActive);

    }
}
