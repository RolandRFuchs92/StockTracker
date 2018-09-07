using System;
using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStockLevel
    {
		[Key]
        int StockLevelId { get; set; }
		int StockItemId { get; set; }
		int ClientId { get; set; }
		int Quantity { get; set; }
		DateTime DateChecked { get; set; }
		int MemberId { get; set; }
    }
}
