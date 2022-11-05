using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST
{
    class Program
    {
        public class Car
        {
            public int WheelSize { get; set; }
            public string ColorName { get; set; }
            public int DoorsCount { get; set; }
            public bool IsBroken { get; set; }

            public override string ToString()
            {
                return string.Format("Car: {0}, {1}, {2}", ColorName, WheelSize.ToString(), IsBroken.ToString());
            }
        }

        private static List<Car> CreateGarage()
        {
            List<Car> cars = new List<Car>()
    {
        new Car(){ ColorName="Синий", DoorsCount=4, IsBroken=false, WheelSize=15},
        new Car(){ ColorName="Мокрый асфальт", DoorsCount=4, IsBroken=true, WheelSize=18},
        new Car(){ ColorName="Бежевый", DoorsCount=3, IsBroken=false, WheelSize=22},
        new Car(){ ColorName="Красный", DoorsCount=4, IsBroken=true, WheelSize=22},
        new Car(){ ColorName="Бежевый", DoorsCount=3, IsBroken=false, WheelSize=17},
        new Car(){ ColorName="Красный", DoorsCount=4, IsBroken=false, WheelSize=19},
    };
            return cars;
        }

        private static List<Car> GetBrokenCars(List<Car> garage)
        {
            List<Car> founded = new List<Car>();
            foreach (Car item in garage)
            {
                if (item.IsBroken)
                {
                    founded.Add(item);
                }
            }
            return founded;
        }

        private static bool FoundCar(Car car)
        {
            if (car.IsBroken)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            List<Car> Garage = CreateGarage();
            Console.WriteLine("-------- 1 способ -------------");
            foreach (Car item in GetBrokenCars(Garage))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("-------- 2 способ --------------");
            foreach (Car item in Garage.FindAll(FoundCar))
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("--------------------------------");
        }
    }
}
