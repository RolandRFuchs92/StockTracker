using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.BusinessLogic.Interface.Client;
using StockTracker.BusinessLogic.Interface.Poco;
using StockTracker.Interface.Models.Clients;
using StockTracker.Repository.Enums;
using StockTracker.Repository.Interface.Clients;

namespace StockTracker.BuisnessLogic.Clients
{
		public class ClientSettingsLogic : IClientSettingsLogic
		{
				private IClientSettingsRepo _repo;
				private ILoggerAdapter<ClientSettingsLogic> _log;

				public ClientSettingsLogic(IClientSettingsRepo repo, ILoggerAdapter<ClientSettingsLogic> log)
				{
						_repo = repo;
						_log = log;
				}

				public IResult<IClientSettings> Add(IClientSettings clientSettings)
				{
						var data = _repo.AddClientSettings(clientSettings);
						return FormulateResult(data, "We were unable to add this clients settings.");
				}

				public IResult<IClientSettings> IsActive(int clientId, bool isActive)
				{
						var data = _repo.IsActive(clientId, isActive);
						var activateAdjective = isActive ? "activate" : "deactivate";
						var message = $"We were unable to {activateAdjective} this client.";
						
						return FormulateResult(data, message);
				}

				public IResult<IClientSettings> IsDeleted(int clientId, bool isDeleted)
				{
						var data = _repo.IsDeleted(clientId, isDeleted);
						var deletedAdjective = isDeleted ? "delete" : "restore";
						var message = $"We were unable to {deletedAdjective}";

						return FormulateResult(data, message);
				}

				public IResult<IClientSettings> Edit(IClientSettings clientSettings)
				{
						var data = _repo.Edit(clientSettings);

						return FormulateResult(data, "We were unable to edit this client.");
				}

				public IResult<IClientSettings> SetBusinessHours(DateTime? openTime, DateTime? closeTime, int clientId)
				{
						if (openTime != null && closeTime != null && ((DateTime)openTime).Minute > ((DateTime)closeTime).Minute)
								return FormulateResult((IClientSettings)null, "The open time is after the close time, please correc this and try again.");

						var data = _repo.SetOpenClosedTimes(openTime, closeTime, clientId);
						return FormulateResult(data, "We were unable to set the open and close time for this client.");
				}

				public IResult<IClientSettings> AddTotalUsers(int clientId, int addUsers)
				{
						var data = _repo.AddTotalUsers(clientId, addUsers);

						return FormulateResult(data, $"We were unable to add {addUsers} users to this client.");
				}

				private IResult<IClientSettings> FormulateResult(IClientSettings data, string errorMessage)
				{
						var result = new Result<IClientSettings>();
						result.Body = data;
						result.IsSuccess = result.Body != null;

						if (!result.IsSuccess)
						{
								_log.LogInformation((int)LoggingEvent.Error, errorMessage);
								result.Message = errorMessage;
								return result;
						}

						_log.LogInformation((int)LoggingEvent.Info, "Returned success result");
						return result;
				}
		}
}
