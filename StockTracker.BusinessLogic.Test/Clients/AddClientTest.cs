using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Model.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.BusinessLogic.Test.Clients
{
		[TestClass]
    public class AddClientTest
    {
				public AddClientTest()
				{
				}

				[TestMethod]
				public void AddClient_PassValidClients_False()
				{
						//Arrange
						var newClientList = new []
						{
								new Client{ 
										Address ="Test address",
										ClientName ="Cammel Patrol",
										CreatedOn = DateTime.Now,
										ContactNumber = "0730730258",
										IsActive = false,
										Email = "moo@moo.co.za"
								},
								new Client{
										Address ="Test address 2",
										ClientName ="Cammel Dog lane",
										CreatedOn = DateTime.Now,
										ContactNumber = "111 023 1234",
										IsActive = true,
										Email = "moo@mooo.gov.za"
								},
								new Client{
										Address ="Test address",
										ClientName ="Camel Patrol",
										CreatedOn = DateTime.Now,
										ContactNumber = "(011) 023 1234",
										IsActive = true,
										Email = "moo@111.111.111.111"
								}
						};


						//Act
						foreach (var client in newClientList)
						{
								

						}

						//Assert

				}    

    }
}
