using StockTracker.Interface.Models.Client;
using StockTracker.Interface.Models.Person;
using StockTracker.Interface.Models.User;

namespace StockTracker.Repository.Interface.BusinessLogic.Clients
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
