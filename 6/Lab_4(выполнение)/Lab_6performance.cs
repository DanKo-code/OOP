using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;


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

            //Advertising advertising1 = new Advertising();
            //advertising1.Duration = 1;

            //News news = new News(10);

            //Advertising advertising2 = new Advertising();
            //advertising2.Duration = 2;

            //Cartoon cartoon = new Cartoon();
            //cartoon.Duration = 20;
            //cartoon.releaseYear = 1980;

            //Advertising advertising3 = new Advertising();
            //advertising3.Duration = 3;

            //HoodMovie hoodmovie = new HoodMovie();
            //hoodmovie.Duration = 180;
            //hoodmovie.releaseYear = 1980;

            //Advertising advertising4 = new Advertising();
            //advertising4.Duration = 1;

            //ProgramGuide pg = new ProgramGuide();



            //pg.Push_Back(advertising1);
            //pg.Push_Back(news);
            //pg.Push_Back(advertising2);
            //pg.Push_Back(cartoon);
            //pg.Push_Back(advertising3);
            //pg.Push_Back(hoodmovie);
            //pg.Push_Back(advertising4);

            //var testGetSameYearFilms = pg.GetSameYearFilms(1980);
            //var programtime = pg.GetProgramTime();
            //var advertisingNumb = pg.GetAdvertisingNumb();

            //pg.Print();

            //var item = pg.Get(0);
            //pg.Set(advertising1, 1);

            //Console.WriteLine("\n\n");

            //pg.Delete(5);
            //pg.Delete(3);

            //pg.Print();
            //////////////////////////////////6//////////////////////////////////////////
            ///

            Advertising advertising1 = new Advertising();
            advertising1.Duration = 1;

            News news = new News(10);

            Cartoon cartoon = new Cartoon();
            cartoon.Duration = 20;
            cartoon.releaseYear = 1980;

            HoodMovie hoodmovie = new HoodMovie();
            hoodmovie.Duration = 180;
            hoodmovie.releaseYear = 1980;

            ProgramGuide pg6 = new ProgramGuide();




            try
            {
                try
                {
                    ////1 пустая коллекция
                    //pg6.Delete(0);
                    //pg6.Print();
                    //pg6.GetProgramTime();

                    ////2 передал нулевую ссылку
                    pg6.Push_Back(advertising1);
                    pg6.Push_Back(news);
                    pg6.Push_Back(cartoon);
                    pg6.Push_Back(hoodmovie);

                    hoodmovie = null;
                    //pg6.Push_Back(hoodmovie);
                    pg6.Set(hoodmovie, 0);   // assert

                    //3 неверный индекс
                   //pg6.Delete(7);
                    //pg6.Set(hoodmovie, 7);
                    //pg6.Get(7);

                    //4 выход за пределы диапазона
                    //pg6.GetSameYearFilms(1000);


                }
                catch (NullCollectionException exeption)
                {
                    Console.WriteLine(exeption.Message);
                    Console.WriteLine(exeption.TargetSite);
                    Console.WriteLine(exeption.StackTrace);
                    throw;
                }
                catch (WrongIndexException exeption)
                {
                    Console.WriteLine(exeption.Message);
                    Console.WriteLine(exeption.TargetSite);
                    Console.WriteLine(exeption.StackTrace);
                    throw;
                }
                catch (OutOfTvProgramRange exeption)
                {
                    Console.WriteLine(exeption.Message);
                    Console.WriteLine(exeption.TargetSite);
                    Console.WriteLine(exeption.StackTrace);
                    throw;
                }
                catch (TestNullObject exeption)
                {
                    Console.WriteLine(exeption.Message);
                    Console.WriteLine(exeption.TargetSite);
                    Console.WriteLine(exeption.StackTrace);
                    throw;
                }
            }
            catch (OverflowException exeption)
            {
                Console.WriteLine(exeption.Message);
                Console.WriteLine(exeption.TargetSite);
                Console.WriteLine(exeption.StackTrace);
            }
            catch (NullReferenceException exeption)
            {
                Console.WriteLine(exeption.Message);
                Console.WriteLine(exeption.TargetSite);
                Console.WriteLine(exeption.StackTrace);
            }
            catch
            {
                Console.WriteLine("Конечная обработка");
            }
            finally
            {
                Console.WriteLine("Тест закончился");
            }

            Debugger.Launch(); //присоед отладчик
            Debugger.IsLogging(); //Проверяет, включено ли ведение журнала для присоединенного отладчика.
            Debugger.Break(); //точка останова



            int n = 11;
            Debug.Assert(n < 1, "Недопустимое значение"); //Проверяет условие. Если условие имеет значение false, выдается указанное сообщение и отображается окно сообщения со стеком вызовов.

            int[] aa = null;
            Debug.Assert(aa != null, "Values array cannot be null");


            Debug.Indent(); //задает уровень отступа
            Debug.WriteLine("Entering Main"); //Записывает имя категории и значение метода ToString() объекта в прослушиватели трассировки в коллекции Listeners.
            Console.WriteLine("Hello World.");
            Debug.WriteLine("Exiting Main");
            Debug.Unindent(); 

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
