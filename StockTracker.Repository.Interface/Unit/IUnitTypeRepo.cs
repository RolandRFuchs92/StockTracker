using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Unit;

namespace StockTracker.Repository.Interface.Unit
{
    public interface IUnitTypeRepo
    {
	    IUnitType Add(string name, string symbol);
	    IUnitType Edit(IUnitType unitType);
	    List<IUnitType> List();
	    bool IsValid(int unitTypeId);
    }
}
