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
				#region Result Is True
				public virtual void ResultIsTrueLogSuccess()
				{
						Assert.IsTrue(Result<bool>());
						_log.Success();
				}

				public virtual void ResultIsTrueNoLog()
				{
						Assert.IsTrue(Result<bool>());
						_log.Success(0);
						_log.Error(0);
						_log.ErrorException(0);
				}

				public virtual void ResultIsFalseNoLog()
				{
						Assert.IsFalse(Result<bool>());
						_log.Success(0);
						_log.Error(0);
						_log.ErrorException(0);
				}
				#endregion

				#region AssertSame
				public virtual void AssertSameLogSuccess<TK>(TK original, string propertyToCheck = "")
				{
						AssertSame(original, propertyToCheck);
						_log.Success();
				}

				public virtual void AssertSameLogError<TK>(TK original)
				{
						AssertSame(original);
						_log.Error();
				}

				public virtual void AssertSameNoLog<TK>(TK original)
				{
						AssertSame(original);
						_log.NoLog();
				}
				#endregion

				#region Check Different
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
				#endregion

				#region IsNull
				public virtual void AssertIsNullLogError<TK>()
				{
						if (!(Result<TK>() is IList<TK>))
								Assert.IsNull(Result<TK>());
						else
								Assert.AreEqual(((IList<TK>)Result<TK>()).Count, 0);

						_log.Error();
				}

				public virtual void AssertIsNullLogSuccess<TK>()
				{
						Assert.IsNull(Result<TK>());
						_log.Success();
				}

				public virtual void AsserltIsNullNoLog<TK>()
				{
						Assert.IsNull(Result<TK>());
						_log.Mock.VerifyNoOtherCalls();
				}
				#endregion

				#region IsNotNull
				public virtual void AssertIsNotNullLogError<TK>()
				{
						Assert.IsNotNull(Result<TK>());
						_log.Error();
				}

				public virtual void AssertIsNotNullLogSuccess<TK>()
				{
						Assert.IsNotNull(Result<TK>());
						_log.Success();
				}

				public virtual void AssertIsNotNullNoLog<TK>()
				{
						Assert.IsNotNull(Result<TK>());
						_log.NoLog();
				}
				#endregion

				#region IsTrue

				public void AssertIsTrueLogSuccess()
				{
						Assert.IsTrue(_repo.Result);
						_log.Success();
				}

				public void AssertIsTrueLogError()
				{
						Assert.IsTrue(_repo.Result);
						_log.Error();
				}

				public void AssertIsTrueNoLog()
				{
						Assert.IsTrue(_repo.Result);
						_log.NoLog();
				}

				#endregion

				#region IsFalse

				private void AssertIsFalseLogSuccess()
				{
						Assert.IsFalse(_repo.Result);
						_log.Success();
				}

				public void AssertIsFalseLogError()
				{
						Assert.IsFalse(_repo.Result);
						_log.Error();
				}

				public void AssertIsFalseNoLog()
				{
						Assert.IsFalse(_repo.Result);
						_log.NoLog();
				}
				#endregion

				public virtual TK Result<TK>()
				{
						return (TK)_repo.Result;
				}

				#region EqualityChecks
				public virtual void AssertSameProp<TK>(TK original, string propertyToCheck)
				{
						var result = Result<TK>();
						var resultProp = result.GetType().GetProperty(propertyToCheck).GetValue(result);
						var originProp = original.GetType().GetProperty(propertyToCheck).GetValue(original);

						Assert.AreEqual(resultProp, originProp);
				}

				public virtual void AssertDiffProp<TK>(TK original, string propertyToCheck)
				{
						var result = Result<TK>();
						var resultProp = result.GetType().GetProperty(propertyToCheck).GetValue(result);
						var originProp = original.GetType().GetProperty(propertyToCheck).GetValue(original);

						Assert.AreNotEqual(resultProp, originProp);
				}
				#endregion

				#region Private Code
				void AssertSame<TK>(TK original, string propertyToCheck = "")
				{
						var result = Result<TK>();
						var idName = $"{result.GetType().Name}Id";
						var resultId = result.GetType().GetProperty(idName).GetValue(result);
						var originId = original.GetType().GetProperty(idName).GetValue(original);

						Assert.AreEqual(resultId, originId);

						if (!string.IsNullOrEmpty(propertyToCheck))
								AssertSameProp(original, propertyToCheck);
						else
						{
								var prop = original.GetType().GetProperties().FirstOrDefault(i => i.Name.ToLower().IndexOf("id") < 0).Name;
								AssertSameProp(original, prop);
						}
				}

				void AssertDiff<TK>(TK original, string propertyToCheck = "")
				{
						var result = Result<TK>();
						var idName = $"{result.GetType().Name}Id";
						var resultId = result.GetType().GetProperty(idName).GetValue(result);
						var originId = original.GetType().GetProperty(idName).GetValue(original);

						Assert.AreEqual(resultId, originId);

						if (!string.IsNullOrEmpty(propertyToCheck))
								AssertDiffProp(original, propertyToCheck);
						else
						{
								var prop = original.GetType().GetProperties().FirstOrDefault(i => i.Name.ToLower().IndexOf("id") < 0).Name;
								AssertDiffProp(original, prop);
						}
				}
				#endregion
		}
}

