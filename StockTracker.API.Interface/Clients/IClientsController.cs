using Microsoft.AspNetCore.Mvc;
using StockTracker.Model.Clients;

namespace StockTracker.API.Interface.Clients
{
    public interface IClientsController
    {
	    IActionResult Add(Client client);
	    IActionResult Get(int clientId);
	    IActionResult Edit(Client client);
    }
}
