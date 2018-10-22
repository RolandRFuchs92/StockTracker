using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Supplier
{
	public class Supplier
	{
		public int SupplierId { get; set; }
		public int SupplierTypeId { get; set; }
		public string SupplierName { get; set; }
		public string SupplierLocation { get; set; }
		public string ContactNumber { get; set; }
		public string Email { get; set; }
		public string Address { get; set; }
	}
}
