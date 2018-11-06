using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.API.Controllers;
using StockTracker.BuisnessLogic.Poco;
using StockTracker.BusinessLogic.Inteface.Client;
using StockTracker.Interface.Models.Client;
using StockTracker.Model.Clients;
using StockTracker.Repository.Clients;

namespace StockTracker.API.Test.Clients
{
	[TestClass]
    public class AddClients
    {
	    private Mock<IAddClient> _moq;

	    public AddClients()
	    {
		    _moq = new Mock<IAddClient>();
	    }

	    [TestMethod]
		public void AddClient_PassValidClients_OK()
		{
			//Arrange
			_moq.Setup(i => i.AddClient(It.IsAny<IClient>())).Returns(new Result<bool>(true));
			var logic = _moq.Object;
			var controller = new ClientsController(logic);

			//Act
			var result = controller.AddClient(ClientList()[0]);
			
			//Assert

		}

	    private Client[] ClientList()
	    {
		    return new[]
		    {
			    new Client{
				    ClientId = 1,
				    Address ="Test address",
				    ClientName ="Cammel Patrol",
				    CreatedOn = DateTime.Now,
				    ContactNumber = "0730730258",
				    IsActive = false,
				    Email = "moo@moo.co.za"
			    },
			    new Client{
				    ClientId = 2,
				    Address ="Test address 2",
				    ClientName ="Cammel Dog lane",
				    CreatedOn = DateTime.Now,
				    ContactNumber = "111 023 1234",
				    IsActive = true,
				    Email = "moo@mooo.gov.za"
			    },
			    new Client{
				    ClientId = 2,
				    Address ="Test address",
				    ClientName ="Camel Patrol",
				    CreatedOn = DateTime.Now,
				    ContactNumber = "(011) 023 1234",
				    IsActive = true,
				    Email = "moo@111.111.111.111"
			    }
		    };
	    }

	}
}
