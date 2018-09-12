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
	    public int StockParId { get; set; }
	    public int Quantity { get; set; }
	    public DateTime DateChecked { get; set; }
	    public bool IsActive { get; set; }

		[ForeignKey("StockParId")]
		public List<int> StockPars { get; set; }
    }
}
