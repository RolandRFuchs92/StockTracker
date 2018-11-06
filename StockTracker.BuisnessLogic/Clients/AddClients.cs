using StockTracker.Context.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.BusinessLogic.Inteface.Poco;
using StockTracker.Extensions.StringExtensions;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Interface.Models.Client;
using StockTracker.Model.Clients;

namespace StockTracker.BuisnessLogic.Clients
{
	public class AddClients : IAddClients
	{
		private readonly IClientRepo _addClient;

		public AddClients(IClientRepo addClient)
		{
			_addClient = addClient;
		}

		public IResult<bool> AddClient(IClient newClient)
		{
			var result = new Result<bool>();

			result.Check(newClient.Email.IsValidEmail(), "Invalid email.");
			result.Check(newClient.ContactNumber.IsPhoneNumberValid(),"Invalid contact number.");
		
			if(!result.IsSuccess)
				return result;

			result.Check(_addClient.Add(newClient), "Client saved!", "Error saving client.");

			return result;
		}

		public IResult<bool> AddClient(bool isActive, string name, string email, string contactNumber)
		{
			var client = new Client
			{
				IsActive = isActive,
				ClientName = name,
				Email = email,
				ContactNumber = contactNumber,
				CreatedOn = DateTime.Now
			};

			return AddClient(client);
		}
	}
}
