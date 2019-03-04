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
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;
using StockTracker.ViewModel.Clients;

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
		public IActionResult Add(ClientFormViewModel client)
		{
			var result = _clientLogic.Add(ViewModelToModel(client));
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
		public IActionResult Edit(ClientFormViewModel client)
		{
			var result = _clientLogic.EditClient(ViewModelToModel(client));
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		public IActionResult GetAll()
		{
			var result = _clientLogic.GetAll();
			if (result.IsSuccess)
				return Ok(result);

			return BadRequest(result);
		}

		IClient ViewModelToModel(ClientFormViewModel client)
		{
			return new Client
			{
				Address = client.Address,
				ClientId = client.ClientId,
				ClientName = client.Name,
				ContactNumber = client.ContactNumber,
				Email = client.Email
			};
		}
	}
}