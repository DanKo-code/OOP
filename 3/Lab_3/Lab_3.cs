using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
     public partial class Lab_3
    {
        public class MySet
        {
            public class Developer
            {
                public Developer(string fullName, string Department)
                {
                    this.fullName = fullName;
                    this.id = this.GetHashCode();
                    this.Department = Department;
                }

                string fullName;
                int id;
                string Department;
            }

            Production Prod = new Production("Danila");

            public static explicit operator Date(MySet first)
            {
                Date temp = new Date();

                temp.buffer = first.items;

                return temp;
            }

            public static MySet operator *(MySet first, MySet second)
            {
                MySet temp = new MySet();

                for (int i = 0; i < first.items.Length; i++)
                {
                    for (int j = 0; j < second.items.Length; j++)
                    {
                        if (first.items[i] == second.items[j])
                        {
                            temp.Push_Back(first.items[i]);
                            break;
                        }
                    }
                }

                return temp;
            }

            public static bool operator >(MySet first, MySet second)
           {
                bool check = false;

                for (int i = 0; i < first.items.Length; i++)
                {
                    for (int j = 0; j < second.items.Length; j++)
                    {
                        if (first.items[i] == second.items[j])
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

            public static bool operator <(MySet first, MySet second)
            {
                if (second > first) return true;

                return false;
            }

            public void Push_Back(int a)
           {
                int[] buf = new int[items.Length + 1];
                items.CopyTo(buf, 0);
                buf[items.Length] = a;
                items = buf;
           }

            //для добавления
            public int[] items = Array.Empty<int>();
        }

        static void Main()
        {
            MySet a = new MySet();
            
            a.Push_Back(1);
            a.Push_Back(2);
            a.Push_Back(3);
            a.Push_Back(40);
           
            MySet b = new MySet();

            b.Push_Back(1);
            b.Push_Back(2);
            b.Push_Back(3);
            b.Push_Back(38);
            b.Push_Back(40);
            b.Push_Back(-5);
            b.Push_Back(-6);

            /////////////////////////////////////////////////////

            Console.WriteLine(a > b);
            Console.WriteLine(a < b);

            MySet c = a * b;

            

            var test = (Date)a;

            /////////////////////Инициализация Developer/////////////////////////////////

            MySet.Developer DeveloperDanila = new MySet.Developer("Danila Kozlyakovsi Aleksandrovich", "4 poit");

            /////////////////////Тестим StatisticOperation/////////////////////////////////

            Console.WriteLine(StatisticOperation.GetSumFirstLastElement(b));

            Console.WriteLine(StatisticOperation.GetDifferenceFirstLastElement(b));

            Console.WriteLine(StatisticOperation.GetAlementsAmount(b));

            string str = "nikita 186";

            char firstElement = str.GetFirstElement();

            b.DeletePositiveElements();

            Console.ReadKey();
        }
    }
}