using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.API.Interface.Clients
{
    public interface IClientSettingsController
    {
        IActionResult Add(IClientSettings settings);
        IActionResult IsActive(int clientId, bool isActive);
        IActionResult IsDeleted(int clientId, bool isDeleted);
        IActionResult Edit(IClientSettings settings);
        IActionResult SetBusinessHours(DateTime? openTime, DateTime? closeTime, int clientId);
        IActionResult AddTotalUsers(int clientId, int userCount);
    }
}
