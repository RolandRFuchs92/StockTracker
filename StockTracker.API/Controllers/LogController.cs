using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockTracker.Adapter.Logger;

namespace StockTracker.API.Controllers
{
		[Route("api/[controller]")]
		public class LogController : ControllerBase
		{
				private readonly LoggerAdapter<LogController> _log;

				public LogController(ILogger<LogController> logger)
				{
						_log = new LoggerAdapter<LogController>(logger);
				}

				[Route("Log")]
				[HttpGet]
				public IActionResult Index()
				{
						_log.LogInformation(1, "Hello world.");
						return Ok(new { message = "moo." });
				}
		}
}