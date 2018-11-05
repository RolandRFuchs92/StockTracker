using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.BusinessLogic.Inteface.Poco;
using StockTracker.Interface.Models.Client;

namespace StockTracker.BusinessLogic.Inteface.Client
{
	public interface IAddClient
	{
		IResult<bool> AddClient(IClient newClient);
		IResult<bool> AddClient(bool isActive, string name, string email, string contactNumber);
	}
}
