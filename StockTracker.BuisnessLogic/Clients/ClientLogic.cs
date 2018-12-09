using StockTracker.Context.Interface;
using System;
using System.ComponentModel.DataAnnotations;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.BuisnessLogic.Poco;
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
            var result = new Result<bool>();

            result.Check(newClient.Email.IsValidEmail(), "Invalid email.");
            result.Check(newClient.ContactNumber.IsPhoneNumberValid(), "Invalid contact number.");

            if (!result.IsSuccess)
            {
                _log.LogError((int)LoggingEvent.Error, result.Message);
                return result;
            }


            result.Check(_clientRepo.Add(newClient), "Client saved!", "Error saving client.");
            return result;
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
            var result = new Result<IClient>();
            result.Body = _clientRepo.Get(clientId);
            result.Check(result.Body != null, "Successfully retreived client!", "Unable to find client.");

            return result;
        }

        public IResult<bool> EditClient(IClient editClient)
        {
            var result = new Result<bool>();
            result.Body = _clientRepo.Edit(editClient);
            result.Check(result.Body, "Successfully edited the client!", "Unable to edit the client.");

            return result;
        }
    }
}
