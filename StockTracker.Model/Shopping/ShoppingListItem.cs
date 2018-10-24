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
	    public int ShoppingListId { get; set; }
	    public int StockCoreId { get; set; }
		public int Quantity { get; set; }
		public bool IsCollected { get; set; }
	    public DateTime CreatedOn { get; set; }

	    [ForeignKey("StockCoreId")]
		public virtual StockCore StockItem { get; set; }
	    [ForeignKey("ShoppingListId")]
		public virtual ShoppingList ShoppingList { get; set; }
    }
}
