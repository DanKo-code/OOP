using System.Collections.Generic;
using System.Linq;

namespace Nikita
{
    internal class Program
    {
        class LastCollection<T>
        {
            public List<string> list_str  = new List<string>();

            public void ADD(T item)
            {
               if(item is string test)
               {
                    list_str.Add(test);
               }
               else throw new Exception();
            }
        }


        static void Main(string[] args)
        {
            try
            {
                LastCollection<string> nikita = new LastCollection<string>();
                nikita.ADD("nikita");

                LastCollection<int> danila = new LastCollection<int>();
                danila.ADD(1);
            }
            catch
            {

                Console.WriteLine("Не удалось преобразовать в string выбранный вами T!");
            }

            ////////////////////////////////////////////////////////////////////
            ///

            string[] str_arr = { "nikita", "danila", "maksimm" };

            var res = str_arr.Where((items) => items.Last() == 'a' && items.Length < 7);


            foreach (var item in res)
            {
                Console.WriteLine(item);
            }

            ////////////////////////////////////////////////////////////////////
            AutoBaraholka debil = new AutoBaraholka("Baraholka");

            Car solaris = new Car("solaris");
            Car honda = new Car("honda");
            Car toyota = new Car("toyota");

            debil.TurnOn += solaris.Check;
            debil.TurnOn += honda.Check;
            debil.TurnOn += toyota.Check;

            debil.Pokypka();
        }

        class AutoBaraholka
        {
            public delegate void StateHandler();
            public event StateHandler? TurnOn;

            public AutoBaraholka(string name)
            {
                Name = name;
            }

            public void Pokypka()
            {
                Console.WriteLine("Начинаем покупать!");

                TurnOn?.Invoke();
            }

            string Name;

        }

        class Car
        {
            public Car(string name)
            {
                this.name = name;
            }

            public void Check() { Console.WriteLine($"Машина {this.name} проверяем состояние!"); }

            public string name;
        }
    }
}