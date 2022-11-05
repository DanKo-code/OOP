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
            ////Вызвал методы с одинаковым иминем
            //Console.WriteLine("Вызвал методы с одинаковым иминем");
            //Cartoon cartoon_1 = new Cartoon();

            //cartoon_1.PrintFragment();

            //((Film)cartoon_1).PrintFragment();

            //if (cartoon_1 is Film test) test.PrintFragment();

            //Console.Write("\n\n\n");

            ////Поработал с as/is
            //Console.WriteLine("Поработал с as/is");
            //TvProgram tvprogram = new News(20);
            //Foo(tvprogram);
            //tvprogram = new Advertising();
            //Foo(tvprogram);
            //tvprogram = new Cartoon();
            //Foo(tvprogram);

            //tvprogram = null;
            //tvprogram = new HoodMovie();
            //Bar(tvprogram);

            //Console.Write("\n\n\n");

            ////Поработал с object.override
            //News test_over_1 = new News(20);
            //News test_over_2 = new News(30);

            //test_over_1.Equals(test_over_2);

            //Console.Write("\n\n\n");
            ////Printer
            //Console.WriteLine("Поработал с Printer");
            //TvProgram[] items = { new News(40), new Advertising(), new Cartoon() };
            //Printer a = new Printer();

            //a.IAmPrinting(items);

            //News.Print pr1;

            //pr1.Foo(test_over_1);

            /////////////////////////////////////5////////////////////////////////////////////
            ///

            var first = TvProgram.HostFees.Artem;

            Advertising advertising1 = new Advertising();
            advertising1.Duration = 1;

            TvProgram.Print p = new TvProgram.Print();
            p.Foo(advertising1);

            ///////////////////////////////////////////////////////////////

            News news = new News(10);
            
            Advertising advertising2 = new Advertising();
            advertising2.Duration = 2;

            Cartoon cartoon = new Cartoon();
            cartoon.Duration = 20;
            cartoon.releaseYear = 1980;

            Cartoon cartoon2 = new Cartoon();
            cartoon2.Duration = 20;
            cartoon2.releaseYear = 1981;

            Advertising advertising3 = new Advertising();
            advertising3.Duration = 3;

            HoodMovie hoodmovie = new HoodMovie();
            hoodmovie.Duration = 180;
            hoodmovie.releaseYear = 1980;

            Advertising advertising4 = new Advertising();
            advertising4.Duration = 1;

            ProgramGuide pg = new ProgramGuide();

           

            pg.Push_Back(advertising1);
            pg.Push_Back(news);
            pg.Push_Back(advertising2);
            pg.Push_Back(cartoon);
            pg.Push_Back(cartoon2);
            pg.Push_Back(advertising3);
            pg.Push_Back(hoodmovie);
            pg.Push_Back(advertising4);

            var testGetSameYearFilms = pg.GetSameYearFilms(1980);
            var programtime = pg.GetProgramTime();
            var advertisingNumb = pg.GetAdvertisingNumb();

            pg.Print();

            var item = pg.Get(0);
            pg.Set(advertising1, 1);

            Console.WriteLine("\n\n");

            pg.Delete(5);
            pg.Delete(3);

            pg.Print();

           

            Console.ReadKey();
        }

        static void Foo(object obj)
        {
            if(obj is TvProgram test)
            {
                test.PrintFragment();
            }
        }

        static void Bar(object obj)
        {
            TvProgram temp = obj as TvProgram;

            if(temp!=null)
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
