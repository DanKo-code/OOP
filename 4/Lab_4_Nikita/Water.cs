using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Nikita
{
    public partial class Perfomance
    {
        abstract public class Water
        {
            public abstract int Square { get; set; }

            public abstract string Name { get; }

            public virtual void PrintFragment()
            {
                Console.WriteLine("Пару слов об классе");
            }

            public abstract string fauna { get; }
        }
        }
}
