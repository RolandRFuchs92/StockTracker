using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Adapter.Logger;
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
				private ILoggerAdapter<ClientsController> _log;

				public ClientsController(IClientLogic clientLogic, ILogger<ClientsController> log)
				{
						_clientLogic = clientLogic;
						_log = new LoggerAdapter<ClientsController>(log);
				}

				[Route("Log")]
				[HttpGet]
				public IActionResult Log() 
				{
						_log.LogInformation(1, "MOOOOOOOOOOOOOOOOOOOOOO");

						return Ok(new { message = "Hello, World!"});
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