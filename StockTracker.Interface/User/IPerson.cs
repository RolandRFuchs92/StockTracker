using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Interface.User
{
    public interface IPerson
    {
        int PersonId { get; set; }
		int PersonName { get; set; }
	    int PersonSurname { get; set; }
		int Mobile { get; set; }
		int WhatsApp { get; set; }
		int Email { get; set; }
    }
}
