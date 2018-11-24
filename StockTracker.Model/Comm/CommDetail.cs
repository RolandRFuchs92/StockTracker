using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StockTracker.Interface.Models.Comm;
using StockTracker.Model.Members;

namespace StockTracker.Model.Comm
{
    public class CommDetail :ICommDetail
    {
	    public int CommDetailId { get; set; }
	    public int CommErrorId { get; set; }
	    public int MemberId { get; set; }
	    public string Response { get; set; }
	    public string Subject { get; set; }
	    public string Message { get; set; }
	    public string Recipients { get; set; }
	    public string Sender { get; set; }

		[ForeignKey("CommErrorId")]
		public virtual CommError CommError { get; set; }
		[ForeignKey("MemberId")]
		public virtual Member Member { get; set; }
    }
}
