using System;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Net.NetworkInformation;

namespace OOP_Lab15
{
    public static class Methods
    {
        public static void SimpleNumbers()
        {

            using (StreamWriter sw = new StreamWriter(@"out.txt"))
            {
                Console.WriteLine("\nВведите n: ");
                int n = int.Parse(Console.ReadLine());
                for (var i = 1; i <= n; i++)
                {
                    var isSimple = true;
                    for (var j = 2; j <= i / 2; j++)
                        if (i % j == 0)
                        {
                            isSimple = false;
                            break;
                        }

                    if (isSimple)
                    {
                        Console.WriteLine($"{i} ");
                        sw.WriteLine($"{i} ");
                        Thread.Sleep(100); 
                    }


                }
            }
                
        }

        static object locker = new object();
        static AutoResetEvent waitHandler = new AutoResetEvent(true);  // объект-событие
        static Mutex mutexObj = new Mutex();

        public static void EvenNumbers()
        {
            for (int i = 0; i <= 19; i++)
            {
                if (i % 2 == 0)
                {
                    //Console.Write($"{i} ");
                    Print(i);
                    Thread.Sleep(1000);
                }
            }
        }

        ////////////////////////////////////////////////
        public static void Print(int i)
        {
            mutexObj.WaitOne();     // приостанавливаем поток до получения мьютекса

            //waitHandler.WaitOne();

            //bool acquiredLock = false;
            //try
            //{
            //    Monitor.Enter(locker,ref acquiredLock);

            //lock (locker)
            //{
            Console.Write($"{i} ");
            //}

            //}
            //finally
            //{
            //    if(acquiredLock) Monitor.Exit(locker);
            //}

            //waitHandler.Set();

            mutexObj.ReleaseMutex();    // освобождаем мьютекс

        }
        ////////////////////////////////////////////////

        public static void OddNumbers()
        {
            for (int i = 0; i <= 19; i++)
            {
                if (i % 2 != 0)
                {
                    //Console.Write($"{i} ");
                    Print(i);
                    Thread.Sleep(1100);
                }
            }
        }

      

        public static void Task5(object obj)
        {
            for (int i = 0; i < (int)obj; i++)
            {
                Console.WriteLine($"\nТаймер!!! {i}");
            }
            
        }
    }
}
