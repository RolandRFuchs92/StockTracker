using System;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStock
    {
	    int StockId { get; set; }
	    string StockName { get; set; }
		float StockPrice { get; set; }
		DateTime DateCreated { get; set; }
		bool IsActive { get; set; }
    }
}
