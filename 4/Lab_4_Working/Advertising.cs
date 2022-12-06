using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public partial class Program
    {
        sealed public class Advertising : TvProgram
        {
            public override int Duration { get; set; }

            public override string Name => "Реклама";

            public override void PrintFragment()
            {
                Console.WriteLine($"{this.Name}: Купите гель - он крутой");
            }

            public override string Define => "Начинается реклама!!!";

            public override string ToString()
            {
                return $"Type: {this.GetType()}, Duration: {Duration}, Name: {Name}, Define: {Define}";
            }


        }
    }
}
