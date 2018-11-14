using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Shopping;

namespace StockTracker.Model.Shopping
{
    public class ShoppingList : IShoppingList
    {
		[Key]
	    public int ShoppingListId { get; set; }
	    public int MemberId { get; set; }
	    public bool HasNotified { get; set; }
	    public DateTime CreatedOn { get; set; }

		public Member.Member Member { get; set; }
		public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
	}
}
