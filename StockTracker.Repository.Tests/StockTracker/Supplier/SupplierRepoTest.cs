using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Interface.Models.Suppliers;
using StockTracker.Repository.Interface.Suppliers;
using StockTracker.Repository.Suppliers;
using StockTracker.Tests.Utils.AbstractClasses;
using StockTracker.Model.Suppliers;

namespace StockTracker.Repository.Test.StockTracker.Supplier
{
		[TestClass]
		public class SupplierRepoTest : TestUtils<SupplierRepo>
		{
				public const string _add = nameof(ISupplierRepo.Add);
				public const string _edit = nameof(ISupplierRepo.Edit);
				public const string _list = nameof(ISupplierRepo.List);
				public const string _listSuppliersByType = nameof(ISupplierRepo.ListSuppliersByType);
				public const string _get = nameof(ISupplierRepo.Get);
				public const string _delete = nameof(ISupplierRepo.Delete);

				[TestMethod]
				public void Add_PassValidSupplierRepo_ReturnNewSupplierLogSuccess()
				{
						//Arrange
						var repo = GetRepo();

						//Act


						//Assert

				}


				#region Dry
				ISupplier GetSupplier()
				{
						return (ISupplier)null;
				}
				#endregion
		}
}
