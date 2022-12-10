//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Threading;
//using System.Threading.Tasks;

//namespace Laba16
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            Console.WriteLine();
//            // Task1();
//            // Task2();
//            // Task3();
//            // Task4();
//            // Task5();
//            //Task6();
//            //Task7();
//            Task8();
//            Console.ReadKey();
//        }

//        private static void Task1()
//        {
//            /*1. ��������� TPL �������� ���������� �� ������� ������ (�� ������
//           Task) �� �����:
//           ������: ������� ���������� ��������� ���-�� ������� ����� �� 1 �� enumerationBorder
//           */
//            var task = new Task<uint>(() => CountQuantityOfSimpleNumbers(1000));
//            Console.WriteLine($"Task #{task.Id} status - {task.Status}");

//            var stopwatch = new Stopwatch();
//            task.Start();
//            stopwatch.Start();
//            Console.WriteLine($"Task #{task.Id} status - {task.Status}");
//            task.Wait();
//            stopwatch.Stop();
//            Console.WriteLine($"Task #{task.Id} status - {task.Status}");
//            Console.WriteLine($"Task - Method has been working for {stopwatch.ElapsedMilliseconds} ms ");
//            Console.WriteLine($"Quantity of simple numbers from 1 to 1000 is {task.Result}");

//            stopwatch.Restart();
//            uint mainThreadResult = CountQuantityOfSimpleNumbers(1000);
//            stopwatch.Stop();
//            Console.WriteLine($"Main Thread Method has been working for {stopwatch.ElapsedMilliseconds} ms ");
//            Console.WriteLine($"Quantity of simple numbers from 1 to 1000 is {mainThreadResult}\n");
//        }

//        private static void Task2()
//        {
//            Console.ForegroundColor = ConsoleColor.Red;
//            /*2. ���������� ������ ������� ���� �� ������ � ������� ������
//            CancellationToken � �������� ������.*/
//            var cancellationToken = new CancellationTokenSource();

//            Task second = Task.Factory.StartNew(CountQuantityOfSimpleNumbersWithCancellingToken, cancellationToken.Token, cancellationToken.Token);
//            try
//            {
//                cancellationToken.Cancel();
//                second.Wait();
//            }
//            catch (AggregateException e)
//            {
//                if (second.IsCanceled)
//                    Console.WriteLine($"{second.Id} task is canceled\n");
//            }
//        }

//        private static void Task3()
//        {
//            Console.ForegroundColor = ConsoleColor.Blue;
//            /*3. �������� ��� ������ � ��������� ���������� � ����������� �� ���
//               ���������� ��������� ������. ��������, ������ �� �������.*/
//            var hundreds = new Task<int>(() => new Random().Next(1, 9) * 100);
//            var dozens = new Task<int>(() => new Random().Next(0, 9) * 10);
//            var units = new Task<int>(() => new Random().Next(0, 9));

//            hundreds.Start();
//            dozens.Start();
//            units.Start();
//            units.Wait();
//            hundreds.Wait();
//            dozens.Wait();

//            var threeDigitNumber = new Task<int>(() => hundreds.Result + dozens.Result + units.Result);
//            threeDigitNumber.Start();
//            Console.WriteLine($"A three-digit number has been created - {threeDigitNumber.Result}\n");
//        }

//        private static void Task4()
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            /*4. �������� ������ ����������� (continuation task) � ���� ���������:
//            1) C ContinueWith - ���������� �� ������ ���������� ���������
//            �������������� �����
//            2) �� ������ ������� �������� � ������� GetAwaiter(),GetResult();*/


//            var sum = new Task<int>(() => 1 + 10 + 100);
//            var showSum = sum.ContinueWith(s => Console.WriteLine(sum.Result));
//            sum.Start();


//            //TODO ���� �������� ���,�� � �� ����,��� ������ ��� ������ ��������
//            var difference = new Task<int>(() => 111 - 100 - 10 - 1);
//            var awaiterCountFor = difference.GetAwaiter();
//            awaiterCountFor.OnCompleted(() =>
//            {
//                awaiterCountFor.GetResult();
//                Console.WriteLine($"Result is {difference.Result}\n");
//            });
//            difference.Start();
//            difference.Wait();

//        }

//        private static void Task5()
//        {
//            /*5. ��������� ����� Parallel �������������� ���������� ������ For(),
//          ForEach(). ��������,�� �����:  ��������� (��������������) ������������������,
//          ��������� ���������� �������� �� 1000000 ���������, ������� ����������
//          ������������������, ��������� �������  (��������, ������). 
//          ������� ������������������ �� ��������� � �������� �������*/


//            //TODO ������� �� ������� ��������,���� ���������,��� � ForEach ������
//            var array1 = new int[10000000];
//            var array2 = new int[10000000];
//            var array3 = new int[10000000];

//            var stopwatch = new Stopwatch();

//            stopwatch.Start();
//            Parallel.For(0, 10000000, CreatingArrayElements);
//            stopwatch.Stop();
//            Console.WriteLine($"Parallel For {stopwatch.ElapsedMilliseconds} ms");

//            stopwatch.Restart();
//            for (var i = 0; i < 10000000; i++)
//            {
//                array1[i] = 1;
//                array2[i] = 1;
//                array3[i] = 1;
//            }

//            stopwatch.Stop();
//            Console.WriteLine($"Native For {stopwatch.ElapsedMilliseconds} ms");


//            int sum = 0;
//            stopwatch.Restart();
//            Parallel.ForEach(array1, SumOfElements);
//            stopwatch.Stop();
//            Console.WriteLine($"Parallel ForEach {stopwatch.ElapsedMilliseconds} ms");

//            sum = 0;
//            stopwatch.Restart();
//            foreach (int item in array1) sum += item;
//            stopwatch.Stop();
//            Console.WriteLine($"Native ForEach {stopwatch.ElapsedMilliseconds} ms");

//            void CreatingArrayElements(int x)
//            {
//                array1[x] = 1;
//                array2[x] = 1;
//                array3[x] = 1;
//            }

//            void SumOfElements(int item)
//            {
//                sum += item;
//            }


//        }

//        private static void Task6()
//        {
//            /*6. ��������� Parallel.Invoke() �������������� ���������� �����
//            ����������.*/
//            var array1 = new int[10000000];
//            var array2 = new int[10000000];
//            var array3 = new int[10000000];


//            Parallel.Invoke
//            (

//                () =>
//                {
//                    for (var i = 0; i < array1.Length; i++)
//                    {
//                        array1[i] = i;
//                    }
//                },
//                () =>
//                {
//                    for (var i = 0; i < array2.Length; i++)
//                    {
//                        array2[i] = i;
//                    }
//                },
//                () =>
//                {
//                    for (var i = 0; i < array3.Length; i++)
//                    {
//                        array3[i] = i;
//                    }
//                }
//            );
//        }

//private static void Task7()
//{
//    /*���� 5 ����������� ������� �������, ��� ������� ���������� ������
//    �� ����� (������ �� ������) � 10 ����������� � �������� ��� ������,
//    ���� ������ ��� - ������. � ����� ������: c���� ���������
//    �����������. ���������� ����� ������. � ������� ���������� ����
//    �������� ������ ������. ������ ��� ��� ��������� ��������� ������
//    �������� ������������ ������� �� ������.*/

//    //TODO ���� � ���� ���� �����������
//    BlockingCollection<string> bc = new BlockingCollection<string>(5);

//    Task[] sellers = new Task[10]
//    {
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("����");
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("����");
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("�������");
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("���");
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("����������");
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("�������������");
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("�������");
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("�����");
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("�����");
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(700);
//                        bc.Add("����");
//                    }
//                })
//    };

//    Task[] consumers = new Task[5]
//    {
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(300);
//                        bc.Take();
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(500);
//                        bc.Take();
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(500);
//                        bc.Take();
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(400);
//                        bc.Take();
//                    }
//                }),
//                new Task(() =>
//                {
//                    while (true)
//                    {
//                        Thread.Sleep(250);
//                        bc.Take();
//                    }
//                })
//    };

//    foreach (var i in sellers)
//        if (i.Status != TaskStatus.Running)
//            i.Start();

//    foreach (var i in consumers)
//        if (i.Status != TaskStatus.Running)
//            i.Start();

//    int count = 1;
//    while (true)
//    {
//        if (bc.Count != count && bc.Count != 0)
//        {
//            count = bc.Count;
//            Thread.Sleep(500);
//            Console.Clear();
//            Console.WriteLine("---�����---");

//            foreach (var i in bc)
//                Console.WriteLine(i);
//        }
//    }

//        }

//        private static void Task8()
//        {
//            /*8. ��������� async � await ����������� ����������� ���������� ������
//            ������.*/
//            void Factorial()
//            {
//                int result = 1;
//                for (int i = 1; i <= 6; i++)
//                    result *= i;
//                Thread.Sleep(1000);
//                Console.WriteLine($"6! = {result}");
//            }

//            async void FactorialAsync()
//            {
//                Console.WriteLine("FA start");
//                await Task.Run(() => Factorial());
//                Console.WriteLine("FA ends");
//            }

//            FactorialAsync();
//            Console.ReadKey();
//        }

//        private static uint CountQuantityOfSimpleNumbers(uint enumerationBorder)
//        {
//            var numbers = new List<uint>();
//            for (var i = 2u; i < enumerationBorder; i++) numbers.Add(i);

//            for (var i = 0; i < numbers.Count; i++)
//                for (var j = 2u; j < enumerationBorder; j++)
//                    numbers.Remove(numbers[i] * j);

//            return (uint)numbers.Count;
//        }

//        private static uint CountQuantityOfSimpleNumbersWithCancellingToken(object obj)
//        {
//            var numbers = new List<uint>();
//            var token = (CancellationToken)obj;
//            for (var i = 2u; i < 1000; i++) numbers.Add(i);

//            for (var i = 0; i < numbers.Count; i++)
//            {
//                if (token.IsCancellationRequested)
//                {
//                    Console.WriteLine("Cancellation Request");
//                    token.ThrowIfCancellationRequested();
//                    return 0;
//                }

//                for (var j = 2u; j < 1000; j++) numbers.Remove(numbers[i] * j);
//            }

//            return (uint)numbers.Count;
//        }

//        //TODO 7 � 8 ������� �� �������,��������� ����� �����
//    }
//}