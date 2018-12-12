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

        public void AreEqualAsserts<T>(T initalObject, Dictionary<string, dynamic> compare)
        {
            ComparisonAsserts(initalObject, compare, true);
        }

        public void AreNotEqualAsserts<T>(T initalObject, Dictionary<string, dynamic> compare)
        {
            ComparisonAsserts(initalObject, compare, false);
        }

        private void ComparisonAsserts<T>(T result, Dictionary<string, dynamic> compare, bool areEqualCheck )
        {
            Assert.IsNotNull(result);
            foreach (var item in compare)
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
