using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Model.Unit;
using StockTracker.Repository.Interface.Unit;
using StockTracker.Repository.Unit;
using StockTracker.Tests.Utils.AbstractClasses;

namespace StockTracker.Repository.Test.StockTracker.Unit
{
	[TestClass]
	public class UnitTypeRepoTest : TestUtils<UnitTypeRepo>
	{

		[TestMethod]
		public void UoW_InitialCondition_ExpectedResult()
		{
			//Arrange
			var repo = GetRepo();

			//Act


			//Assert

		}
	}
}
