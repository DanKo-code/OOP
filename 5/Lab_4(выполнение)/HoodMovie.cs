using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public partial class Program
    {
        public class HoodMovie : TvProgram, Film
        {
            public override int Duration { get; set; }

            public override string Name => "Фильмец";

            public override string Define => "Начинается какой-то фильм";

            public int releaseYear { get; set; }

            public override void PrintFragment()
            {
                Console.WriteLine(" Трансформеры, включаем!");
            }

            void Film.PrintFragment()
            {
                Console.WriteLine("Ура, Трансформеры начинается!!!");
            }

            public string genre => "thriller";

            public override string ToString()
            {
                return $"Type: {this.GetType()}, Duration: {Duration}, Name: {Name}, Define: {Define}, Genre: {genre}";
            }
        }
    }
}
