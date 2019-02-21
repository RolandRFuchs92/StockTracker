using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Suppliers;

namespace StockTracker.Repository.Interface.Suppliers
{
    public interface ISupplierTypeRepo
    {
	    ISupplierType Add(ISupplierType supplierType);
	    ISupplierType Edit(ISupplierType supplierType);
	    bool IsValid(int supplierTypeId);
	    List<ISupplierType> List();
    } 
}
