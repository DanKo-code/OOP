using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime.Remoting;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("C:\\2курс, 1 сем\\ООП\\2\\Lab_2\\bin\\Release\\Lab_2.exe");

            Type type = asm.GetType("Lab_2.Lab_2.Phone");

            var members = type.GetMembers();

            foreach (var memberInfo in members)
            {
                Console.WriteLine(memberInfo.Name);
            }

            
        }
    }
}