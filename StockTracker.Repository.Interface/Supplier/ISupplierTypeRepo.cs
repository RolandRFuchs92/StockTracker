using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Supplier;

namespace StockTracker.Repository.Interface.Supplier
{
    public interface ISupplierTypeRepo
    {
	    ISupplierType Add(ISupplierType supplier);
	    ISupplierType Edit(ISupplierType supplier);
	    bool Delete(int supplierTypeId);
	    List<ISupplierType> List();
    } 
}
