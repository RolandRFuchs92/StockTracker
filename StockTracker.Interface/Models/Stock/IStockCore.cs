using System;
using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStockCore
	{
		[Key]
	    int StockCoreId { get; set; }
		int StockCategoryId { get; set; }
		int StockSupplierDetailId { get; set; }
		int StockTypeId { get; set; }
	    string StockCoreName { get; set; }
		DateTime CreatedOn { get; set; }
    }
}
