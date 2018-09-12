using System;
using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStockLevel
    {
		[Key]
        int StockLevelId { get; set; }
		int StockParId { get; set; }
		int Quantity { get; set; }
		bool IsActive { get; set; }
		DateTime DateChecked { get; set; }
    }
}
