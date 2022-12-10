using System.Collections.Concurrent;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BlockingCollection<string> bc = new BlockingCollection<string>(5);

            Task sellers = new Task(() => 
            {
                while (true) 
                {
                    Thread.Sleep(500);

                    bc.Add("Телевизор");
                    bc.Add("Стол");
                    bc.Add("Никита");
                } 

            });

            

            Task consumers = new Task(() =>
            {
                 while(true)
                 {
                        Thread.Sleep(100);

                        Console.WriteLine(bc.Take());
                 }

            });

            sellers.Start();
            consumers.Start();

            Task.WaitAll(sellers, consumers);
        }



        
    }
}