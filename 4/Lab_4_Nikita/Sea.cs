using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4_Nikita
{
    public partial class Perfomance
    {
        class Sea:Water
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

            public override string ToString()
            {
                return $"Type: {this.GetType()}, Duration: {Duration}, Name: {Name}, Define: {Define}";
            }

            public override int GetHashCode()
            {
                return (int)(this.Duration - 456 * 10 / 20 + 9786 - 3);
            }

            private int id;

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (obj.GetType() != this.GetType()) return false;
                News test_equals = (News)obj;
                return ((this.Duration == test_equals.Duration) &&
                        (this.Define == test_equals.Define) &&
                        (this.Name == test_equals.Name) &&
                        (this.id == test_equals.id));
            }
        }
    }
}
