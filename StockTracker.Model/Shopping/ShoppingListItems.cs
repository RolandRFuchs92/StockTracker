using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Model.Shopping
{
    public class ShoppingListItems : IShoppingListItems
    {
		[Key]
	    public int ShoppingListItemId { get; set; }
	    public int StockId { get; set; }
	    public int Quantity { get; set; }
	    public bool IsCollected { get; set; }
	    //public List<IStock> Stocks { get; set; }
    }
}
