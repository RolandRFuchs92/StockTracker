using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Supplier;
using StockTracker.Model.StockSupplier;

namespace StockTracker.Model.Supplier
{
		public class Supplier : ISupplier
		{
				public int SupplierId { get; set; }
				public int SupplierTypeId { get; set; }
				public string SupplierName { get; set; }
				public string SupplierLocation { get; set; }
				public string ContactNumber { get; set; }
				public string Email { get; set; }
				public string Address { get; set; }

				public virtual SupplierType SupplierType { get; set; }
				public virtual StockSupplierDetail StockSupplierDetail { get; set; }
		}
}
