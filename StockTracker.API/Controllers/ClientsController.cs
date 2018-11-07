using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.Interface.Models.Client;

namespace StockTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
	    private IClientLogic _addClient;

	    public ClientsController(IClientLogic addClient)
	    {
		    _addClient = addClient;
	    }

		[Route("AddClient")]
	    public IActionResult AddClient(bool isActive, string name, string email, string contactNumber)
		{
			var result = _addClient.AddClient(isActive, name, email, contactNumber);
			if(result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

	    [Route("AddClient")]
	    public IActionResult AddClient(IClient client)
	    {
		    var result = _addClient.AddClient(client);
		    if (result.IsSuccess)
			    return Ok(result);

		    return BadRequest(result);
	    }
	}
}