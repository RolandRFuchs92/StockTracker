using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Suppliers;

namespace StockTracker.Model.Suppliers
{
    public class SupplierType : ISupplierType
    {
	    public int SupplierTypeId { get; set; }
	    public string SupplierTypeName { get; set; }

		public ICollection<Supplier> Suppliers { get; set; }
    }
}
