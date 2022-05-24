using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClassName,string[] requestedFieldsNames)
        {
            Type classType = Type.GetType(investigatedClassName);
            FieldInfo[] classFields = 
                classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder stringBuilder = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] {});

            stringBuilder.AppendLine($"Class under investigation: {investigatedClassName}");

            foreach (FieldInfo field in classFields.Where(f => requestedFieldsNames.Contains(f.Name)))
            {
                stringBuilder.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return stringBuilder.ToString().Trim();
        }

        
    }
}
