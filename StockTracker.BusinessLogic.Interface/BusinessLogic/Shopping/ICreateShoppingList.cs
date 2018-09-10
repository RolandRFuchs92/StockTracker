using StockTracker.Interface.Models.Shopping;

namespace StockTracker.Repository.Interface.BusinessLogic.Shopping
{
    public interface ICreateShoppingList
    {
	    IShoppingList HighPriorityList(int clientId);
	    IShoppingList LowPriorityList(int clientId);
	    IShoppingList OutStandingShoppingList(int clientId);
    }
}
