using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public partial class Program
    {
        public class Cartoon : TvProgram, Film
        {
            public override int Duration { get; set; }

            public override string Name => "Мультик";

            public override string Define => "Ура, начинается мультк!!!";

            public int releaseYear { get; set; }

            public override void PrintFragment()
            {
                Console.WriteLine("1 сезон, 2 серия, включаем!");
            }

            void Film.PrintFragment()
            {
                Console.WriteLine("Сэр, не хотите выдуть мыльный пузырь. Всего 25 центов!");
            }

            public string genre => "Anime";

            public override string ToString()
            {
                return $"Type: {this.GetType()}, Duration: {Duration}, Name: {Name}, Define: {Define}, Genre: {genre}, ReleaseYear: {releaseYear}";
            }
        }
    }
}
