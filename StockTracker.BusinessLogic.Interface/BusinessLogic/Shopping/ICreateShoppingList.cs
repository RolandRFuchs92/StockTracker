using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Shopping;

namespace StockTracker.BusinessLogic.Interface.BusinessLogic.Shopping
{
    public interface ICreateShoppingList
    {
	    IShoppingList HighPriorityList(int clientId);
	    IShoppingList LowPriorityList(int clientId);
	    IShoppingList OutStandingShoppingList(int clientId);
    }
}
