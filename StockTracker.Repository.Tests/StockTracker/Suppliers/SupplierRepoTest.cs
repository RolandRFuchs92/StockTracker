using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Interface.Models.Suppliers;
using StockTracker.Repository.Interface.Suppliers;
using StockTracker.Repository.Suppliers;
using StockTracker.Tests.Utils.AbstractClasses;
using StockTracker.Model.Suppliers;
using StockTracker.Seed.Suppliers;
using System.Collections.Generic;
using StockTracker.Tests.Utils.Extension;

namespace StockTracker.Repository.Test.StockTracker.Suppliers
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
				private readonly GenericSupplier _defaultSupplier;

				public SupplierRepoTest()
				{
						_defaultSupplier = new GenericSupplier();
				}

				[TestMethod]
				public void Add_PassValidSupplierRepo_ReturnNewSupplierLogSuccess()
				{
						//Arrange
						var repo = GetRepo();
						var newSupplier = GetSupplier(new Dictionary<string, dynamic> { { nameof(ISupplier.SupplierId), 0 } });

						//Act
						repo.CreateResult(_add, newSupplier);

						//Assert
						AssertIsNotNullLogSuccess<ISupplier>();
				}


				#region Dry
				ISupplier GetSupplier(Dictionary<string, dynamic> replaceVals)
				{
						return _defaultSupplier.One().GetNewObject(replaceVals);
				}
				#endregion
		}
}
