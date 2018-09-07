using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Clients;
using StockTracker.Model.User;

namespace StockTracker.Model.Stock
{
    public class StockLevel: IStockLevel
    {
		[Key]
	    public int StockLevelId { get; set; }
	    public int StockItemId { get; set; }
		public int ClientId { get; set; }
	    public int Quantity { get; set; }
	    public DateTime DateChecked { get; set; }
	    public int MemberId { get; set; }

		[ForeignKey("MemberId")]
		public Member Member { get; set; }
		[ForeignKey("ClientId")]
		public Client Client { get; set; }
		[ForeignKey("StockItemId")]
		public StockItem StockItem { get; set; }
    }
}
