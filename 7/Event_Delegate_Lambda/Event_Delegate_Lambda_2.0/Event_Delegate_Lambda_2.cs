using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab08
{
    class Program
    {
        static void Main(string[] args)
        {
            Boss DANILA = new Boss();

            Worker Nikita = new Worker(100, 10);
            Technique kamaz = new Technique(100, 50);

            DANILA.Upgrade += () => { Console.WriteLine("Я работаю!"); };
            DANILA.TurnOn += () => { Console.WriteLine("Я отдохнул!"); };

            DANILA.Use(Nikita);
            DANILA.Reestablish(Nikita);

            DANILA.Upgrade -= () => { Console.WriteLine("Я работаю!"); }; ;
            DANILA.TurnOn -= () => { Console.WriteLine("Я отдохнул!"); };

            DANILA.Upgrade += () => { Console.WriteLine("При помощи меня работают!"); };
            DANILA.TurnOn +=() => { Console.WriteLine("Меня починили!"); };

            DANILA.Use(kamaz);
            DANILA.Reestablish(kamaz);


            // Func
            Func<string, string> A1;
            string str1 = "Nikita; .Danila, Artem; Ivan";
            Console.WriteLine($"\n\nСтрока: {str1}");
            A1 = StringEditor.RemovePunctuation;
            Console.WriteLine($"{A1.Method.Name}: {A1(str1)}");
            A1 = StringEditor.AddSymbol;
            Console.WriteLine($"{A1.Method.Name}: {A1(str1)}");
            A1 = StringEditor.ToUpper;
            Console.WriteLine($"{A1.Method.Name}: {A1(str1)}");
            A1 = StringEditor.ToLower;
            Console.WriteLine($"{A1.Method.Name}: {A1(str1)}");
            A1 = StringEditor.RemoveSpace;
            Console.WriteLine($"{A1.Method.Name}: {A1(str1)}");

            // Action
            void Add(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
            StringEditor.DoOperation(1, 2, Add);

            // Predicate
            string str2 = "";
            StringEditor.IsEmpty(str2.Length);


            Console.ReadKey();
        }

    }
}