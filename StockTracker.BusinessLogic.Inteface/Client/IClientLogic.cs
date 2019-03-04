using System.Collections.Generic;
using StockTracker.BusinessLogic.Interface.Poco;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.BusinessLogic.Interface.Client
{
	public interface IClientLogic
	{
		IResult<bool> Add(IClient newClient);
		IResult<bool> Add(string name, string email, string contactNumber);
		IResult<IClient> GetClient(int clientId);
		IResult<List<IClient>> GetAll();
		IResult<bool> EditClient(IClient client);
	}
}
