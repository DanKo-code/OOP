using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public partial class Program
    {
        abstract public class TvProgram
        {
            public abstract int Duration { get; set; }

            public virtual string Name { get; }

            public abstract void PrintFragment();

            ////////////////////////////////////////////
            ///
            public abstract string Define { get; }

            public enum HostFees
            {
                Nikita = 100,
                Danila,
                Artem
            }

            public struct Print
            {
                public void Foo(object obj)
                {
                    if (obj is TvProgram test)
                    {
                        test.PrintFragment();
                    }
                }
            }
            

        }
    }
}
