using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(short.MaxValue);

            int[] arr = { 1, 2, 3 };

            string res = string.Join(",",arr);

            Console.ReadKey();
        }
    }
}
