using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StockTracker.Tests.Utils.Asserts
{
    public class PropertyAssertChecks<T>
    {
        public void CompareObject(T result, Dictionary<string, dynamic> compareDictionary)
        {
            foreach (var item in compareDictionary)
            {
                var resultProp = result.GetType().GetProperty(item.Key).GetValue(item.Value);
                var val = item.Value;

                Assert.AreEqual(resultProp, val);
            }
        }

    }
}
