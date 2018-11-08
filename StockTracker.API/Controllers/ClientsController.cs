using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTracker.API.Interface;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.Interface.Models.Client;

namespace StockTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase, IClientsController
	{
	    private IClientLogic _clientLogic;

	    public ClientsController(IClientLogic clientLogic)
	    {
		    _clientLogic = clientLogic;
	    }

		[Route("AddClient")]
	    public IActionResult Add(bool isActive, string name, string email, string contactNumber)
		{
			var result = _clientLogic.AddClient(isActive, name, email, contactNumber);
			if(result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		public IActionResult Get(int clientId)
		{
			throw new NotImplementedException();
		}

		public IActionResult Edit(IClient client)
		{
			throw new NotImplementedException();
		}

		public IActionResult Remove(int clientId)
		{
			throw new NotImplementedException();
		}

		public IActionResult Toggle(int clientId, bool isActive)
		{
			throw new NotImplementedException();
		}

		[Route("AddClient")]
	    public IActionResult Add(IClient client)
	    {
		    var result = _clientLogic.AddClient(client);
		    if (result.IsSuccess)
			    return Ok(result);

		    return BadRequest(result);
	    }

	
	}
}