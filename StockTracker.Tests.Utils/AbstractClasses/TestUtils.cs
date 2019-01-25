using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context.Interface;
using StockTracker.Tests.Utils.Acts;
using StockTracker.Tests.Utils.MockVerifiers;

namespace StockTracker.Tests.Utils.AbstractClasses
{
	public abstract class TestUtils<T>
	{
		public GenericLoggerCheck<T> _log;
		public IStockTrackerContext _db;

		private Repo<T> _repo;

		public virtual Repo<T> GetRepo()
		{
			var repo = new Repo<T>();
			_repo = repo;
			_db = repo.db;
			_log = repo._loggerCheck;
			return repo;
		}

		public virtual void AssertSameLogSuccess<TK>(TK original)
		{
			AssertSame(original);
			_log.Success();
		}

		public virtual void AssertSameLogError<TK>(TK original)
		{
			AssertSame(original);
			_log.Error();
		}

		public virtual void AssertDiffLogError<TK>(TK original)
		{
			AssertDiff(original);
			_log.Error();
		}

		public virtual void AssertDiffLogSuccess<TK>(TK original)
		{
			AssertDiff(original);
			_log.Success();
		}

		void AssertSame<TK>(TK original)
		{
			var result = Result<TK>();
			var idName = $"{result.GetType().Name}Id";
			var resultId = result.GetType().GetProperty(idName).GetValue(result);
			var originId = original.GetType().GetProperty(idName).GetValue(original);

			Assert.AreEqual(resultId, originId);
		}

		void AssertDiff<TK>(TK original)
		{
			var result = Result<TK>();
			var idName = $"{result.GetType().Name}Id";
			var resultId = result.GetType().GetProperty(idName).GetValue(result);
			var originId = original.GetType().GetProperty(idName).GetValue(original);

			Assert.AreNotEqual(resultId, originId);
		}

		public virtual void ResultIsNullLogError<TK>()
		{
			Assert.IsNull(Result<TK>());
			_log.Error();
		}

		public virtual void ResultIsNotNullLogError<TK>()
		{
			Assert.IsNotNull(Result<TK>());
			_log.Error();
		}

		public virtual void ResultIsNullLogSuccess<TK>()
		{
			Assert.IsNull(Result<TK>());
			_log.Success();
		}

		public virtual void ResultIsNotNullLogSuccess<TK>()
		{
			Assert.IsNotNull(Result<TK>());
			_log.Success();
		}

		public virtual TK Result<TK>()
		{
			return (TK)_repo.Result;
		}
	}
}

