using StockTracker.Interface.Models.Client;

namespace StockTracker.Repository.Interface.BusinessLogic.Clients
{
    public interface IAddClient
    {
	    bool AddClient(IClient newClient);
	    bool AddClient(bool isActive, string name, string email, int contactNumber);
    }
}
