using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StockTracker.Adapter.Interface.Logger;
using StockTracker.Context.Interface;
using StockTracker.Model.Clients;
using StockTracker.Model.Stock;
using StockTracker.Seed.Clients.Generic;
using StockTracker.Seed.Interface;
using StockTracker.Seed.Stock;
using StockTracker.Tests.Utils.MockVerifiers;

namespace StockTracker.Tests.Utils.Acts
{
    public class Repo<T>
    {
        private T _repo;
        private GenericLoggerCheck<T> _loggerCheck;
        private IStockTrackerContext _db;


        public Repo(string errorDbSetName = "")
        {
            CreateDbInstance(errorDbSetName);
            _repo = (T)Activator.CreateInstance(typeof(T), _db, _loggerCheck.Mock.Object);
        }

        private void CreateDbInstance(string errorDbSetName)
        {
            var moq = new Mock<IStockTrackerContext>();
            if (!string.IsNullOrEmpty(errorDbSetName))
                moq.Setup(i => i.GetType().GetProperty(errorDbSetName)).Throws(new Exception());

            _db = moq.Object;
        }

        public dynamic Result(string methodName, bool isValidResult = true)
        {
            var methodInfo = _repo.GetType().GetMethod(methodName);
            var parameterInfo = methodInfo.GetParameters();
            
            var methodParameters = new List<object>();

            foreach (var parameter in parameterInfo)
            {
                if(isValidResult)
                    methodParameters.Add(DefaultValue(parameter, true));
                else
                    methodParameters.Add(DefaultValue(parameter, false));
            }

            var result = _repo.GetType().GetMethod(methodName).Invoke(_repo, methodParameters.ToArray());

            return result;
        }

        public dynamic Result(string methodName, object[] methodParams)
        {
            var result = _repo.GetType().GetMethod(methodName).Invoke(_repo, methodParams);

            return result;
        }

        private object DefaultValue(ParameterInfo parameter, bool isValidResult)
        {
            var paramType = parameter.ParameterType;

            if (paramType == typeof(int))
                return isValidResult ? 1 : 100;

            if (paramType == typeof(string))
                return isValidResult ? "Ragunaut" : "";

            if(paramType == typeof(double))
                return isValidResult ? 1.23 : 100000.00000;

            if (paramType.IsClass)
            {
                var assembly = Assembly.Load("StockTracker.Seed");
                var types = (from classObj in assembly.GetTypes()
                            let obj = classObj.BaseType
                            where !classObj.IsAbstract
                                  && !classObj.IsInterface
                                  && obj != null
                                  && obj.IsGenericType
                                  && obj.GetGenericTypeDefinition() == typeof(IGeneric<>)
                                  && obj.GetGenericTypeDefinition().GetType() == paramType
                            select classObj).FirstOrDefault();

                if (types == null)
                    throw new Exception("Unrecognised parameter type.");

                var newInstance = Activator.CreateInstance(types, true).GetType().GetMethod("One");
                return newInstance.Invoke(newInstance, new object[] { });
            }

            throw new Exception("Unrecognised parameter type.");
        }
    }
}
