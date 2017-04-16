using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Rate.Services.Core
{
    public static class PropertyReader
    {
        public static object PropValue<T>(this System.Object o, string propertyName)
        {
            var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            return property.PropertyType.GetTypeInfo().IsClass ? null : property?.GetValue(o);
        }
    }
}
