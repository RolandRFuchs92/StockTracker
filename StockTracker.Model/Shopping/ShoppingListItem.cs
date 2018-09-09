using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Shopping;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Stock;

namespace StockTracker.Model.Shopping
{
    public class ShoppingListItem : IShoppingListItem
    {
		[Key]
	    public int ShoppingListItemId { get; set; }
	    public int StockItemId { get; set; }
	    public int Quantity { get; set; }
	    public bool IsCollected { get; set; }
	    public int ShoppingListId { get; set; }

	    [ForeignKey("StockItemId")]
		public virtual StockItem StockItem { get; set; }
	    [ForeignKey("ShoppingListId")]
		public virtual ShoppingList ShoppingList { get; set; }
    }
}
