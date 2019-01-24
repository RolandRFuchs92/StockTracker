using System.Collections.Generic;

namespace StockTracker.Tests.Utils.Extension
{
    public static class ObjectExtension
    {
        public static T GetNewObject<T>(this T moo, Dictionary<string, dynamic> adjustments)
        {
            foreach (var item in adjustments)
            {
                moo.GetType().GetProperty(item.Key).SetValue(moo, item.Value);
            }

            return moo;
        }
    }
}
