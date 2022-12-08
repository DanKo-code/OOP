using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test_Thread
{
    internal class Program
    {
        static void Main()
        {
            PriorityTest priorityTest = new PriorityTest();

            Thread thread1 = new Thread(priorityTest.ThreadMethod);
            thread1.Name = "ThreadOne";
            Thread thread2 = new Thread(priorityTest.ThreadMethod);
            thread2.Name = "ThreadTwo";
            thread2.Priority = ThreadPriority.BelowNormal;
            Thread thread3 = new Thread(priorityTest.ThreadMethod);
            thread3.Name = "ThreadThree";
            thread3.Priority = ThreadPriority.AboveNormal;

            thread1.Start();
            thread2.Start();
            thread3.Start();
            // Allow counting for 10 seconds.
            Thread.Sleep(5000);
            priorityTest.LoopSwitch = false;

            Console.WriteLine("Хто я");
            Console.ReadKey();
        }
    }


    class PriorityTest
    {
        static volatile bool loopSwitch;
        [ThreadStatic] static long threadCount = 0;

        public PriorityTest()
        {
            loopSwitch = true;
        }

        public bool LoopSwitch
        {
            set { loopSwitch = value; }
        }

        public void ThreadMethod()
        {
            while (loopSwitch)
            {
                threadCount++;
            }
            Console.WriteLine("{0,-11} with {1,11} priority " +
                "has a count = {2,13}", Thread.CurrentThread.Name,
                Thread.CurrentThread.Priority.ToString(),
                threadCount.ToString("N0"));
        }
    }

        // Передача метода с параметрами в поток
        //static void Main()
        //{
        //    myThread t1 = new myThread("Thread 1", 6);
        //    myThread t2 = new myThread("Thread 2", 3);
        //    myThread t3 = new myThread("Thread 3", 2);

        //    Console.Read();
        //}

        ////static void Foo()
        ////{
        ////    for (int i = 0; i < 100; i++)
        ////    {
        ////        Console.WriteLine(i);
        ////        Thread.Sleep(1000);
        ////    }
        ////}


        //class myThread
        //{
        //    Thread thread;

        //    public myThread(string name, int num)   //Конструктор получает имя функции и номер до кторого ведется счет
        //    {                                       
        //        thread = new Thread(this.func);
        //        thread.Name = name;
        //        thread.Start(num);//передача параметра в поток
        //    }

        //    void func(object num)//Функция потока, передаем параметр
        //    {
        //        for (int i = 0; i < (int)num; i++)
        //        {
        //            Console.WriteLine(Thread.CurrentThread.Name + " выводит " + i);
        //            Thread.Sleep(1000);
        //        }
        //        Console.WriteLine(Thread.CurrentThread.Name + " завершился");
        //    }


        //}

        // Асинхронный метод
        //static async void Method()
        //{
        //    await Task.Run(() =>
        //    {
        //        while (x)
        //        {
        //            Console.WriteLine("Никита ПИДОР!!!");
        //            //Thread.Sleep(1000);
        //        }

        //    }
        //    );
        //}
}
