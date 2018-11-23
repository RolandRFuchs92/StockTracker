using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTracker.API.Interface.Clients;
using StockTracker.BusinessLogic.Interface.Client;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.API.Controllers
{
    public class ClientSettingsController : IClientSettingsController
    {
        private IClientSettingsLogic _clientSettingsLogic;

        public ClientSettingsController(IClientSettingsLogic settingsLogic)
        {
            _clientSettingsLogic = settingsLogic;
        }

        public IActionResult Add(IClientSettings settings)
        {
            if (settings.ClientId < 1)
                return new BadRequestObjectResult("No ClientId found.");

            var result = _clientSettingsLogic.Add(settings);

            if (result.IsSuccess)
                return new OkObjectResult(result);

            return new BadRequestObjectResult(result);
        }

        public IActionResult IsActive(int clientId, bool isActive)
        {
            var result = _clientSettingsLogic.IsActive(clientId, isActive);

            if(result.IsSuccess)
                return new OkObjectResult(result);

            return new BadRequestObjectResult(result);
        }

        public IActionResult IsDeleted(int clientId, bool isDeleted)
        {
            throw new NotImplementedException();
        }

        public IActionResult Edit(IClientSettings settings)
        {
            throw new NotImplementedException();
        }

        public IActionResult SetBusinessHours(DateTime? openTime, DateTime? closeTime, int clientId)
        {
            throw new NotImplementedException();
        }

        public IActionResult AddTotalUsers(int clientId, int userCount)
        {
            throw new NotImplementedException();
        }
    }
}
