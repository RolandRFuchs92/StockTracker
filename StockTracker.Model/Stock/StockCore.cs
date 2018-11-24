using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.Stock;
using StockTracker.Model.Shopping;
using StockTracker.Model.StockSupplier;

namespace StockTracker.Model.Stock
{
    public class StockCore : IStockCore
	{
	    public int StockCoreId { get; set; }
	    public int StockCategoryId { get; set; }
	    public int StockSupplierDetailId { get; set; }
	    public int StockTypeId { get; set; }
	    public string StockCoreName { get; set; }
	    public DateTime CreatedOn { get; set; }

		public StockCategory StockCategory { get; set; }
		public StockSupplierDetail StockSupplierDetail { get; set; }
	    public StockType StockType { get; set; }

		public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
