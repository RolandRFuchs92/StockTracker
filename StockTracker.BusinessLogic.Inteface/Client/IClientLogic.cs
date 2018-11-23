using StockTracker.BusinessLogic.Interface.Poco;
using StockTracker.Interface.Models.Clients;

namespace StockTracker.BusinessLogic.Interface.Client
{
	public interface IClientLogic
	{
		IResult<bool> AddClient(IClient newClient);
		IResult<bool> AddClient(string name, string email, string contactNumber);
		IResult<IClient> GetClient(int clientId);
		IResult<bool> EditClient(IClient client);
	}
}
