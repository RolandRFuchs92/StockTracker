using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.Comm;

namespace StockTracker.Model.Comm
{
    public class CommSendStatusType : ICommSendStatusType
    {
	    public int CommSendStatusTypeId { get; set; }
	    public string CommSendStatusName { get; set; }
    }
}
