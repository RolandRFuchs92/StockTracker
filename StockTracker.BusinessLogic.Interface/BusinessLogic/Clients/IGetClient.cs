using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models;
using StockTracker.Interface.Models.Client;
using StockTracker.Interface.Models.User;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Clients
{
    public interface IGetClient
    {
	    IClient GetClient(int clientId);
	    IClient GetClientByMember(int memberId);
	    IClient GetClientByMember(IMember member);
	    IClient GetClientByPerson(int personId);
	    IClient GetClientByPerson(IPerson person);
	    IClient GetClientByPerson(string name, string surname);
	    IClient GetClient(string contactNumber);
	    IClient GetClientByEmail(string email);
    }
}
