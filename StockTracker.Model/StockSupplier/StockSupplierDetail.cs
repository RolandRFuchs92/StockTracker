using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.StockSupplier;
using StockTracker.Model.Unit;
using StockTracker.Model.User;

namespace StockTracker.Model.StockSupplier
{
    public class StockSupplierDetail : IStockStupplierDetail
    {
	    public int StockSupplierDetailId { get; set; }
	    public int SupplierId { get; set; }
	    public int MemberId { get; set; }
	    public float Price { get; set; }
	    public int UnitTypeId { get; set; }
	    public int Unit { get; set; }
	    public DateTime CreatedOn { get; set; }

		[ForeignKey("MemberId")]
		public virtual Member Member { get; set; }
		[ForeignKey("SupplierId")]
		public virtual Supplier.Supplier Supplier { get; set; }
		[ForeignKey("UnitTypeId")]
		public virtual UnitType UnitType { get; set; }
    }
}
