using System;
using Lab_6performance;


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
            

            try
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

                MySet<int>[] temp = new MySet<int>[2];

                for (int i = 0; i < temp.Length; i++)
                {
                    temp[i] = new MySet<int>();
                }

                temp[0].Push_Back(1);

                /////////////////////////////////////////////////////

                Console.WriteLine(a > b);
                Console.WriteLine(a < b);

                MySet<int> c = a * b;

                /////////////////////////////////////////////////////
                ///

                //b.Delete(10);

                //MySet<Lab_6performance.Program.News> d = new MySet<Lab_6performance.Program.News>();
                MySet<Lab_6performance.Program.News> d = new MySet<Lab_6performance.Program.News>();
                d.Push_Back(new Program.News(10));
                d.Push_Back(new Program.News(11));
                d.Push_Back(new Program.News(12));


                MySet<Lab_6performance.Program.News> e = new MySet<Lab_6performance.Program.News>();
                e.Push_Back(new Program.News(10));
                e.Push_Back(new Program.News(11));
                e.Push_Back(new Program.News(12));
                e.Push_Back(new Program.News(13));


                Console.WriteLine(d > e);
                Console.WriteLine(d < e);

                MySet<Lab_6performance.Program.News> c2 = d * e;

                ////////////////////////////Работа с файлами///////////////////////////////
                ///

               

            }
            catch (Exception exeption)
            {
                Console.WriteLine(exeption);
            }
            finally
            {
                Console.WriteLine("Вызвался finally!!!");
            }
      
            Console.ReadKey();
        }
    }
}