using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Adapter.Logger;

namespace StockTracker.API.Controllers
{
		[Route("api/[controller]")]
		public class LogController : ControllerBase
		{
				private readonly ILoggerAdapter<LogController> _log;

				public LogController(ILoggerAdapter<LogController> logger)
				{
						_log = logger;
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