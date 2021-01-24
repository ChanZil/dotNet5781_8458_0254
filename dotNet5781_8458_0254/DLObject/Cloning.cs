using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DO
{
    static class Cloning
    {
        internal static T Clone<T>(this T original) where T : new()
        {
            T copyToObject = new T();
            foreach (PropertyInfo propertyInfo in typeof(T).GetProperties())
                propertyInfo.SetValue(copyToObject, propertyInfo.GetValue(original, null), null);
            return copyToObject;
        }
    }
}
