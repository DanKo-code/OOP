using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //Вызвал методы с одинаковым иминем
            Console.WriteLine("Вызвал методы с одинаковым иминем");
            Cartoon cartoon_1 = new Cartoon();

            cartoon_1.PrintFragment();

            ((Film)cartoon_1).PrintFragment();

            if (cartoon_1 is Film test) test.PrintFragment();

            Console.Write("\n\n\n");

            //Поработал с as/is
            Console.WriteLine("Поработал с as/is");
            TvProgram tvprogram = new News(20);
            Foo(tvprogram);
            tvprogram = new Advertising();
            Foo(tvprogram);
            tvprogram = new Cartoon();
            Foo(tvprogram);

            tvprogram = null;
            tvprogram = new HoodMovie();
            Bar(tvprogram);

            Console.Write("\n\n\n");

            //Поработал с object.override
            News test_over_1 = new News(20);
            News test_over_2 = new News(30);

            test_over_1.Equals(test_over_2);

            Console.Write("\n\n\n");
            //Printer
            Console.WriteLine("Поработал с Printer");
            TvProgram[] items = { new News(40), new Advertising(), new Cartoon() };
            Printer a = new Printer();

            a.IAmPrinting(items);

            Console.ReadKey();
        }

        static void Foo(object obj)
        {
            if (obj is TvProgram test)
            {
                test.PrintFragment();
            }
        }

        static void Bar(object obj)
        {
            TvProgram temp = obj as TvProgram;

            if (temp != null)
            {
                temp.PrintFragment();
            }
        }


        class Printer
        {
            public void IAmPrinting(TvProgram[] example)
            {
                for (int i = 0; i < example.Length; i++)
                {
                    Console.WriteLine(example[i].ToString());
                }
            }
        }
    }
}
