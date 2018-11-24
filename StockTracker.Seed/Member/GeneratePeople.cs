using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Model;
using StockTracker.Model.Persons;

namespace StockTracker.Seed.Member
{
    public class GeneratePeople
    {
	    private List<string> _name;
	    private Random _rng;

	    public GeneratePeople()
	    {
		    _rng = new Random();
			_name = new List<string>();
		    GenerateName();
	    }

	    public List<Person> GeneratePersonList(int maxMembers)
	    {
		    var people = new List<Person>();
		    var maxNames = _name.Count();

		    for (var inc = 1; inc < maxMembers + 1; inc++)
		    {
			    var firstName = _name[_rng.Next(maxNames - 1)];
				people.Add(new Person
				{
					PersonId = inc,
					PersonSurname = _name[_rng.Next(maxNames -1)],
					Mobile = _rng.Next(100000000, 999999999).ToString(),
					WhatsApp = _rng.Next(100000000, 999999999).ToString(),
					Email = $"{firstName}@randomseed.co.za",
					PersonName = firstName
				});
		    }

		    return people;
	    }

	    private void GenerateName()
	    {
			_name.Add("Roland");
		    _name.Add("Douglas");
		    _name.Add("Desmond");
		    _name.Add("John");
		    _name.Add("Johan");
		    _name.Add("Sharon");
		    _name.Add("Cathy");
		    _name.Add("Candice");
		    _name.Add("Janice");
		    _name.Add("Ashley");
		    _name.Add("David");
		    _name.Add("Lara");
		    _name.Add("Jessica");
		    _name.Add("Chaye");
		    _name.Add("Diante");
		    _name.Add("Dee");
		    _name.Add("Joseph");
		    _name.Add("Mary");
		    _name.Add("Martha");
		    _name.Add("Trevor");
		    _name.Add("Wesley");
		    _name.Add("Ruan");
		    _name.Add("Victoria");
		    _name.Add("Steve");
		    _name.Add("Lulu");
		    _name.Add("Edmond");
		    _name.Add("Alex");
		    _name.Add("James");
		    _name.Add("Lexis");
		    _name.Add("Eleneor");
	    }
	}
}
