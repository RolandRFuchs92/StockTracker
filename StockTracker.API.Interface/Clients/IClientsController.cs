using Microsoft.AspNetCore.Mvc;
using StockTracker.Model.Clients;
using StockTracker.ViewModel.Clients;

namespace StockTracker.API.Interface.Clients
{
    public interface IClientsController
    {
	    IActionResult Add(ClientFormViewModel client);
	    IActionResult Get(int clientId);
	    IActionResult Edit(ClientFormViewModel client);
	    IActionResult GetAll();
    }
}
