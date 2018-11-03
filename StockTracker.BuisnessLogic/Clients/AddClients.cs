using StockTracker.Context.Interface;
using System;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.Extensions.StringExtensions;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Interface.Models.Client;
using StockTracker.Model.Clients;

namespace StockTracker.BuisnessLogic.Clients
{
		public class AddClients : IAddClient
		{
				private readonly IAddClientRepo _addClient;

				public AddClients(IAddClientRepo addClient)
				{
						_addClient = addClient;
				}

				public bool AddClient(IClient newClient)
				{
						if (!newClient.Email.IsValidEmail() || !newClient.ContactNumber.IsPhoneNumberValid())
								return false;

						return _addClient.Add(newClient);
				}

				public bool AddClient(bool isActive, string name, string email, string contactNumber)
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
