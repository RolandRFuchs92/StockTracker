using StockTracker.Interface.Models.Shopping;
using StockTracker.Model.Shopping;

namespace StockTracker.Repository.Interface.BusinessLogic.Shopping
{
    public interface ICreateShoppingList
    {
	    ShoppingList HighPriorityList(int clientId);
	    ShoppingList LowPriorityList(int clientId);
	    ShoppingList OutStandingShoppingList(int clientId);
    }
}
