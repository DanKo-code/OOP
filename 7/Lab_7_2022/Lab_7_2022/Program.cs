using System.Reflection.Emit;
using System.Text.Json;
using Lab_3;
using static Lab_3.Lab_3;
using Lab_6performance;
using System.IO;
using System.Numerics;

namespace Lab_7_2022
{
    class Program
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

                for (int j = 0; j < dwordLine.Length-1; j++)
                {
                    temp[i].Push_Back((T)Convert.ChangeType(dwordLine[j], typeof(T)));
                }
            }

            return temp;
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


            MySet<Lab_6performance.Program.News> d = new MySet<Lab_6performance.Program.News>();
            d.Push_Back(new Lab_6performance.Program.News(10));
            d.Push_Back(new Lab_6performance.Program.News(11));
            d.Push_Back(new Lab_6performance.Program.News(12));

            SerializeMySet<string>(a,b);

            var res = DeSerializeMySet<string>("SerializeMySet.txt");
        }
    }
}