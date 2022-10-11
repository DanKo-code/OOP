using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public class Program
    {
        abstract class TvProgram
        {
            public abstract int Duration { get; }

            public abstract string Name { get;}

            public abstract void PrintFragment();

            ////////////////////////////////////////////
            ///
            public abstract string Define { get; }
        }

        public interface Film
        {
            string genre { get; }

            void PrintFragment();
        }

        sealed class News : TvProgram
        {
            public override int Duration => 20;

            public override string Name => "Новости";

            public override void PrintFragment()
            {
                Console.WriteLine($"{this.Name}: В Украине закончилась война");
            }

            public override string Define => "Начинаются новости!!!";
        }

        sealed class Advertising : TvProgram
        {
            public override int Duration => 1;

            public override string Name => "Реклама";

            public override void PrintFragment()
            {
                Console.WriteLine($"{this.Name}: Купите гель - он крутой");
            }

            public override string Define => "Начинаются новости!!!";
        }

        class Cartoon : TvProgram, Film
        {
            public override int Duration => 30;

            public override string Name => "Мультик";

            public override string Define => "Ура, начинается мультк!!!";

            public override void PrintFragment()
            {
                Console.WriteLine("1 сезон, 2 серия, включаем!");
            }

            void Film.PrintFragment()
            {
                Console.WriteLine("Ура, мультик начинается!!!");
            }

            public string genre => "Anime";
        }

        class Hoodmovie : TvProgram, Film
        {
            public override int Duration => 120;

            public override string Name => "Фильмец";

            public override string Define => "Начинается какой-то фильм";

            public override void PrintFragment()
            {
                Console.WriteLine(" \"название фильма\", включаем!");
            }

            void Film.PrintFragment()
            {
                Console.WriteLine("Ура, \"название фильма\" начинается!!!");
            }

            public string genre => "detective";
        }

        static void Main(string[] args)
        {
            Cartoon cartoon_1 = new Cartoon();
            cartoon_1.PrintFragment();

            ((Film)cartoon_1).PrintFragment();



            Console.ReadKey();
        }
    }
}
