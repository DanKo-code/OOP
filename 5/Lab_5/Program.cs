//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Lab_4
//{

//    //    /////////////////////////////////// class/struct ///////////////////////////////////////////////

//    //class ClassPoint
//    //{
//    //    public ClassPoint(int x, int y)
//    //    {
//    //        this.x = x;
//    //        this.y = y;
//    //    }

//    //    public int x;
//    //    public int y;
//    //}

//    //struct StructPoint
//    //{
//    //    public StructPoint(int x, int y)
//    //    {
//    //        this.x = x;
//    //        this.y = y;
//    //    }

//    //    public int x;
//    //    public int y;
//    //}



//    //class Program
//    //{
//    //    static void Bar(StructPoint stru)
//    //    {
//    //        stru.x++;
//    //        stru.y++;
//    //    }

//    //    static void Foo(ClassPoint clas)
//    //    {
//    //        clas.x++;
//    //        clas.y++;
//    //    }

//    //    static void Main()
//    //    {
//    //        StructPoint struc = new StructPoint(1, 2);
//    //        ClassPoint clas = new ClassPoint(1, 2);

//    //        Bar(struc);
//    //        Foo(clas);
//    //    }

//    //}    //class ClassPoint
//    //{
//    //    public ClassPoint(int x, int y)
//    //    {
//    //        this.x = x;
//    //        this.y = y;
//    //    }

//    //    public int x;
//    //    public int y;
//    //}

//    //struct StructPoint
//    //{
//    //    public StructPoint(int x, int y)
//    //    {
//    //        this.x = x;
//    //        this.y = y;
//    //    }

//    //    public int x;
//    //    public int y;
//    //}



//    //class Program
//    //{
//    //    static void Bar(StructPoint stru)
//    //    {
//    //        stru.x++;
//    //        stru.y++;
//    //    }

//    //    static void Foo(ClassPoint clas)
//    //    {
//    //        clas.x++;
//    //        clas.y++;
//    //    }

//    //    static void Main()
//    //    {
//    //        StructPoint struc = new StructPoint(1, 2);
//    //        ClassPoint clas = new ClassPoint(1, 2);

//    //        Bar(struc);
//    //        Foo(clas);
//    //    }

//    //}

//    //    /////////////////////////////////// class/struct ///////////////////////////////////////////////



//    //    /////////////////////////////////// явная реализация интерфейса ///////////////////////////////////////////////

//    //interface First
//    //{
//    //    void Action();
//    //}

//    //interface Second
//    //{
//    //    void Action();
//    //}

//    //class MyClass : First, Second
//    //{
//    //    public void Action()
//    //    {
//    //        Console.WriteLine("MyClass Action...");
//    //    }
//    //}

//    //class MyOtherClass : First, Second
//    //{
//    //    void First.Action()
//    //    {
//    //        Console.WriteLine("MyClass First.Action...");
//    //    }

//    //    void Second.Action()
//    //    {
//    //        Console.WriteLine("MyClass Second.Action...");
//    //    }
//    //}

//class Program
//{
//    static void Main()
//    {
//        MyClass myClass = new MyClass();
//        Foo(myClass);
//        Bar(myClass);

//        MyOtherClass myOtherClass = new MyOtherClass();
//        Foo(myOtherClass);
//        Bar(myOtherClass);

//        First a = myOtherClass;
//        a.Action();

//        ((First)myOtherClass).Action();

//        object obj = new object();
//        if (obj is First first)
//        {
//            first.Action();
//        }



//    }

//    static void Foo(First first)
//    {
//        first.Action();
//    }

//    static void Bar(Second second)
//    {
//        second.Action();
//    }
//}

//    //    /////////////////////////////////// явная реализация интерфейса ///////////////////////////////////////////////


//    //    /////////////////////////////////// abstract ///////////////////////////////////////////////

//    abstract class Weapon
//    {
//        public abstract int Damage { get; }

//        public abstract void Fire();

//    }

//    class Gun : Weapon
//    {
//        public override int Damage { get { return 5; } }

//        public override void Fire()
//        {
//            Console.WriteLine("BAM!!!");
//        }
//    }

//    class AK_47 : Weapon
//    {
//        public override int Damage => 20;

//        public override void Fire()
//        {
//            Console.WriteLine("TRA-TA-TA-TA-T-A!!!");
//        }
//    }

//    class Player
//    {
//        public void Fire(Weapon weapon)
//        {
//            weapon.Fire();
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Player player = new Player();

//            Weapon[] inventory = { new Gun(), new AK_47() };

//            foreach (var items in inventory)
//            {

//                player.Fire(items);
//            }
//        }
//    }

//    //    /////////////////////////////////// abstract ///////////////////////////////////////////////


//    class Program
//    {
//        ///////////////////////////////// polimorfism ///////////////////////////////////////////////
//        class Car
//        {
//            protected virtual void StartEngine()
//            {
//                Console.WriteLine("Двигатель запущен!");
//            }


//            public virtual void Drive()
//            {
//                StartEngine();
//                Console.WriteLine("я машина, я еду");
//            }
//        }

//        class SportCar : Car
//        {
//            protected override void StartEngine()
//            {
//                Console.WriteLine("рон дон дон");
//            }

//            public override void Drive()
//            {
//                StartEngine();

//                Console.WriteLine("я спорткар, я еду быстро");
//            }
//        }

//        class Person
//        {
//            public void Drive(Car car)
//            {

//                car.Drive();
//            }
//        }

//        static void Main()
//        {
//            Person person = new Person();
//            person.Drive(new SportCar());
//        }
//    }
//    /////////////////////////////////// polimorfism ///////////////////////////////////////////////


//    //    /////////////////////////////////// IS AS ///////////////////////////////////////////////

//class Program
//{
//    class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }

//        public void Print()
//        {
//            Console.WriteLine("X:\t" + X);
//            Console.WriteLine("Y:\t" + Y);
//        }
//    }


//    static void Main(string[] args)
//    {
//        object obj = new Point { X = 3, Y = 5 };

//        Bar(obj);

//    }

//    static void Foo(object obj)
//    {
//        Point point = obj as Point;

//        if (point != null)
//        {
//            point.Print();
//        }
//    }

//    static void Bar(object obj)
//    {
//        if (obj is Point point)
//        {
//            //Point point = (Point)obj;

//            point.Print();
//        }
//    }
//}


//    //    /////////////////////////////////// IS AS ///////////////////////////////////////////////

//    //    /////////////////////////////////// BASE ///////////////////////////////////////////////

//class Programm
//{
//    class Point2D
//    {
//        public Point2D(int x, int y)
//        {
//            X = x;
//            Y = y;

//            Console.WriteLine("конструктор Point2D");
//        }

//        public int X { get; set; }
//        public int Y { get; set; }
//    }

//    class Point3D : Point2D
//    {
//        public Point3D(int x, int y, int z) : base(x, y)
//        {
//            Z = z;
//            Console.WriteLine("конструктор Point3D");
//        }



//        public int Z { get; set; }
//    }

//    static void Main()
//    {
//        Point3D point3D = new Point3D(1, 2, 3);
//    }
//}



//    //    /////////////////////////////////// BASE ///////////////////////////////////////////////



//    //}
//}
