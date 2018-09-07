using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.Stock;

namespace StockTracker.Model.Stock
{
    public class StockItem : IStockItem
    {
		[Key]
	    public int StockItemId { get; set; }
	    public int StockCategoryId { get; set; }
	    public string StockItemName { get; set; }
	    public float StockItemPrice { get; set; }
	    public DateTime DateCreated { get; set; }
	    public bool IsActive { get; set; }

		[ForeignKey("StockCategoryId")]
		public StockCategory StockCategory { get; set; }
    }
}
