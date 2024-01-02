using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Stealer
{
    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            Type type =Type.GetType("Stealer."+className);
            StringBuilder sb = new StringBuilder();
            FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                if (!fieldInfo.IsPrivate )
                {
                    sb.AppendLine($"{fieldInfo.Name} must be private!");

                }
            }
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (MethodInfo methodInfo in methodInfos)
            {
                if (methodInfo.Name.ToLower().Contains("get"))
                {
                    if (!methodInfo.IsPublic)
                    {
                        sb.AppendLine($"{methodInfo.Name} have to be public!");
                    }
                }
                else if (methodInfo.Name.ToLower().Contains("set"))
                {
                    if (!methodInfo.IsPrivate)
                    {
                        sb.AppendLine($"{methodInfo.Name} have to be private!");
                    }
                }

            }

            return sb.ToString().TrimEnd();
        }

        public string StealFieldInfo(string investigationClass, params string[] fieldsToInvestigate)
        {
            Type type = Type.GetType(investigationClass);
            StringBuilder sb = new StringBuilder();
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            sb.AppendLine($"Class under investigation: {type.FullName}");
            foreach (var field in fieldsToInvestigate)
            {
                foreach (var fieldInfo in fields)
                {
                    if (fieldInfo.Name == field)
                    {
                        Hacker hackerInstance = (Hacker) Activator.CreateInstance(type);
                        sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(hackerInstance)}");
                        break;
                    }
                }

            }
            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach(var methodInfo in methodInfos)
            {
                sb.AppendLine(methodInfo.Name);
            }
            return sb.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type type = Type.GetType(className);
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            StringBuilder sb = new StringBuilder();
            foreach(var methodInfo in methodInfos)
            {
                if (methodInfo.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
                }
            }
            foreach (var methodInfo in methodInfos)
            {
                if (methodInfo.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
                }
            }
            return sb.ToString().TrimEnd();


        }
    }
}
