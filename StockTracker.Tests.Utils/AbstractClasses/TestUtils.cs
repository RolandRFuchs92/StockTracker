﻿using System;
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

		public virtual TK Result<TK>()
		{
			return (TK)_repo.Result;
		}

	}
}

