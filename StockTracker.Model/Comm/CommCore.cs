using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.Comm;

namespace StockTracker.Model.Comm
{
    public class CommCore : ICommCore
    {
	    public int CommCoreId { get; set; }
	    public int CommTypeId { get; set; }
	    public int CommSendStatusTypeId { get; set; }
	    public int CommDetailId { get; set; }
	    public DateTime ChangedOn { get; set; }
	    public DateTime CreatedOn { get; set; }

		[ForeignKey("CommSendStatusTypeId")]
		public virtual CommSendStatusType CommSendStatusType { get; set; }
		[ForeignKey("CommDetailId")]
		public virtual CommDetail CommDetail { get; set; }

    }
}
