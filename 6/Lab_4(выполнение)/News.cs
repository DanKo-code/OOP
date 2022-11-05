using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6performance
{
    public partial class Program
    {
        sealed public partial class News : TvProgram
        {
            public News(int duration)
            {
                this.Duration = duration;
                this.id = GetHashCode();
            }

            public override int Duration { get; set; }
            

            public override string Name => "Новости";

            public override void PrintFragment()
            {
                Console.WriteLine($"{this.Name}: В Украине закончилась война");
            }

            public override string Define => "Начинаются новости!!!";

            
        }
    }
}
