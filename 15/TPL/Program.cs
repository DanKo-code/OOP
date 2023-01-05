using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TPL
{
    internal class Program
    {
        static CancellationTokenSource tokenSource = new CancellationTokenSource();

        static Stopwatch stopWatch = new Stopwatch();

        static void Main(string[] args)
        {
            Console.WriteLine("1111111111111111111111111111112222222222222222222222222222222222222222222");

            Task task1 = new Task(() => ErSieve(30000000), tokenSource.Token);
            Console.WriteLine($"Task ID:              {task1.Id}");
            Console.WriteLine($"the task is completed ?: {task1.IsCompleted}");
            Console.WriteLine($"Status when created:  {task1.Status}");
            task1.Start();
            Console.WriteLine($"Status when started:  {task1.Status}\n");
            Console.WriteLine($"Status when started:  {task1.Status}\n");

            if ("1" == Console.ReadLine()) tokenSource.Cancel();

            task1.Wait();
            Console.WriteLine($"Status when ended:    {task1.Status}");


            //Stopwatch check_1 = new Stopwatch();
            //check_1.Start();1
            //ErSieve(30000000);
            //check_1.Stop();
            //Console.WriteLine($"Последовательное! {check_1.ElapsedMilliseconds}");





            Console.WriteLine("\n\n333333333333333333333333344444444444444444444444444444444444444444444");

            Task<int> task3_1 = new Task<int>(() =>
            {
                int x = 2;
                for (int i = 1; i < 7; i++)
                    x *= i;
                Console.WriteLine($"Result #1:            {x}");
                return x;
            });

            Task<int> task3_2 = new Task<int>(() =>
            {
                int x = 1;
                for (int i = 1; i < 4; i++)
                {
                    x++;
                    x *= x;
                }
                Console.WriteLine($"Result #2:            {x}");
                return x;
            });

            Task<int> task3_3 = new Task<int>(() =>
            {
                int z = -300;
                for (int i = 0; i < 54; i++)
                    z += i;
                Console.WriteLine($"Result #3:            {z}");
                return z;
            });

            Task task_after_123 = Task.WhenAll(/*task3_1,*/ task3_2, task3_3).ContinueWith(t => Sum(34, 43));

            //task3_1.Start();
            task3_2.Start();
            task3_3.Start();

            task_after_123.Wait();

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine("/////////////////////////////////////////////////////////////////////////////////");

            task3_1.Start();

            var awaiter = task3_1.GetAwaiter();

            awaiter.OnCompleted(() =>
            {
                Sum(awaiter.GetResult(), 43);
            });

            Console.WriteLine("\n\n555555555555555555555555555555555555555555555555555555555555555555555");
            List<int> list = new List<int>();

            Console.WriteLine("Foreach\n");

            for (int i = 0; i < 100000; i++)
            {
                list.Add(i);
            }

            Console.WriteLine("Parallel ForEach:\n");

            stopWatch.Restart();
            Parallel.ForEach<int>(list, Factorial);
            stopWatch.Stop();



            Console.WriteLine(stopWatch.ElapsedMilliseconds);


            Console.WriteLine("\nDefault ForEach:\n");
            stopWatch.Restart();
            foreach (int l in list)
            {
                Factorial(l);
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.ElapsedMilliseconds);

            Console.WriteLine("\n\nFor\n");
            stopWatch.Restart();

            Parallel.For(1, 100000, Factorial);

            stopWatch.Stop();
            Console.WriteLine("Parallel cycle:\n");
            Console.WriteLine(stopWatch.ElapsedMilliseconds);

            stopWatch.Start();

            for (int i = 1; i <= 100000; i++)
            {
                Factorial(i);
            }

            stopWatch.Stop();
            Console.WriteLine("\nDefault cycle:\n");
            Console.WriteLine(stopWatch.ElapsedMilliseconds);

            Console.WriteLine("\n\n66666666666666666666666666666666666666666666666666666666666666666666666666666666");

            Parallel.Invoke(
    () => Sum(1, 2),
    () =>
    {
        Console.WriteLine($"Выполняется задача {Task.CurrentId}\n");
        Thread.Sleep(3000);
    },
    () => Factorial(5)
);

            Console.WriteLine("\n777777777777777777777777777777777777777777777777777777777777777777777777777777777");

            CancellationTokenSource tokenSource_2 = new CancellationTokenSource();

            BlockingCollection<string> bc = new BlockingCollection<string>(5);

            Task[] sellers = new Task[5]
            {
                new Task (()=>{while (true) { Thread.Sleep(1000); bc.Add("Стул");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task (()=>{while (true) { Thread.Sleep(2000); bc.Add("Шкаф");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task (()=>{while (true) { Thread.Sleep(3000); bc.Add("Кирпич");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task (()=>{while (true) { Thread.Sleep(4000); bc.Add("Никита");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task (()=>{while (true) { Thread.Sleep(5000); bc.Add("Телевизор горизонт");if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
            };

            Task[] consumers = new Task[10]
            {
                new Task(() =>
                {
                    while(true)
                    {
                        Thread.Sleep(6000);

                        bc.Take();


                    }

                }),


                new Task(() => { while(true){ Thread.Sleep(5000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(5000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(5000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(5000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(5000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(5000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(5000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(5000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token),
                new Task(() => { while(true){ Thread.Sleep(5000);   bc.Take(); if(tokenSource_2.Token.IsCancellationRequested) return;} }, tokenSource_2.Token)
            };

            foreach (var item in sellers)
                if (item.Status != TaskStatus.Running)
                    item.Start();

            foreach (var item in consumers)
                if (item.Status != TaskStatus.Running)
                    item.Start();





            Task task7 = new Task(() =>
            {
                int count = 0;
                while (true)
                {
                    if (bc.Count != count && bc.Count != 0)
                    {
                        count = bc.Count;

                        Console.Clear();
                        Console.WriteLine("777777777777777777777777777777777777777777777777777777777777777777777777777");
                        Console.WriteLine("--------------- Склад ---------------");

                        foreach (var item in bc)
                            Console.WriteLine(item);

                        Thread.Sleep(400);

                        if (tokenSource_2.Token.IsCancellationRequested)
                        {
                            Console.WriteLine("\nProcess stopped.");
                            return;
                        }
                        Console.WriteLine("-------------------------------------");
                    }
                }
            }, tokenSource_2.Token);

            task7.Start();

            if ("7" == Console.ReadLine()) tokenSource_2.Cancel();

            task7.Wait();

            Console.WriteLine("\n8888888888888888888888888888888888888888888888888888888888888888888888888888888888");

           FactorialAsync(5);                               /// асинхронная функция факториала
        Console.WriteLine("Main is still running.");

            Func<Task> someM = (async () =>
            {
                // Task.Delay() - асинхронный аналог Thread.Sleep() 
                await Task.Delay(1000);
                Console.Write("working ...... ");

            });

            someM.Invoke();

            Console.ReadLine();
        }

        public static void ErSieve(int n)
        {
            for (int c = 0; c < 5; c++)
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                bool[] flags = new bool[n];

                for (int i = 0; i < flags.Length; i++)
                    flags[i] = true;

                flags[1] = false;
                for (int i = 2, j = 0; i < n;)
                {
                    if (flags[i])
                    {
                        j = i * 2;
                        while (j < n)
                        {
                            flags[j] = false;
                            j += i;
                        }
                    }
                    i++;
                }

                Console.WriteLine($"All simple numbers from 1 to {n}:");
                for (int i = 2; i < flags.Length; i++)
                {
                    if (flags[i])
                    {
                        Thread.Sleep(100);
                        Console.Write($"{i} ");
                    }

                    if (tokenSource.Token.IsCancellationRequested)
                    {


                        try
                        {
                            tokenSource.Token.ThrowIfCancellationRequested();
                        }
                        catch
                        {
                            stopWatch.Stop();

                            Console.WriteLine("\nTotal runtime in Milliseconds:        " + stopWatch.ElapsedMilliseconds);
                            Console.WriteLine("\nThe process was cenceled.");

                            return;
                        }

                    }
                }
                Console.WriteLine();

                stopWatch.Stop();

                Console.WriteLine("\nTotal runtime in Milliseconds:        " + stopWatch.ElapsedMilliseconds);
            }
           
        }

        public static int Sum(int a, int b)
        {
            Console.WriteLine($"Input A:              {a}\nInput B:              {b}");
            return (a + b);
        }

        public static void Factorial(int x)
        {
            long result = 1;

            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
        }

        public static async void FactorialAsync(int x)
        {
            Console.WriteLine("Start of FactorialAsync");
            await Task.Run(() => Factorial(x));
            Console.WriteLine("End of FactorialAsync");
        }
    }
  
}


//