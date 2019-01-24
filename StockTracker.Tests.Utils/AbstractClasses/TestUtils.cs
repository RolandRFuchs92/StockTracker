using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context.Interface;
using StockTracker.Tests.Utils.Acts;

namespace StockTracker.Tests.Utils.AbstractClasses
{
	public abstract class TestUtils<T>
	{
		public ILoggerAdapter<T> _log;
		public IStockTrackerContext _db;

		public virtual Repo<T> GetRepo()
		{
			var repo = new Repo<T>();
			_db = repo.db;
			return repo;
		}

		public virtual void AssertEdit<TK>(TK result, TK original, bool areSame = false)
		{
			var idName = $"{result.GetType().Name}Id";
			var resultId = result.GetType().GetProperty(idName).GetValue(result);
			var originId = original.GetType().GetProperty(idName).GetValue(original);

			if (areSame)
				Assert.AreEqual(resultId, originId);
			else
				Assert.AreNotEqual(resultId, originId);
		}

		public virtual void AssertNull<TK>(TK result)
		{
			Assert.IsNotNull(result);
		}
	}
}
