using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.Models.Comm
{
    public interface ICommDetail
    {
        int CommDetailId { get; set; }
		int CommErrorId { get; set; }
		int MemberId { get; set; }
		string Response { get; set; }
		string Subject { get; set; }
		string Message { get; set; }
		string Recipients { get; set; }
		string Sender { get; set; }
    }
}
