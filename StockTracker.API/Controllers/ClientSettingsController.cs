using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTracker.API.Interface.Clients;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.BusinessLogic.Interface.Client;
using StockTracker.BusinessLogic.Interface.Poco;
using StockTracker.Interface.Models.Clients;
using StockTracker.Model.Clients;

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
                return new BadRequestObjectResult(new Result<IClientSettings>("No ClientId found."));

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
            var result = _clientSettingsLogic.IsDeleted(clientId, isDeleted);

            if (result.IsSuccess)
                return new OkObjectResult(result);

            return new BadRequestObjectResult(result);
        }

        public IActionResult Edit(IClientSettings settings)
        {
            if (settings.ClientId == 0 || settings.ClientSettingsId == 0)
                return new BadRequestObjectResult(new Result<IClientSettings>("No Client or Settings Id was specified."));

            return GenericResponse(_clientSettingsLogic.Edit(settings));
        }

        public IActionResult SetBusinessHours(DateTime? openTime, DateTime? closeTime, int clientId)
        {
            if ((int) clientId == 0)
                return new BadRequestObjectResult(new Result<IClientSettings>("No clientId was supplied."));

            return GenericResponse(_clientSettingsLogic.SetBusinessHours(openTime,closeTime,clientId));
        }

        public IActionResult AddTotalUsers(int clientId, int userCount)
        {
            if ((int) clientId == 0)
                return new BadRequestObjectResult(new Result<IClientSettings>("No Id was added"));

            return GenericResponse(_clientSettingsLogic.AddTotalUsers(clientId, userCount));
        }

        IActionResult GenericResponse<T>(IResult<T> result)
        {
            if (result.IsSuccess)
                return new OkObjectResult(result);

            return new BadRequestObjectResult(result);
        }
    }
}
