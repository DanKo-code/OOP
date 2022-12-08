using System;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using System.Reflection;

namespace OOP_Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Задание 1. Процессы и информация о них
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



            // Задание 2. Исследование текущего домена
            Console.WriteLine("\n\n\n\nТекущий домен:         " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("Детали конфигурации:   " + AppDomain.CurrentDomain.SetupInformation);
            Console.WriteLine("Все сборки в домене:\n");
            foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
                Console.WriteLine(ass.GetName().Name);

            AppDomain domain = AppDomain.CreateDomain("MyDomain");
            //Assembly assembly = Assembly.Load("example");



            // Задание 3. Вывод простых чисел от 1 до n
            Thread simpleThread = new Thread(Methods.SimpleNumbers);    /// создаем новый поток
            simpleThread.Start();                                       /// запускаем его
            Console.WriteLine("\n\n\nИнформация о потоке:");
            Console.WriteLine("Выполняется ли поток: " + simpleThread.IsAlive);
            Console.WriteLine("Приоритет потока: " + simpleThread.Priority);
            Console.WriteLine("Идентификатор: " + simpleThread.ManagedThreadId);
            simpleThread.Join();                                        /// ждем пока он отработает 



            // Задание 4. Два потока четных и нечетных чисел
            Console.WriteLine("\n\n\nПотоки чётных и нечётных чисел:");
            Thread evenThread = new Thread(Methods.EvenNumbers);
            evenThread.Priority = ThreadPriority.AboveNormal;           /// меняем приоритет по заданию
            evenThread.Start();             /// если закомментить Join(), второй поток не будет ждать первый
            evenThread.Join();              // Чтобы выводились поочередно, надо закомментить эту строку!!!

            Console.WriteLine();
            Thread oddThread = new Thread(Methods.OddNumbers);
            oddThread.Priority = ThreadPriority.BelowNormal;
            oddThread.Start();
            oddThread.Join();



            // Задание 5. Класс Timer
            TimerCallback tm = new TimerCallback(Methods.Task5);        /// делегат для таймера
            Timer timer = new Timer(tm, null, 1000, 1000);              /// null - параметр которого нет, 1000 - 
            Thread.Sleep(4000);                                         /// время через которое запустится процесс
                                                                        /// с таймером, 1000 - периодичность таймера,
                                                                        /// 4000 - ждем и не закрываем поток
        }   
    }
}
