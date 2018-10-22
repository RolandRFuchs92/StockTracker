using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Comm
{
    public interface ICommError
    {
        int CommErrorId { get; set; }
		string StackTrace { get; set; }
		string Exception { get; set; }
		string Note { get; set; }
		DateTime CreatedOn { get; set; }
    }
}
