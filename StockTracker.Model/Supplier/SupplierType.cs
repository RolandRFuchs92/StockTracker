using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Supplier;

namespace StockTracker.Model.Supplier
{
    public class SupplierType : ISupplierType
    {
	    public int SupplierTypeId { get; set; }
	    public string SupplierTypeName { get; set; }
    }
}
