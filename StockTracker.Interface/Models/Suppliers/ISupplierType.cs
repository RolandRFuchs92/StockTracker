﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Suppliers
{
	public interface ISupplierType
	{
		int SupplierTypeId { get; set; }
		string SupplierTypeName { get; set; }
	}
}
