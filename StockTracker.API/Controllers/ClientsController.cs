using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTracker.BusinessLogic.Inteface.Client;

namespace StockTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
	    private IAddClient _addClient;

	    public ClientsController(IAddClient addClient)
	    {
		    _addClient = addClient;
	    }

		[Route("AddClient")]
	    public IActionResult AddClient(bool isActive, string name, string email, string contactNumber)
		{
			var result = _addClient.AddClient(isActive, name, email, contactNumber);
			if(result.IsSuccess)
				return Ok(result.Message);

			return BadRequest(result.Message);
		}

    }
}