using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Unit;
using StockTracker.Repository.Interface.Unit;

namespace StockTracker.Repository.Unit
{
    public class UnitTypeRepo : IUnitTypeRepo
    {
	    public IUnitType Add(string name, string symbol)
	    {
						try
						{

						}
						catch (Exception e)
						{

								throw;
						}
	    }

	    public IUnitType Edit(IUnitType unitType)
	    {
		    throw new NotImplementedException();
	    }

	    public IUnitType List()
	    {
		    throw new NotImplementedException();
	    }

	    public bool IsValid()
	    {
		    throw new NotImplementedException();
	    }
    }
}
