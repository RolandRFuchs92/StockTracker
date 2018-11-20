using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.BusinessLogic.Inteface.Poco;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.BusinessLogic.Inteface.Client
{
	public interface IClientLogic
	{
		IResult<bool> AddClient(IClient newClient);
		IResult<bool> AddClient(string name, string email, string contactNumber);
		IResult<IClient> GetClient(int clientId);
		IResult<bool> EditClient(IClient client);
	}
}
