using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contr_Nikita
{
    public static class StatisticOperation
    {
        public static void NullSum(this Program.Bag p)
        {
            p.Sum = 0;
        }
    }

    public class Program
    {
        interface IBank
        {
            int Minus(int sum);
        }


        public class Bag : IComparable<Bag>, IBank
        {
            public int Minus(int sum)
            {
                return (int)(sum * 0.9);
            }


            public string Name { get; set; }
            public int Sum { get; set; }

            public int CompareTo(Bag p)
            {
                return this.Sum.CompareTo(p.Sum);
            }
        }

        class Cassa :Bag, IBank
        {
            new public int Minus(int sum)
            {
                return (int)(sum * 0.5);
            }
        }



        static void Main(string[] args)
        {
            Bag first = new Bag();
            Bag second = new Bag();

            first.Sum = 11;
            second.Sum = 10;

            first.CompareTo(second);
            StatisticOperation.NullSum(second);


            Cassa cassa = new Cassa();
            cassa.Minus(100);
            ((Bag)cassa).Minus(100);
            ((IBank)cassa).Minus(100);
        }
    }
    
}
