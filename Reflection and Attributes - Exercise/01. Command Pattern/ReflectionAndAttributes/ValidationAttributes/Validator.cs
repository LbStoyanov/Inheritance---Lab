using System;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any())
                .ToArray();

            foreach (var propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(obj);
                var attribute = propertyInfo.GetCustomAttribute<MyValidationAttribute>();

                bool isValid = attribute.isValid(value);

                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}