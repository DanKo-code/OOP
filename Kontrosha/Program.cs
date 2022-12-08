using System.Collections.Generic;

namespace Kontrosha
{
    internal class Program
    {
        class SuperLinkedList<T> : LinkedList<T>
        {
            public LinkedList<T> items = new LinkedList<T>();

            public new void Removee(T item)
            {
                foreach (var item_2 in items)
                {
                    if (item.Equals(item_2))
                    {
                        items.Remove(item);
                        return;
                    } 
                }

                throw new Exception();
            }

            public new void AddLastt(T item)
            {
                items.AddLast(item);
            }
        }

        static void Main(string[] args)
        {
            SuperLinkedList<string> A = new SuperLinkedList<string>();

            A.AddLastt("1");
            A.AddLastt("2");
            A.AddLastt("3");
            A.AddLastt("123457");

            try
            {
                A.Removee("2");
            }
            catch
            {

                Console.WriteLine("Данного элемента нет в коллекции!");
            }

            ///////////////////////////////////////////////////////////
            ///

            var temp = A.items.Where(a => a.Length < 6);

            foreach (var item in temp)
            {
                Console.WriteLine(item);
            }

            ///////////////////////////////////////////////////////////
            ///

            Dres Danila = new Dres("Danila");

            KON kon_1 = new KON("kon_1");
            KON kon_2 = new KON("kon_2");
            KON kon_3 = new KON("kon_3");

            Danila.TurnOn += kon_1.StayDubu;
            Danila.TurnOn += kon_2.StayDubu;
            Danila.TurnOn += kon_3.StayDubu;

            Danila.Command();
        }

        class Dres
        {
            public delegate void StateHandler();
            public event StateHandler? TurnOn;

            public Dres(string name)
            {
                Name = name;
                
            }

            public void Command()
            {
                Console.WriteLine("Вставайте!");

                TurnOn?.Invoke();
            }

            string Name;
          
        }

        class KON
        {
            public KON(string name)
            {
                this.name = name;
            }

            public void StayDubu() { Console.WriteLine($"Конь {this.name} встал на дыба!"); }

            public string name;
        }
    }
}