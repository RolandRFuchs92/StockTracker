using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StockTracker.Tests.Utils.Asserts
{
    public class PropertyAssertChecks
    {
        public void CompareObject<T>(T result, Dictionary<string, dynamic> compareDictionary)
        {
            foreach (var item in compareDictionary)
            {
                var resultProp = result.GetType().GetProperty(item.Key).GetValue(item.Value);
                var val = item.Value;

                Assert.AreEqual(resultProp, val);
            }
        }

        public void AreEqualAsserts<T>(T initalObject, Dictionary<string, dynamic> parameterDictionary)
        {
            ComparisonAsserts(initalObject, parameterDictionary, true);
        }

        public void AreNotEqualAsserts<T>(T initalObject, Dictionary<string, dynamic> parameterDictionary)
        {
            ComparisonAsserts(initalObject, parameterDictionary, false);
        }

        private void ComparisonAsserts<T>(T result, Dictionary<string, dynamic> parameterDictionary, bool areEqualCheck )
        {
            Assert.IsNotNull(result);
            foreach (var item in parameterDictionary)
            {
                var objectValue = result.GetType().GetProperty(item.Key).GetValue(result);
                var comparisonValue = item.Value;

                if(areEqualCheck)
                    Assert.AreEqual(objectValue, comparisonValue);
                else
                    Assert.AreNotEqual(objectValue, comparisonValue);
            }
        }

    }
}
