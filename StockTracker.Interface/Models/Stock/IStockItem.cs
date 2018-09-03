using System;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStockItem
    {
	    int StockItemId { get; set; }
	    string StockItemName { get; set; }
		float StockItemPrice { get; set; }
		DateTime DateCreated { get; set; }
		bool IsActive { get; set; }
    }
}
