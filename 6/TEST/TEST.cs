using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace TEST
{

    class Program
    {
        static int ExeceptionExample(int x, int y)
        {
            if (y == 0)
            {
                Exception a = new Exception("Nikita");
                a.HelpLink = "http://www.belstu.by";
                a.Data.Add("Время возникновения: ", DateTime.Now);
                throw a;
            }
            return x / y;
        }

        public class A
        {
            public A()
            {

            }
        }

        public static void Foo(A test)
        {

        }

        static void Main()
        {
            try
            {
                Main();
            }
            catch
            {
                Console.WriteLine("nikita");
                
            }
           

            //A a = null; 

            ////a = null;

            //Program.Foo(a);

            //a = null;

            //Foo()

            //try
            //{
            //    int x = int.Parse(Console.ReadLine());
            //    int y = int.Parse(Console.ReadLine());
            //    ExeceptionExample(x, y);
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message + "\n\n");
            //    Console.WriteLine(ex.TargetSite + "\n\n");
            //    Console.WriteLine(ex.StackTrace + "\n\n");
            //    Console.WriteLine(ex.HelpLink + "\n\n");
            //}




            //try
            //{
            //    string str = "sdcsd";

            //    int a = int.Parse(str);
            //}
            //catch (Exception ex) when
            //(ex.GetType() != typeof(System.FormatException))
            //{
            //    throw;
            //}
            //catch
            //{

            //}

            /////////////////////////////////////////////////////////////////////////
            ///



            //string[] str = new string[5];
            //try
            //{
            //    str[4] = "anything";
            //    Console.WriteLine("It's OK");
            //}
            //catch (IndexOutOfRangeException e)
            //{
            //    Console.WriteLine("IndexOutOfRangeException");
            //}
            //catch (Exception e)
            //{
            //    e.
            //    Console.WriteLine("Exception");
            //}


        }
    }
    
}
