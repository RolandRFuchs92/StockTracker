using System;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStockLevel
    {
        int StockLevelId { get; set; }
		int StockItemId { get; set; }
		int Quantity { get; set; }
		DateTime DateChecked { get; set; }
		int MemberId { get; set; }
    }
}
