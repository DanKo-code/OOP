using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Nikita
{
    public partial class Perfomance
    {
        public interface Land
        {
            int population { get; }

            void PrintFragment();
        }
    }
}
