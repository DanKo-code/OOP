using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prikol
{
    class Program
    {
        class A
        {
            int i = 1;
            public int I { get => ++i; }
        }


        static void Main(string[] args)
        {
            A a = new A();

            Console.WriteLine(a.I);
        }
    }
}
