using StockTracker.Context.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.BuisnessLogic.Util;
using StockTracker.BusinessLogic.Interface.Client;
using StockTracker.BusinessLogic.Interface.Poco;
using StockTracker.Extensions.StringExtensions;
using StockTracker.Interface.Models.Clients;
using StockTracker.Repository.Interface.Clients;
using StockTracker.Model.Clients;
using StockTracker.Repository.Enums;

namespace StockTracker.BuisnessLogic.Clients
{
    public class ClientLogic : IClientLogic
    {
        private readonly IClientRepo _clientRepo;
        private readonly ILoggerAdapter<ClientLogic> _log;

        public ClientLogic(IClientRepo clientRepo, ILoggerAdapter<ClientLogic> log)
        {
            _clientRepo = clientRepo;
            _log = log;
        }

        public IResult<bool> AddClient(IClient newClient)
        {
            var result = new FormulateResult<bool, ClientLogic>(_log);

            result.Check(newClient.Email.IsValidEmail(), "Invalid email.");
            result.Check(newClient.ContactNumber.IsPhoneNumberValid(), "Invalid contact number.");

            if (!result.IsSuccess)
            {
                return result.Result;
            }

            result.Check(_clientRepo.Add(newClient), "Client saved!", "Error saving client.");
            return result.Result;
        }

        public IResult<bool> AddClient(string name, string email, string contactNumber)
        {
            var client = new Client
            {
                ClientName = name,
                Email = email,
                ContactNumber = contactNumber,
                CreatedOn = DateTime.Now
            };

            return AddClient(client);
        }

        public IResult<IClient> GetClient(int clientId)
        {
            var result = new FormulateResult<IClient, ClientLogic>(_log);
            var body = _clientRepo.Get(clientId);
            result.Check(body, "Successfully retreived client!", "Unable to find client.");

            return result.Result;
        }

        public IResult<bool> EditClient(IClient editClient)
        {
            var result = new FormulateResult<bool, ClientLogic>(_log);
            var body = _clientRepo.Edit(editClient);

            result.Check(body, "Successfully edited the client!", "Unable to edit the client.");

            return result.Result;
        }
    }
}
