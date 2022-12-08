using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class Program
    {
        class MyClass
        {

            record class Person(string Name, int Age);

            public void Print(object? obj)
            {
                // здесь мы ожидаем получить объект Person
                if (obj is Person person)
                {
                    Console.WriteLine($"Name = {person.Name}");
                    Console.WriteLine($"Age = {person.Age}");
                }
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
