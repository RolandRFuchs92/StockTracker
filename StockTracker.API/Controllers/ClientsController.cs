using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockTracker.API.Interface;
using StockTracker.API.Interface.Clients;
using StockTracker.BusinessLogic.Interface.Client;
using StockTracker.Model.Clients;

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

		[Route("Add")]
		[HttpPost]
		public IActionResult Add(Client client)
		{
			var result = _clientLogic.AddClient(client);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		[Route("Get")]
		[HttpGet]
		public IActionResult Get(int clientId)
		{
			var result = _clientLogic.GetClient(clientId);
			if (!result.IsSuccess)
				return BadRequest(result.Message);

			return Ok(result);
		}

		[Route("Edit")]
		[HttpPost]
		public IActionResult Edit(Client client)
		{
			var result = _clientLogic.EditClient(client);
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}
	}
}