using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Tests.Utils.Context;
using StockTracker.Tests.Utils.MockVerifiers;

namespace StockTracker.Tests.Utils.AbstractClasses
{
	public abstract class BusinessLogicTestUtils<TService, TRepo> : CollatedAsserts<TService>
		where TService : class
	{
		protected StockTrackerContext _db;
		protected TRepo _repo;
		protected GenericLoggerCheck<TRepo> _repoLog;
		protected TService _service;

		protected BusinessLogicTestUtils()
		{
			_db = new TestDbFactory().Db();
			_repoLog = new GenericLoggerCheck<TRepo>();
			_repo = (TRepo)Activator.CreateInstance(typeof(TRepo), _repo, _repoLog.Mock.Object);
		}

		public virtual void CreateInstance()
		{
			_service = (TService)Activator.CreateInstance(typeof(TService), _repo, _log);
		}

		public virtual void CreateResult(string methodName, params object[] parameters)
		{
			_result = _service.GetType().GetMethod(methodName).Invoke(_service, parameters);
		}
	}
}
