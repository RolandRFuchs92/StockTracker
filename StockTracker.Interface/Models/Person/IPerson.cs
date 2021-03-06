﻿using System.ComponentModel.DataAnnotations;

namespace StockTracker.Interface.Models.Person
{
    public interface IPerson
    {
		[Key]
        int PersonId { get; set; }
	    string PersonName { get; set; }
	    string PersonSurname { get; set; }
		string Mobile { get; set; }
		string WhatsApp { get; set; }
		string Email { get; set; }
    }
}
