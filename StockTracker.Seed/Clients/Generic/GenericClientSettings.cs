﻿using System;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Seed.Abstract;
using StockTracker.Seed.Interface;

namespace StockTracker.Seed.Clients.Generic
{
    public class GenericClientSettings : GenericSeed<ClientSettings>
    {
	    public override ClientSettings[] All()
	    {
		    var viewModel = new[]
		    {
			    new ClientSettings
			    {
					ClientSettingsId = 1,
				    IsActive = true,
					ClientId = 1,
				    CanAnyoneAddStock = true,
				    CanEmailManagers = false,
				    CloseTime = new DateTime(2018, 1, 1, 8, 0, 0),
				    OpenTime = new DateTime(2018, 1, 1, 8, 0, 0),
				    DateDeleted = null,
				    IsDeleted = null,
				    TotalUsers = 3
			    },
			    new ClientSettings
			    {
					ClientSettingsId = 2,
				    IsActive = true,
					ClientId = 2,
				    CanAnyoneAddStock = true,
				    CanEmailManagers = false,
				    CloseTime = new DateTime(2018, 1, 1, 8, 0, 0),
				    OpenTime = new DateTime(2018, 1, 1, 8, 0, 0),
				    DateDeleted = null,
				    IsDeleted = null,
				    TotalUsers = 3
			    },
			    new ClientSettings
			    {
					ClientSettingsId = 3,
				    IsActive = true,
				    ClientId = 3,
				    CanAnyoneAddStock = true,
				    CanEmailManagers = false,
				    CloseTime = new DateTime(2018, 1, 1, 8, 0, 0),
				    OpenTime = new DateTime(2018, 1, 1, 8, 0, 0),
				    DateDeleted = null,
				    IsDeleted = null,
				    TotalUsers = 3
			    }
			};

		    return viewModel;
	    }
    }
}
