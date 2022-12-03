using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace lab11
{
    class Program
    {
        class MyClass
        {
            private MyClass() { }

            public void Print() { }
        }

        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("C:\\2курс, 1 сем\\ООП\\2\\Lab_2\\bin\\Release\\Lab_2.exe");

            Type? testedClass = asm.GetType("Lab_2.Lab_2+Phone");
            


            string name = "lab11.Product";
            using (StreamWriter sw = new StreamWriter(@"Reflection.txt", false, Encoding.Default))
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
                Reflector.Invoke(name, "PrintProducts");
                sw.WriteLine(Reflector.Create(name).ToString());
                sw.WriteLine("****************************************************************************");
            }

            //name = "lab11.Employees";
            //using (StreamWriter sw = new StreamWriter(@"Reflection.txt", true, Encoding.Default))
            //{
            //    sw.WriteLine("-----определение имени сборки------");
            //    sw.WriteLine(Reflector.GetAssemblyName());
            //    sw.WriteLine("-----публичные конструкторы----- ");
            //    sw.WriteLine(Reflector.HasPublicConstructors(name));
            //    sw.WriteLine("-----все общедоступные публичные методы------");
            //    Reflector.PublicMethods(name, sw);
            //    sw.WriteLine("-----информация о полях и свойствах класса------");
            //    Reflector.FieldsAndProperties(name, sw);
            //    sw.WriteLine("-----все реализованные классом интерфейсы------");
            //    Reflector.Interfaces(name, sw);
            //    sw.WriteLine("-----выводит по имени класса имена методов------");
            //    Reflector.MethodType(name, "Int32", sw);
            //    sw.WriteLine(Reflector.Create(name).ToString());
            //    sw.WriteLine("****************************************************************************");
            //}

            //name = "System.Type";
            //using (StreamWriter sw = new StreamWriter(@"Reflection.txt", true, Encoding.Default))
            //{
            //    sw.WriteLine("-----определение имени сборки------");
            //    sw.WriteLine(Reflector.GetAssemblyName());
            //    sw.WriteLine("-----публичные конструкторы----- ");
            //    sw.WriteLine(Reflector.HasPublicConstructors(name));
            //    sw.WriteLine("-----все общедоступные публичные методы------");
            //    Reflector.PublicMethods(name, sw);
            //    sw.WriteLine("-----информация о полях и свойствах класса------");
            //    Reflector.FieldsAndProperties(name, sw);
            //    sw.WriteLine("-----все реализованные классом интерфейсы------");
            //    Reflector.Interfaces(name, sw);
            //    sw.WriteLine("-----выводит по имени класса имена методов------");
            //    Reflector.MethodType(name, "value", sw);
            //}
        }
    }
}