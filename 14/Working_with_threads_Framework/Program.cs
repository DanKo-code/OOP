using System;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace OOP_Lab15
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            ////Задание 1.Процессы и информация о них
            //var allProcesses = Process.GetProcesses();                  /// получаем массив со всеми процессами
            //Console.WriteLine("Информация о процессах:");
            //Console.Write("{0,-10}", "ID:");
            //Console.Write("{0,-40}", "Process Name:");
            //Console.Write("{0,-30}", "Priority:");

            //Console.Write("{0,-30}", "Start Time:");

            //Console.Write("{0,-10}", "Use Time:");

            //Console.WriteLine();
            //foreach (Process process in allProcesses)
            //{
            //    try
            //    {
            //        Console.Write("{0,-10}", $"{process.Id}");
            //        Console.Write("{0,-40}", $"{process.ProcessName}");
            //        Console.Write("{0,-30}", $"{process.BasePriority}");

            //        Console.Write("{0,-30}", $"{process.StartTime}");

            //        Console.Write("{0,-10}", $"{process.UserProcessorTime}");

            //        Console.WriteLine();
            //        Console.WriteLine();
            //    }
            //    catch
            //    {
            //        Console.WriteLine("Отказано в доступе!");
            //    }

            //}



            ////Задание 2.Исследование текущего домена
            //Console.WriteLine("\n\n\n\nТекущий домен:         " + AppDomain.CurrentDomain.FriendlyName);
            //Console.WriteLine("Детали конфигурации:   " + AppDomain.CurrentDomain.SetupInformation);
            //Console.WriteLine("Все сборки в домене:\n");
            //foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
            //    Console.WriteLine(ass.GetName().Name);

            //AppDomain domain = AppDomain.CreateDomain("MyDomain");          //создал домен
            //domain.Load("Working_with_threads_Framework");
            //AppDomain.Unload(domain);



            //// Задание 3. Вывод простых чисел от 1 до n
            //Thread simpleThread = new Thread(Methods.SimpleNumbers);
            //simpleThread.Start();

            //Console.WriteLine("Выполняется ли поток: " + simpleThread.IsAlive);
            //Console.WriteLine("Приоритет потока: " + simpleThread.Priority);
            //Console.WriteLine("Идентификатор: " + simpleThread.ManagedThreadId);
            //Console.WriteLine("Статус потока: " + simpleThread.ThreadState);

            //Thread.Sleep(4000);
            //simpleThread.Suspend();
            //Console.WriteLine($"Поток simpleThread приостановлен");

            //Thread.Sleep(4000);
            //simpleThread.Resume();
            //Console.WriteLine($"Поток simpleThread возобновлен");

            //Thread.Sleep(4000);
            //simpleThread.Abort();

            //Console.WriteLine($"Поток simpleThread завершен");





            //// Задание 4. Два потока четных и нечетных чисел
            //Console.WriteLine("\n\n\nПотоки чётных и нечётных чисел:\n");
            //Thread evenThread = new Thread(Methods.EvenNumbers);
            //Thread oddThread = new Thread(Methods.OddNumbers);

            //evenThread.Priority = ThreadPriority.AboveNormal;
            //oddThread.Priority = ThreadPriority.BelowNormal;
            //evenThread.Start();

            //////
            ////evenThread.Join();

            //Thread.Sleep(100);

            //oddThread.Start();




            // Задание 5. Класс Timer
            int num = 3;

            TimerCallback tm = new TimerCallback(Methods.Task5);
            Timer timer = new Timer(tm, num, 0, 1000);
            Thread.Sleep(4000);



            Console.ReadKey();
        }
    }
}
