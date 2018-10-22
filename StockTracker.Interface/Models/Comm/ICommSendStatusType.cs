using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Comm
{
    public interface ICommSendStatusType
    {
	    int CommSendStatusTypeId { get; set; }
		string CommSendStatusName { get; set; }
    }
}
