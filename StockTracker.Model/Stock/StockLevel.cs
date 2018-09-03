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
    public class StockLevel: IStockLevel
    {
		[Key]
	    public int StockLevelId { get; set; }
	    public int StockItemId { get; set; }
	    public int Quantity { get; set; }
	    public DateTime DateChecked { get; set; }
	    public int MemberId { get; set; }

		[ForeignKey("MemberId")]
		public Member Member { get; set; }
    }
}
