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
        }
    }
}
