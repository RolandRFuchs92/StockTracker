using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Supplier
{
	public interface ISupplier
	{
		int SupplierId { get; set; }
		int SupplierTypeId { get; set; }
		string SupplierName { get; set; }
		string SupplierLocation { get; set; }
		string ContactNumber { get; set; }
		string Email { get; set; }
		string Address { get; set; }
	}
}
