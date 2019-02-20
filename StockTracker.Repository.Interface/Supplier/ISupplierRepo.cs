﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Supplier;

namespace StockTracker.Repository.Interface.Supplier
{
    public interface ISupplierRepo
    {
	    ISupplier Add(ISupplier supplier);
	    ISupplier Edit(ISupplier supplier);
	    List<ISupplier> List();
	    List<ISupplier> ListSuppliersByType(int supplierType);
	    ISupplier Get(int supplierId);
	    bool Delete(int supplierId);
    }
}
