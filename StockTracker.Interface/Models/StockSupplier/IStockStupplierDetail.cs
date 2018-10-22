using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.StockSupplier
{
    public interface IStockStupplierDetail
    {
		int StockSupplierDetail { get; set; }
		int SupplierId { get; set; }
		int MemberId { get; set; }
		float Price { get; set; }
		int UnitTypeId { get; set; }
		int Unit { get; set; }
		DateTime CreatedOn { get; set; }
    }
}
