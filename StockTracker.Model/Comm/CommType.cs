using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Comm;

namespace StockTracker.Model.Comm
{
    public class CommType : ICommType
    {
	    public int CommTypeId { get; set; }
	    public string CommName { get; set; }
    }
}
