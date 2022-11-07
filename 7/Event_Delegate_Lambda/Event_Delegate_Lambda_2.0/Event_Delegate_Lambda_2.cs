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


            //Func<string, string> A;
            //string str = "Nikita; .Danila, Artem; Ivan";
            //Console.WriteLine($"\n\nСтрока: {str}");
            //A = StringEditor.RemovePunctuation;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");
            //A = StringEditor.AddSymbol;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");
            //A = StringEditor.ToUpper;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");
            //A = StringEditor.ToLower;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");
            //A = StringEditor.RemoveSpace;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");

            Console.ReadKey();
        }

    }
}