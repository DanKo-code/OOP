using System;
using System.IO;



//using Lab_6performance;


//namespace Lab_3
//{
//    public partial class Lab_3
//    {
//        interface MyGenericInterface<T>
//        {
//            void Push_Back(T item);
//            void Delete(uint index);
//            void View();  
//        }


//        public class MySet<T> : MyGenericInterface<T> //where T : class
//        {
//            public static MySet<T> operator *(MySet<T> first, MySet<T> second)
//            {
//                //if ((first.GetType()).IsEquivalentTo(second.GetType()))
//                //    throw new Exception("Нельзя выполнить выделения подмножества с параметрами разного типа");

//                MySet<T> temp = new MySet<T>();

//                for (int i = 0; i < first.items.Length; i++)
//                {
//                    for (int j = 0; j < second.items.Length; j++)
//                    {
//                        //if (first.items[i] == second.items[j])
//                        if (!first.items[i].Equals(second.items[j]))
//                        {
//                            temp.Push_Back(first.items[i]);
//                            break;
//                        }
//                    }
//                }

//                return temp;
//            }

//            public static bool operator >(MySet<T> first, MySet<T> second)
//            {
//                //if ((first.GetType()).IsEquivalentTo(second.GetType()))
//                //    throw new Exception("Нельзя выполнить проверку на подмножества с параметрами разного типа");

//                bool check = false;

//                for (int i = 0; i < first.items.Length; i++)
//                {
//                    for (int j = 0; j < second.items.Length; j++)
//                    {
//                        if (first.items[i].Equals(second.items[j]))
//                        {
//                            check = true;
//                            break;
//                        }
//                    }

//                    if (!check) return false;

//                    check = false;
//                }

//                return true;
//            }

//            public static bool operator <(MySet<T> first, MySet<T> second)
//            {
//                //if ((first.GetType()).IsEquivalentTo(second.GetType()))
//                //    throw new Exception("Нельзя выполнить проверку на подмножества с параметрами разного типа");

//                if (second > first) return true;

//                return false;
//            }

//            public void Push_Back(T a)
//            {
//                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//                if (a == null) throw new TestNullObject("Передан обьект с null ссылкой!");

//                T[] buf = new T[items.Length + 1];
//                items.CopyTo(buf, 0);
//                buf[items.Length] = a;
//                items = buf;
//            }

//            public void Delete(uint index)
//            {
//                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//                if (items.Length == 0) throw new NullCollectionException("ProgramGuide пуст!");

//                // исключение - индекс не в диапазоне [0 - items.Length]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//                if (index < 0 || index > items.Length - 1) throw new WrongIndexException("Неверный индекс элемента");

//                T[] buf = new T[items.Length - 1];

//                for (int i = 0, j = 0; i < items.Length; i++, j++)
//                {
//                    if (i == index)
//                    {
//                        --j;
//                        continue;
//                    }


//                    buf[j] = items[i];
//                }

//                items = buf;
//            }

//            public void View()
//            {
//                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
//                if (items.Length == 0) throw new NullCollectionException("ProgramGuide пуст!");

//                for (int i = 0; i < items.Length; i++)
//                {
//                    Console.WriteLine(items[i].ToString());
//                }
//            }

//            ////////////////////////////////////////////////////////////////////////

//            //public MySet(T[] example){}
                

//            //для добавления
//            public T[] items = Array.Empty<T>();
//        }

//        static void Main()
//        {
            

//            try
//            {
//                MySet<int> a = new MySet<int>();

//                a.Push_Back(1);
//                a.Push_Back(2);
//                a.Push_Back(3);
//                a.Push_Back(40);

//                MySet<int> b = new MySet<int>();

//                b.Push_Back(1);
//                b.Push_Back(2);
//                b.Push_Back(3);
//                b.Push_Back(40);
//                b.Push_Back(50);

//                MySet<int>[] temp = new MySet<int>[2];

//                for (int i = 0; i < temp.Length; i++)
//                {
//                    temp[i] = new MySet<int>();
//                }

//                temp[0].Push_Back(1);

//                /////////////////////////////////////////////////////

//                Console.WriteLine(a > b);
//                Console.WriteLine(a < b);

//                MySet<int> c = a * b;

//                /////////////////////////////////////////////////////
//                ///

//                //b.Delete(10);

//                //MySet<News> d = new MySet<News>();
//                MySet<News> d = new MySet<News>();
//                d.Push_Back(new News(10));
//                d.Push_Back(new News(11));
//                d.Push_Back(new News(12));


//                MySet<News> e = new MySet<News>();
//                e.Push_Back(new News(10));
//                e.Push_Back(new News(11));
//                e.Push_Back(new News(12));
//                e.Push_Back(new News(13));


//                Console.WriteLine(d > e);
//                Console.WriteLine(d < e);

//                MySet<News> c2 = d * e;

//                ////////////////////////////Работа с файлами///////////////////////////////
//                ///

               

//            }
//            catch (Exception exeption)
//            {
//                Console.WriteLine(exeption);
//            }
//            finally
//            {
//                Console.WriteLine("Вызвался finally!!!");
//            }
      
//            Console.ReadKey();
//        }
//    }
//}

//using System;
//using Lab_6performance;


namespace Lab_3
{
    public partial class Lab_3
    {
        static void SerializeMySet<T>(params MySet<T>[] example)
        {
            StreamWriter writer = new StreamWriter("SerializeMySet.txt", false);

            for (int i = 0; i < example.Length; i++)
            {
                for (int j = 0; j < example[i].items.Length; j++)
                {
                    writer.Write(example[i].items[j] + " ");
                }

                writer.Write("\n");
            }

            writer.Close();
        }

        static MySet<T>[] DeSerializeMySet<T>(string patch)
        {
            string[] textFile = System.IO.File.ReadAllLines(patch);

            MySet<T>[] temp = new MySet<T>[textFile.Length];

            for (int i = 0; i < temp.Length; i++) temp[i] = new MySet<T>();

            for (int i = 0; i < textFile.Length; i++)
            {
                string[] dwordLine = textFile[i].Split(' ');

                for (int j = 0; j < dwordLine.Length - 1; j++)
                {
                    temp[i].Push_Back((T)Convert.ChangeType(dwordLine[j], typeof(T)));
                }
            }

            return temp;
        }


        interface MyGenericInterface<T>
        {
            void Push_Back(T item);
            void Delete(uint index);
            void View();
        }

       

        public class MySet<T> : MyGenericInterface<T> //where T : class
        {
            public static MySet<T> operator *(MySet<T> first, MySet<T> second)
            {
                //if ((first.GetType()).IsEquivalentTo(second.GetType()))
                //    throw new Exception("Нельзя выполнить выделения подмножества с параметрами разного типа");

                MySet<T> temp = new MySet<T>();

                for (int i = 0; i < first.items.Length; i++)
                {
                    for (int j = 0; j < second.items.Length; j++)
                    {
                        //if (first.items[i] == second.items[j])
                        if (!first.items[i].Equals(second.items[j]))
                        {
                            temp.Push_Back(first.items[i]);
                            break;
                        }
                    }
                }

                return temp;
            }

            public static bool operator >(MySet<T> first, MySet<T> second)
            {
                //if ((first.GetType()).IsEquivalentTo(second.GetType()))
                //    throw new Exception("Нельзя выполнить проверку на подмножества с параметрами разного типа");

                bool check = false;

                for (int i = 0; i < first.items.Length; i++)
                {
                    for (int j = 0; j < second.items.Length; j++)
                    {
                        if (first.items[i].Equals(second.items[j]))
                        {
                            check = true;
                            break;
                        }
                    }

                    if (!check) return false;

                    check = false;
                }

                return true;
            }

            public static bool operator <(MySet<T> first, MySet<T> second)
            {
                //if ((first.GetType()).IsEquivalentTo(second.GetType()))
                //    throw new Exception("Нельзя выполнить проверку на подмножества с параметрами разного типа");

                if (second > first) return true;

                return false;
            }

            public void Push_Back(T a)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (a == null) throw new TestNullObject("Передан обьект с null ссылкой!");

                T[] buf = new T[items.Length + 1];
                items.CopyTo(buf, 0);
                buf[items.Length] = a;
                items = buf;
            }

            public void Delete(uint index)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (items.Length == 0) throw new NullCollectionException("ProgramGuide пуст!");

                // исключение - индекс не в диапазоне [0 - items.Length]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (index < 0 || index > items.Length - 1) throw new WrongIndexException("Неверный индекс элемента");

                T[] buf = new T[items.Length - 1];

                for (int i = 0, j = 0; i < items.Length; i++, j++)
                {
                    if (i == index)
                    {
                        --j;
                        continue;
                    }


                    buf[j] = items[i];
                }

                items = buf;
            }

            public void View()
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (items.Length == 0) throw new NullCollectionException("ProgramGuide пуст!");

                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine(items[i].ToString());
                }
            }

            ////////////////////////////////////////////////////////////////////////

            //public MySet(T[] example){}


            //для добавления
            public T[] items = Array.Empty<T>();
        }

        static void Main()
        {


            



MySet<string> a = new MySet<string>();

a.Push_Back("1");
a.Push_Back("2");
a.Push_Back("3");
a.Push_Back("4");

//for (int i = 0; i < a.items.Length; i++)
//{
//    Console.WriteLine(a.items[i]);
//}

MySet<string> b = new MySet<string>();

b.Push_Back("nikita");
b.Push_Back("danila");
b.Push_Back("artem");
b.Push_Back("pasha");

//for (int i = 0; i < a.items.Length; i++)
//{
//    Console.WriteLine(a.items[i]);
//}


MySet<News> d = new MySet<News>();
d.Push_Back(new News(10));
d.Push_Back(new News(11));
d.Push_Back(new News(12));

SerializeMySet<string>(a, b);

var res = DeSerializeMySet<string>("SerializeMySet.txt");

Console.ReadKey();
        }



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


        public class Cartoon : TvProgram, Film
        {
            public override int Duration { get; set; }

            public override string Name => "Мультик";

            public override string Define => "Ура, начинается мультк!!!";

            public int releaseYear
            {
                get;
                set;
                //get
                //{
                //    return releaseYear;
                //}
                //set
                //{
                //    if(value <= 1800 && value <= 2022) trow
                //}
            }

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


        public class ProgramGuide
        {
            public void Delete(int index)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (items.Length == 0) throw new NullCollectionException("ProgramGuide пуст!");

                // исключение - индекс не в диапазоне [0 - items.Length]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (index < 0 || index > items.Length - 1) throw new WrongIndexException("Неверный индекс элемента");

                TvProgram[] buf = new TvProgram[items.Length - 1];

                for (int i = 0, j = 0; i < items.Length; i++, j++)
                {
                    if (i == index)
                    {
                        --j;
                        continue;
                    }


                    buf[j] = items[i];
                }

                items = buf;
            }

            public void Set(TvProgram newaItem, int index)
            {
                //Debug.Assert(newaItem != null, "Передаваемый объект не может указывать на null!");

                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (newaItem == null) throw new TestNullObject("Передан обьект с null ссылкой!");

                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (index < 0 || index > items.Length - 1) throw new WrongIndexException("Неверный индекс элемента!");

                items[index] = newaItem;
            }

            public TvProgram Get(int index)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (index < 0 || index > items.Length - 1) throw new WrongIndexException("Неверный индекс элемента!");
                return items[index];
            }

            public void Print()
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (items.Length == 0) throw new NullCollectionException("ProgramGuide пуст!");

                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine(items[i].ToString());
                }

            }

            public void Push_Back(TvProgram a)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (a == null) throw new TestNullObject("Передан обьект с null ссылкой!");

                TvProgram[] buf = new TvProgram[items.Length + 1];
                items.CopyTo(buf, 0);
                buf[items.Length] = a;
                items = buf;
            }

            public TvProgram[] items = Array.Empty<TvProgram>();
        }



        public interface Film
        {
            string genre { get; }

            int releaseYear { get; set; }

            void PrintFragment();
        }


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
                return $"Type: {this.GetType()}, Duration: {Duration}, Name: {Name}, Define: {Define}, Genre: {genre}, ReleaseYear: {releaseYear}";
            }
        }


        public class NullCollectionException : Exception
        {
            public NullCollectionException(string message) : base(message) { }
        }

        public class WrongIndexException : Exception
        {
            public WrongIndexException(string message) : base(message) { }
        }

        public class OutOfTvProgramRange : OverflowException
        {
            public OutOfTvProgramRange(string message) : base(message) { }
        }

        public class TestNullObject : NullReferenceException
        {
            public TestNullObject(string message) : base(message) { }
        }


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

        sealed public partial class News : TvProgram
        {
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

        abstract public class TvProgram
        {
            public abstract int Duration { get; set; }

            public virtual string Name { get; }

            public abstract void PrintFragment();

            ////////////////////////////////////////////
            ///
            public abstract string Define { get; }

            public enum HostFees
            {
                Nikita = 1000,
                Danila,
                Artem
            }

            public struct Print
            {
                public void Foo(object obj)
                {
                    if (obj is TvProgram test)
                    {
                        test.PrintFragment();
                    }
                }
            }


        }
    }

    public static class Controller
    {

        public static Lab_3.TvProgram[] GetSameYearFilms(this Lab_3.ProgramGuide temp, int year)
        {
            // исключение - год не в диапазоне [1800 - 2022]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (year <= 1800 || year >= 2022) throw new Lab_3.OutOfTvProgramRange("Выход за пределы года фильма!");


            Lab_3.TvProgram[] buf = Array.Empty<Lab_3.TvProgram>();


            for (int i = 0; i < temp.items.Length; i++)
            {
                if (temp.items[i] is Lab_3.Film test)
                {
                    if (test.releaseYear == year)
                    {
                        Lab_3.TvProgram[] buf2 = new Lab_3.TvProgram[buf.Length + 1];
                        buf.CopyTo(buf2, 0);
                        buf2[buf.Length] = temp.items[i];
                        buf = buf2;
                    }
                }
            }

            return buf;
        }

        public static int GetProgramTime(this Lab_3.ProgramGuide temp)
        {
            // исключение - если контэйнер пуст??????????????????!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if (temp.items.Length == 0) throw new Lab_3.NullCollectionException("ProgramGuide пуст!");

            int time = 0;

            for (int i = 0; i < temp.items.Length; i++)
            {
                time += temp.items[i].Duration;
            }

            return time;
        }

        public static int GetAdvertisingNumb(this Lab_3.ProgramGuide temp)
        {
            int advertisingNumb = 0;

            for (int i = 0; i < temp.items.Length; i++)
            {
                if (temp.items[i] is Lab_3.Advertising) ++advertisingNumb;
            }

            return advertisingNumb;
        }
    }

}



