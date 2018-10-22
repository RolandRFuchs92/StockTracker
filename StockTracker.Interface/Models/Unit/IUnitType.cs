using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Unit
{
	public interface IUnitType
	{
		int UnitTypeId { get; set; }
		string Name { get; set; }
		string Symbol { get; set; }
	}
}
