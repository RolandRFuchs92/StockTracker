using StockTracker.Interface.Models.Person;
using StockTracker.Model.Members;

namespace StockTracker.Model.Persons
{
    public class Person : IPerson
    {
	    public int PersonId { get; set; }
	    public string PersonName { get; set; }
	    public string PersonSurname { get; set; }
	    public string Mobile { get; set; }
	    public string WhatsApp { get; set; }
	    public string Email { get; set; }

        public Member Member { get; set; }
    }
}
