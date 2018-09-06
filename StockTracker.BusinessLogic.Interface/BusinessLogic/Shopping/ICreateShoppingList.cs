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
	    IShoppingList GenerateShiShoppingList(int clientId);
		
    }
}
