using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

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
            /*
            foreach (var item in testedclass.getconstructors())
            {
                if (item.ispublic)
                {
                    return true;
                }
            }
            return false;
            */

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
                Console.WriteLine(method);

                foreach (var parameter in method.GetParameters())
                {
                    Console.WriteLine(parameter);

                    if (parameter.ParameterType.Name == param)
                    {
                        Console.WriteLine(method);
                        sw.WriteLine(method);
                    }
                }
            }
        }
        public static void Invoke(string name, string methodName)
        {
            try
            {
                Type type = Type.GetType(name, false, true);
                object obj = Activator.CreateInstance(type);

                string[] str = File.ReadAllLines(@"Invoke.txt");
                List<string> app = new List<string>();
                Random random = new Random();

                if (str.Length == 0)
                {
                    if (type.Name == "Product")
                    {
                        str = new string[3];
                        string temp;
                        for (int i = 0; i < 3; i++)
                        {
                            int j = random.Next(10);
                            temp = $"Preduct{j}";
                            str[i] = temp;

                        }
                    }
                }
                foreach (var temp in str)
                {
                    app.Add(temp);
                }
                List<string>[] list = new List<string>[] { app };
                MethodInfo method = type.GetMethod(methodName);
                method.Invoke(obj, list);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public static object Create(string name)
        {
            return Activator.CreateInstance(Type.GetType(name));
        }
    }
}