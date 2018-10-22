using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Unit;

namespace StockTracker.Model.Unit
{
    public class UnitType : IUnitType
    {
	    public int UnitTypeId { get; set; }
	    public string Name { get; set; }
	    public string Symbol { get; set; }
    }
}
