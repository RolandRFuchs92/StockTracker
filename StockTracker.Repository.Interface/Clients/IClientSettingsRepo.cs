﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Client;

namespace StockTracker.Repository.Interface.Clients
{
    public interface IClientSettingsRepo
    {
	    bool AddClientSettings(IClientSettings settings);
    }
}