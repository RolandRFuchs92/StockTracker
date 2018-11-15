using System.ComponentModel.DataAnnotations;
using StockTracker.Interface.Models.Person;

namespace StockTracker.Model.Person
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
