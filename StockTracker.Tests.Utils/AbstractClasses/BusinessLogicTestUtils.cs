using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StockTracker.Context;
using StockTracker.Tests.Utils.Context;
using StockTracker.Tests.Utils.MockVerifiers;

namespace StockTracker.Tests.Utils.AbstractClasses
{
	public abstract class BusinessLogicTestUtils<TService, TRepo> : CollatedAsserts<TService>
		where TService : class
		where TRepo : class

	{
		protected StockTrackerContext _db;
		protected TRepo _repo;
		protected TService _service;

		protected BusinessLogicTestUtils()
		{
			_db = new TestDbFactory().Db();
			_repo = CreateRepo();
		}

		public virtual TRepo CreateRepo()
		{
			return new Mock<TRepo>().Object;
		}

		public virtual void CreateInstance(TRepo repo = null)
		{
			_service = (TService)Activator.CreateInstance(typeof(TService), _repo, _log.Mock.Object);
		}

		public virtual void CreateResult(string methodName, params object[] parameters)
		{
			_result = _service.GetType().GetMethod(methodName).Invoke(_service, parameters);
		}
	}
}
