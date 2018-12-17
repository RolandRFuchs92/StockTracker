using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Model.Stock;
using StockTracker.Seed.Clients.Generic;
using StockTracker.Seed.Interface;
using StockTracker.Seed.Stock;
using StockTracker.Tests.Utils.Context;
using StockTracker.Tests.Utils.MockVerifiers;

namespace StockTracker.Tests.Utils.Acts
{
    public class Repo<T>
    {
        private T _repo;
        private IStockTrackerContext _db;
        private bool isValidResult;


        public dynamic Result { get; private set; }
        public GenericLoggerCheck<T> _loggerCheck { get; private set; }
        public object[] ParametersUsed { get; private set; }
        public Dictionary<string, dynamic> ParameterDictionary { get; private set; }

        public Repo(string errorDbSetName = "")
        {
            Setup(errorDbSetName);
            _repo = (T)Activator.CreateInstance(typeof(T), _db, _loggerCheck.Mock.Object);
        }

        public Repo(string errorDbSetName = "", params object[] parameter)
        {
            Setup(errorDbSetName);
            _repo = (T)Activator.CreateInstance(typeof(T), _db, _loggerCheck.Mock.Object, parameter[0]);
        }

        private void Setup(string errorDbSetName)
        {
            isValidResult = string.IsNullOrEmpty(errorDbSetName);
            CreateDbInstance(errorDbSetName);
            _loggerCheck = new GenericLoggerCheck<T>();
            _db = new TestDbFactory().Db();
        }

        private void CreateDbInstance(string errorDbSetName)
        {
            if (!string.IsNullOrEmpty(errorDbSetName))
            {
                var moq = new Mock<IStockTrackerContext>();
                moq.Setup(i => i.GetType().GetProperty(errorDbSetName)).Throws(new Exception());
                _db = moq.Object;
            }
            else
            {
                _db = new TestDbFactory().Db();
            }
        }

        public void CreateResult(string methodName)
        {
            var methodInfo = _repo.GetType().GetMethod(methodName);
            var parameterInfo = methodInfo.GetParameters();

            var methodParameters = new List<object>();

            foreach (var parameter in parameterInfo)
            {
                var val = DefaultValue(parameter);
                ParameterDictionary.Add(parameter.Name, val);
                methodParameters.Add(val);
            }

            ParametersUsed = methodParameters.ToArray();
            CreateResult(methodName, ParametersUsed);
        }

        public void CreateResult(string methodName, params object[] methodParams)
        {
            ParametersUsed = methodParams;
            Result = _repo.GetType().GetMethod(methodName).Invoke(_repo, methodParams);
        }

        private object DefaultValue(ParameterInfo parameter)
        {
            var paramType = parameter.ParameterType;

            if (paramType == typeof(int))
                return isValidResult ? 1 : 100;

            if (paramType == typeof(string))
                return isValidResult ? "Ragunaught" : "";

            if (paramType == typeof(double))
                return isValidResult ? 1.23 : 100000.00000;

            if (!paramType.IsClass) throw new Exception("Unrecognised parameter type.");

            var assembly = Assembly.Load("StockTracker.Seed");
            var types = (from classObj in assembly.GetTypes()
                         let obj = classObj.BaseType
                         where !classObj.IsAbstract
                               && !classObj.IsInterface
                               && obj != null
                               && obj.IsGenericType
                               && obj.GetGenericTypeDefinition() == typeof(IGeneric<>)
                               && obj.GetGenericTypeDefinition() == paramType
                         select classObj).FirstOrDefault();

            if (types == null)
                throw new Exception("Unrecognised parameter type.");

            var newInstance = Activator.CreateInstance(types, true).GetType().GetMethod("One");
            return newInstance.Invoke(newInstance, new object[] { });

        }
    }
}
