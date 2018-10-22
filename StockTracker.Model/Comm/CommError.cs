using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Comm;

namespace StockTracker.Model.Comm
{
    public class CommError : ICommError
    {
	    public int CommErrorId { get; set; }
	    public string StackTrace { get; set; }
	    public string Exception { get; set; }
	    public string Note { get; set; }
	    public DateTime CreatedOn { get; set; }
    }
}
