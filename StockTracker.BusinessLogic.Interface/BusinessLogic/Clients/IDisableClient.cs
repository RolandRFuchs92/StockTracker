using StockTracker.Interface.Models.Client;

namespace StockTracker.Repository.Interface.BusinessLogic.Clients
{
    public interface IDisableClient
    {
	    bool DisableClient(int clientId);
	    bool DisableClient(IClient client);
    }
}
