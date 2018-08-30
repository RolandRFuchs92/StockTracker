using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Interface.Models.User;

namespace StockTracker.Model
{
    public class Person : IPerson
    {
	    public int PersonId { get; set; }
	    public string PersonName { get; set; }
	    public string PersonSurname { get; set; }
	    public string Mobile { get; set; }
	    public string WhatsApp { get; set; }
	    public string Email { get; set; }
    }
}
