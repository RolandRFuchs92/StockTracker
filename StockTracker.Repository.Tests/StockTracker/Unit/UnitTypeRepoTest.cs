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
		private const string _add = nameof(IUnitTypeRepo.Add);
		private const string _edit = nameof(IUnitTypeRepo.Edit);
		private const string _list = nameof(IUnitTypeRepo.List);
		private const string _isValid = nameof(IUnitTypeRepo.IsValid);
		private readonly UnitType _unitType;

		public UnitTypeRepoTest()
		{
			_unitType = new UnitType
			{
				Name = "Blob",
				Symbol = "blb",
				UnitTypeId = 100
			};
		}

		[TestMethod]
		public void Add_PassEmptyName_ReturnNull()
		{
			//Arrange
			var repo = GetRepo();
			var unit = _unitType;
			unit.Name = "";

			//Act
			repo.CreateResult(_add, unit);
			var result = repo.Result;

			//Assert
			Assert.IsNull(result);
		}
	}
}
