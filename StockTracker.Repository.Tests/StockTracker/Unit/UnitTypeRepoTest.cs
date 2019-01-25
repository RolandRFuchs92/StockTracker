using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Interface.Models.Unit;
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

		#region Add
		[TestMethod]
		public void Add_PassEmptyName_ReturnNullLogError()
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
			_log.Error();
		}

		[TestMethod]
		public void Add_PassNewNameAndSymbol_ReturnResultLogSuccess()
		{
			//Arrange
			var repo = GetRepo();
			var unitType = _unitType;
			_unitType.UnitTypeId = 0;

			//Act
			repo.CreateResult(_add, unitType.Name, unitType.Symbol);

			//Assert
			AssertSameLogSuccess(unitType);
		}

		[TestMethod]
		public void Add_PassNewNameAndEmptySymbol_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var unitType = _unitType;
			_unitType.Symbol = "";

			//Act
			repo.CreateResult(_add, unitType.Name, unitType.Symbol);

			//Assert
			ResultIsNullLogError<IUnitType>();
		}
		#endregion


		#region Edit
		[TestMethod]
		public void Edit_PassEmptyNameAndEmptySymbol_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var unitType = _unitType;
			unitType.UnitTypeId = 1;
			unitType.Name = "";
			unitType.Symbol = "";

			//Act
			repo.CreateResult(_edit, (IUnitType)unitType);

			//Assert
			ResultIsNullLogError<IUnitType>();
		}

		[TestMethod]
		public void Edit_PassEmptySymbolAndNewName_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var unitType = _unitType;
			unitType.Symbol = "";
			unitType.UnitTypeId = 1;

			//Act
			repo.CreateResult(_edit, unitType);

			//Assert
			ResultIsNullLogError<IUnitType>();
		}


		[TestMethod]
		public void Edit_PassEmptyNameAndNewSumbol_ReturnNullLogError()
		{
			//Arrange
			var repo = GetRepo();
			var unitType = _unitType;
			unitType.Name = "";
			unitType.UnitTypeId = 1;

			//Act
			repo.CreateResult(_edit, unitType);

			//Assert
			ResultIsNullLogError<IUnitType>();
		}

		[TestMethod]
		public void Edit_PassNewNameNewSymbol_ReturnNewUnitLogSuccess()
		{
			//Arrange
			var repo = GetRepo();
			var unitType = _unitType;
			unitType.UnitTypeId = 1;

			//Act
			repo.CreateResult(_edit, unitType);

			//Assert
			AssertDiffLogSuccess(unitType);
		}
		#endregion
	}
}
