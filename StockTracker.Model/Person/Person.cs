using System.ComponentModel.DataAnnotations;
using StockTracker.Interface.Models.Person;
using StockTracker.Interface.Models.User;

namespace StockTracker.Model.User
{
    public class Person : IPerson
    {
		[Key]
	    public int PersonId { get; set; }
	    public string PersonName { get; set; }
	    public string PersonSurname { get; set; }
	    public string Mobile { get; set; }
	    public string WhatsApp { get; set; }
	    public string Email { get; set; }
    }
}
