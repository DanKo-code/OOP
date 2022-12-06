using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System;
using System.Collections;
using System.Security.Cryptography;


namespace lab11
{
    class Program
    {
        class MyClass
        {
            void A() { }
            public void B() { }

            int a;
        }

        

        static void Main(string[] args)
        {
            

            Assembly testedAssmbly = Assembly.LoadFrom("C:\\2курс, 1 сем\\ООП\\2\\Lab_2\\bin\\Release\\Lab_2.exe");

            Type? testedClass = testedAssmbly.GetType("Lab_2.Lab_2+Phone");

            var res_33 = testedClass.GetMembers();

            Reflector.GetParametersFromFile(testedClass, "set_GetSetlongDistanceCallTime", "Invoke.txt");

            using (StreamWriter sw = new StreamWriter("Reflection.txt", false, Encoding.Default))
            {
                sw.WriteLine("-----определение имени сборки------");
                sw.WriteLine(Reflector.GetAssemblyName(testedClass));
                sw.WriteLine("-----наличие публичных конструкторов----- ");
                sw.WriteLine(Reflector.HasPublicConstructors(testedClass));
                sw.WriteLine("-----все общедоступные публичные методы------");

                Reflector.PublicMethods(testedClass, sw);
                sw.WriteLine("-----информация о полях и свойствах класса------");
                Reflector.FieldsAndProperties(testedClass, sw);
                sw.WriteLine("-----все реализованные классом интерфейсы------");
                Reflector.Interfaces(testedClass, sw);
                sw.WriteLine("-----выводит по имени класса имена методов, тип параметров, которых совпадает с пользовательским------");
                Reflector.MethodType(testedClass, "String", sw);
                sw.WriteLine("-----метод Invoke------");

                var testUser = Reflector.CreateObject(testedClass);

                Reflector.Invoke(testedClass,
                                 testUser,
                                 "set_GetSetlongDistanceCallTime",
                                 Reflector.GetParametersFromFile(testedClass, "set_GetSetlongDistanceCallTime", "Invoke.txt") //ДАНИЛА, введи число
                                 /*Reflector.GetRandomParameters(testedClass, "set_GetSetlongDistanceCallTime")*/);
                sw.WriteLine("****************************************************************************");
            }

            testedClass = typeof(Employees);

            using (StreamWriter sw = new StreamWriter("Reflection_2.txt", false, Encoding.Default))
            {
                sw.WriteLine("-----определение имени сборки------");
                sw.WriteLine(Reflector.GetAssemblyName(testedClass));
                sw.WriteLine("-----наличие публичных конструкторов----- ");
                sw.WriteLine(Reflector.HasPublicConstructors(testedClass));
                sw.WriteLine("-----все общедоступные публичные методы------");

                Reflector.PublicMethods(testedClass, sw);
                sw.WriteLine("-----информация о полях и свойствах класса------");
                Reflector.FieldsAndProperties(testedClass, sw);
                sw.WriteLine("-----все реализованные классом интерфейсы------");
                Reflector.Interfaces(testedClass, sw);
                sw.WriteLine("-----выводит по имени класса имена методов, тип параметров, которых совпадает с пользовательским------");
                Reflector.MethodType(testedClass, "String", sw);
                sw.WriteLine("-----метод Invoke------");

                var testUser = Reflector.CreateObject(testedClass, new object[] { 1,2,3 });

                Reflector.Invoke(testedClass,
                                 testUser,
                                 "Work",
                                 /*Reflector.GetParametersFromFile(testedClass, "Work", "Invoke.txt")*/ //ДАНИЛА, введи число
                                 Reflector.GetRandomParameters(testedClass, "Work"));
                sw.WriteLine("****************************************************************************");
            }

            testedAssmbly = Assembly.LoadFrom("C:\\2курс, 1 сем\\ООП\\9\\Collections\\obj\\Debug\\net6.0\\Collections.dll");

            //foreach (var item in testedAssmbly.GetTypes())
            //{
            //    Console.WriteLine(item.FullName);
            //}

            testedClass = testedAssmbly.GetType("lab10.MyCollection`1");

            using (StreamWriter sw = new StreamWriter("Reflection_3.txt", false, Encoding.Default))
            {
                sw.WriteLine("-----определение имени сборки------");
                sw.WriteLine(Reflector.GetAssemblyName(testedClass));
                sw.WriteLine("-----наличие публичных конструкторов----- ");
                sw.WriteLine(Reflector.HasPublicConstructors(testedClass));
                sw.WriteLine("-----все общедоступные публичные методы------");

                Reflector.PublicMethods(testedClass, sw);
                sw.WriteLine("-----информация о полях и свойствах класса------");
                Reflector.FieldsAndProperties(testedClass, sw);
                sw.WriteLine("-----все реализованные классом интерфейсы------");
                Reflector.Interfaces(testedClass, sw);
                sw.WriteLine("-----выводит по имени класса имена методов, тип параметров, которых совпадает с пользовательским------");
                Reflector.MethodType(testedClass, "String", sw);
                sw.WriteLine("-----метод Invoke------");

                var chairType = testedAssmbly.GetType("lab10.Furniture");
                var chair = Reflector.CreateObject(chairType, new object[] { "chair" });

                //var store = Reflector.CreateObject(testedClass);

                //Reflector.Invoke(testedClass,
                //                 testUser,
                //                 "Work",
                //                 Reflector.GetParametersFromFile(testedClass, "Work", "Invoke.txt") //ДАНИЛА, введи число
                //                 /*Reflector.GetRandomParameters(testedClass, "set_GetSetlongDistanceCallTime")*/);
                sw.WriteLine("****************************************************************************");
            }
        }
    }
}