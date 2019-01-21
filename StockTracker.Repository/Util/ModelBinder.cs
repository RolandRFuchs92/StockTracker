using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTracker.Repository.Util
{
    public class ModelBinder
    {
        public T Bind<T>(T oldModel, T newModel)
        {
            var properties = oldModel.GetType().GetProperties().Select(i => i.Name);

            if (newModel == null)
                return oldModel;

            foreach (var property in properties)
            {
                if (property.Equals($"{typeof(T).Name}Id") || property.Equals("Id"))
                    continue;
                
                var newValue = newModel.GetType().GetProperty(property).GetValue(newModel);
                oldModel.GetType().GetProperty(property).SetValue(oldModel, newValue);
            }

            return oldModel;
        }
    }
}
