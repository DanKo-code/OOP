using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public partial class Program
    {
        public interface Film
        {
            string genre { get; }

            int releaseYear { get; set; }

            void PrintFragment();
        }
    }
}
