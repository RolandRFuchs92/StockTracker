using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.StockSupplier;

namespace StockTracker.Model.Stock
{
    public class StockItem : IStockItem
    {
		[Key]
	    public int StockCoreId { get; set; }
	    public int StockCategoryId { get; set; }
	    public int StockSupplierDetailId { get; set; }
	    public int StockTypeId { get; set; }
	    public string StockItemName { get; set; }
	    public DateTime CreatedOn { get; set; }

		[ForeignKey("StockCategoryId")]
		public StockCategory StockCategory { get; set; }
		[ForeignKey("StockSupplierDetailId")]
		public StockSupplierDetail StockSupplierDetail { get; set; }
		[ForeignKey("StockTypeId")]
	    public virtual StockType StockType { get; set; }
    }
}
