using System;
using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.Stock
{
    public interface IStockItem
    {
		[Key]
	    int StockCoreId { get; set; }
		int StockCategoryId { get; set; }
		int StockSupplierDetailId { get; set; }
		int StockTypeId { get; set; }
	    string StockItemName { get; set; }
		DateTime CreatedOn { get; set; }
    }
}
