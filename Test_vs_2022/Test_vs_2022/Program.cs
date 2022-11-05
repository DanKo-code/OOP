namespace Lab_4performance
{
    interface A
    {
        public void Print() 
        {
            Console.WriteLine("AAA");
        }
    }

    public partial class Program
    {
        public class B : A
        {
            public void Print()
            {
                Console.WriteLine("BBB");
            }
        }

        static void Main(string[] args)
        {
            B b = new B();

            ((A)b).Print();
            
        }
    }
}


