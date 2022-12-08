using System.Collections;
using System.Collections.Generic;

namespace Kontrosha
{
    internal class Program
    {
        class SuperHashSet<T> where T : MyClass
        {
            public static HashSet<T> hs = new HashSet<T>();

            public static void Add(T val)
            {
                hs.Add(val);
            }

            public static void Print()
            {
                foreach (T val in hs)
                {
                    Console.WriteLine(val);
                }
            }
        }

        class MyClass
        {
            public MyClass(string name, int age)
            {
                this.name = name;
                this.age = age;
            }

            public new void ToString()
            {
                Console.WriteLine($"Name: {this.name}, Age: {this.age}");
            }

            public string name;
            public int age;
        }

        static void Main(string[] args)
        {
            SuperHashSet<MyClass>.Add(new MyClass("Nikita", 30));
            SuperHashSet<MyClass>.Add(new MyClass("Artem", 10));
            SuperHashSet<MyClass>.Add(new MyClass("Ilya", 10));

            var sameAge = SuperHashSet<MyClass>.hs.Where(e => e.age == 10);



            foreach (var val in sameAge)
            {
                val.ToString();
            }

            ////////////////////////////////////////////////
            ///

            User user = new User("Nikita", 10);

            Button first_button = new Button("First_Button");
            Button second_button = new Button("Second_Button");

            user.TurnOn += first_button.Ipressed;
            user.TurnOn += second_button.Ipressed;

            user.Press(); 
        }

        class User
    {
        public delegate void StateHandler();
        public event StateHandler? TurnOn;

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public void Press()
        {
            Console.WriteLine("Пользователь нажал на копку!");

            TurnOn?.Invoke();
        }

        string Name;
        int Age;



    }
    class Button
    {
        public Button(string name)
        {
            this.name = name;
        }

        public void Ipressed() { Console.WriteLine($"Кнопка {this.name} нажата!"); }

        public string name;
    }

    }
}