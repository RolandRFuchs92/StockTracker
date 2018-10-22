using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Comm
{
    public interface ICommCore
    {
        int CommTypeId { get; set; }
		int CommSendStatusTypeId { get; set;}
		int CommDetailId { get; set; }
		DateTime ChangedOn { get; set; }
		DateTime CreatedOn { get; set; }
    }
}
