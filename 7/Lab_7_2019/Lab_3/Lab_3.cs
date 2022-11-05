using System;

namespace Lab_3
{
    public partial class Lab_3
    {
        interface MyGenericInterface<T>
        {
            void Push_Back(T item);
            void Delete(uint index);
            void View();  
        }


        public class MySet<T> : MyGenericInterface<T> where T : IEquatable<T>
        {
            public static MySet<T> operator *(MySet<T> first, MySet<T> second)
            {
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
                if (second > first) return true;

                return false;
            }

            //public void Add(T a)
            //{
            //    T[] buf = new T[items.Length + 1];
            //    items.CopyTo(buf, 0);
            //    buf[items.Length] = a;
            //    items = buf;
            //}

            public void Push_Back(T a)
            {
                T[] buf = new T[items.Length + 1];
                items.CopyTo(buf, 0);
                buf[items.Length] = a;
                items = buf;
            }

            public void Delete(uint index)
            {
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
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine(items[i].ToString());
                }
            }

            //для добавления
            public T[] items = Array.Empty<T>();
        }

        static void Main()
        {
            MySet<int> a = new MySet<int>();

            a.Push_Back(1);
            a.Push_Back(2);
            a.Push_Back(3);
            a.Push_Back(40);

            MySet<int> b = new MySet<int>();

            b.Push_Back(1);
            b.Push_Back(2);
            b.Push_Back(3);
            b.Push_Back(40);
            b.Push_Back(50);

            /////////////////////////////////////////////////////

            Console.WriteLine(a > b);
            Console.WriteLine(a < b);

            MySet<int> c = a * b;

            Console.ReadKey();
        }
    }
}