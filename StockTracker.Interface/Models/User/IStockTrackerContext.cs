﻿namespace StockTracker.Interface.Models.User
{
    public interface IStockTrackerContext
    {
        int PersonId { get; set; }
	    string PersonName { get; set; }
	    string PersonSurname { get; set; }
		string Mobile { get; set; }
		string WhatsApp { get; set; }
		string Email { get; set; }
    }
}
