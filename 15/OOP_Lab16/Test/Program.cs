namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task task = new Task(() =>
            //{
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Nikita gay");
            //});

            Task task = Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine("Nikita gay");
            });


            //task.Start();

            Console.WriteLine("Hello, World!");
        }
    }
}