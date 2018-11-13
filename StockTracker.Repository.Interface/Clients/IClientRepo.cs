﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.Repository.Interface.Clients
{
    public interface IClientRepo
    {
	    bool Add(IClient newClient);
	    bool Add(bool isActive, string name, string email, string contactNumber);
	    bool Remove(int clientId);
	    bool Edit(IClient editClient);
	    IClient Get(int clientId);
	    IClient Get(string name);
	    bool Toggle(int clientId, bool isActive);
    }
}
