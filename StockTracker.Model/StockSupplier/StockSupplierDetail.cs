using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.StockSupplier;
using StockTracker.Model.Members;
using StockTracker.Model.Stock;
using StockTracker.Model.Unit;

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

		public Member Member { get; set; }
		public Supplier.Supplier Supplier { get; set; }
		public UnitType UnitType { get; set; }

	    public StockCore StockCore { get; set; }
    }
}
