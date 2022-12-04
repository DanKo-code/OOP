using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Collections;

namespace lab11
{
    static class Reflector
    {
        public static string GetAssemblyName(Type testedClass)
        {
            return testedClass.Assembly.FullName;
        }

        public static bool HasPublicConstructors(Type testedClass)
        {
            if (testedClass.GetConstructors(BindingFlags.Instance | BindingFlags.Public).Length != 0) return true;
            return false;
        }

        public static IEnumerable<string> PublicMethods(Type testedClass, StreamWriter sw)
        {
            List<string> list = new List<string>();
            foreach (MethodInfo method in testedClass.GetMethods())
            {
                if (method.IsPublic)
                {
                    list.Add(method.Name);
                    sw.WriteLine(method.Name);
                }
            }
            return list;
        }
        public static IEnumerable<string> FieldsAndProperties(Type testedClass, StreamWriter sw)
        {
            List<string> list = new List<string>();
            foreach (var item in testedClass.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                list.Add(item.Name);
                sw.WriteLine(item.Name);
            }
            foreach (var item in testedClass.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static))
            {
                list.Add(item.Name);
                sw.WriteLine(item.Name);
            }
            return list;
        }
        public static IEnumerable<string> Interfaces(Type testedClass, StreamWriter sw)
        {
            List<string> list = new List<string>();
            
            foreach (var item in testedClass.GetInterfaces())
            {
                list.Add(item.Name);
                sw.WriteLine(item.Name);
            }

            return list;
        }
        public static void MethodType(Type testedClass, string param, StreamWriter sw)
        {
            foreach (var method in testedClass.GetMethods(BindingFlags.Public |
                                                   BindingFlags.NonPublic |
                                                   BindingFlags.Static |
                                                   BindingFlags.Instance))
            {
                Console.WriteLine(method); // убрать!

                foreach (var parameter in method.GetParameters())
                {
                    Console.WriteLine(parameter); // убрать!

                    if (parameter.ParameterType.Name == param)
                    {
                        Console.WriteLine(method); // убрать!
                        sw.WriteLine(method);
                    }
                }
            }
        }
        public static object[] GetParametersFromFile(Type testedClass, string methodName, string FileName)
        {
            object[] strFile = File.ReadAllLines(FileName);

            MethodInfo method = testedClass.GetMethod(methodName);

            ArrayList buff = new ArrayList();

            int i = 0;
            foreach (var parameter in method.GetParameters())
            {
                buff.Add(Convert.ChangeType(strFile[i++], parameter.ParameterType));
            }

            return buff.ToArray();
        }

        public static object[] GetRandomParameters(Type testedClass, string methodName)
        {
            MethodInfo method = testedClass.GetMethod(methodName);

            ArrayList buff = new ArrayList();

            Random random = new Random();

            foreach (var parameter in method.GetParameters())
            {
                byte[] b = new byte[1];

                random.NextBytes(b);

                buff.Add(Convert.ChangeType(b[0], parameter.ParameterType));
            }

            return buff.ToArray();
        }

        public static void Invoke(Type testedClass, object typeInstance, string methodName, object[] methodParams)
        {
            try
            {
                MethodInfo method = testedClass.GetMethod(methodName);
                method.Invoke(typeInstance, methodParams);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static object CreateObject(Type testedClass, object[] parameters)
        {
            return Activator.CreateInstance(testedClass, parameters);
        }

        public static object CreateObject(Type testedClass)
        {
            return Activator.CreateInstance(testedClass);
        }
    }
}