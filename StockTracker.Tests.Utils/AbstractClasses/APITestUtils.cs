using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace StockTracker.Tests.Utils.AbstractClasses
{
	public abstract class APITestUtils<TService> : CollatedAsserts<TService> where TService : class
	{
		protected TService _service;

		public APITestUtils()
		{

		}

		public abstract void CreateService();

		protected virtual void CreateResult(string methodName, params object[] parameters)
		{
			_result = _service.GetType().GetMethod(methodName).Invoke(_service, parameters);
		}
	}
}
