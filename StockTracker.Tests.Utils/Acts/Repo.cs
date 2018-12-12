using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Tests.Utils.Acts
{
    public class Repo<T>
    {
        private T _repo;

        public Repo(T repo)
        {
            _repo = repo;
        }

        public dynamic Result(string methodName, object[] methodParams)
        {
            var result = _repo.GetType().GetMethod(methodName).Invoke(_repo, methodParams);

            return result;
        }
    }
}
