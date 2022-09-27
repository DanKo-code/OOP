using System;
using System.Text;


namespace OOP
{
   
    class Lab_1
    {
        static void Main(string[] args)
        {
            //Exercise 1///////////////////////////////////////////////////////////////////////////////////// 

#if Primitive_Types
            bool Bool = true;

            byte Byte = 255;
            sbyte SByte = 127;

            char Char = '\0';

            //decimal Decimal = 228.1337M;    // точность 28-29 знаков
            //double Double = 1.23;           // точность 15-17 знаков
            //float Float = 1.23f;            // точность 6-9 знаков

            decimal Decimal = ((decimal)1/3);    // точность 28-29 знаков
            double Double = ((double)1 / 3);           // точность 15-17 знаков
            float Float = ((float)1 / 3);

            short Int_16 = 1;
            ushort UInt_16 = 1;
            int Int_32 = 1;
            uint UInt_32 = 1;
            long Int_64 = -100L;
            ulong UInt_64 = 100UL;

            string str = "dfv";
            object obj = 1;
            

            Console.WriteLine("bool = {0}, byte = {1}, sbyte = {2}, char = {3}" +
                "\ndecimal = {4}, double = {5}, float = {6}, short = {7}" +
                "\nushort = {8},  int = {9}, uint = {10}, long = {11}, ulong = {12}, str = {13}, object = {14}",
               
                Bool, Byte, SByte, Char, Decimal,
                Double, Float, Int_16, UInt_16, Int_32, UInt_32,
                 Int_64, UInt_64, str, obj);
#endif

#if Сonverting
            // неявное преобразование
            char Char = 'A';
            int Int = Char;

            long Long = 18;
            decimal Decimal = Long;

            short Short = 18;
            double Double = Short;

            float Float = Short;

            Long = Int;

            // явное преобрпзование
            int a = 45;
            int b = 255;
            byte Byte = (byte)(a + b);

            Int = (int)Double;

            Int = -1;
            uint UInt = (uint)Int;

            Decimal = (decimal)Double;

            Char = (char)Int;

            // Работа с Convert


            Double = Convert.ToDouble(Float);

            Float = Convert.ToSingle(Double);

            float FloatParse = float.Parse("12,24");
#endif

#if Boxing_Unboxing
            // boxing unboxing
            int a = 1;
            object b = a;
            int c = (int)b;
#endif

#if Var
            var a = 5;
            var b = "Nikita";
            var c = new[] { 0, 1, 2 };
#endif

#if Nullable
            int? val = null;
            Nullable<int> val2 = null;
            Console.WriteLine($"{val}{val2}");
#endif

#if Var_2
            //var IntVal = 1;
            //IntVal = 3.4f; присвоение переменной типа int значения типа float невозможно из-за статической типизации языка
            //компилятор лишь выбирает наиболее подходящий тип в момент инициализации
#endif

            //Exercise 2///////////////////////////////////////////////////////////////////////////////////////////////////

#if Compare_Initialization_STR
            string str1 = "A";
            string str2 = "a";

            int result = string.Compare(str1, str2); //сравнение по алфавиту
            if (result < 0)
            {
                Console.WriteLine("Строка greeting перед строкой world");
            }
            else if (result > 0)
            {
                Console.WriteLine("Строка greeting стоит после строки world");
            }
            else
            {
                Console.WriteLine("Строки greeting и world идентичны, либо их length == 0");
            }
#endif

#if Converting_STR
            string str1 = "Nikita";
            string str2 = "is";
            string str3 = "groot";

            string result = str1 + str2 + str3; // Сцепление
            result = "Nikita";                  // Копирование
            result = str1.Substring(0, 3);      // Выделение подстроки

            result = "Nikita is groot";         // Разделение строки
            string[] str_arr = result.Split(/*'a'*/);

            foreach (string sub in str_arr)
            {
                Console.WriteLine($"Substring: {sub}");
            }

            result = "Nikitaisgood";           // Вставка подстроки в заданную позицию
            result = result.Insert(6, " ");

            result = "Nikita is groot";        // Удаление подстроки
            int foundS1 = result.IndexOf(" ");
            int foundS2 = result.IndexOf(" ", foundS1 + 1);

            if (foundS1 != foundS2 && foundS1 >= 0)
            {
                result = result.Remove(foundS1 + 1, foundS2 - foundS1);

                Console.WriteLine(result);
            }

            result = "groot"; 
            result = $"Nikita is {result}";
#endif

#if Null_Void_STR
            string Empty = "";
            string Null = null;

            bool result = String.IsNullOrEmpty(Empty);
            result = String.IsNullOrEmpty(Null);

            result = String.IsNullOrWhiteSpace(Empty);


            if (String.IsNullOrEmpty(Empty) && String.IsNullOrEmpty(Null))
            {
                Console.WriteLine("\nОбе строки равны null или пустые!");
            }
            else
            {
                Console.WriteLine("\nОбе строки не null и не пуст!");
            }
#endif

#if StringBuilder
            StringBuilder result = new StringBuilder(" is groot");
            result.Insert(0, "Nikita");
            result.Remove(10, 5);
            result.Append("debil");
#endif

            //Exercise 3///////////////////////////////////////////////////////////////////////////////////////////////////

#if Ex_3_a
            int[,] Matrix = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i, j] + " ");
                }
                Console.Write("\n\n");
            }
#endif

#if Ex_3_b
            string[] str_arr = { "one", "two", "three" };
            

           
                Console.Write("\nNumbers: ");
                foreach (string s in str_arr)
                {
                    Console.Write(s + " ");
                }

                Console.Write("\n\n"+ "Длинна массива = "  + str_arr.Length);

                Console.Write("\n\n Введите позицию: ");
                int position = Convert.ToInt32(Console.ReadLine());

                Console.Write("\n\n Введите строку: ");
                string str = Console.ReadLine();

                str_arr[position] = str;
#endif

#if Ex_3_c
            Random Rnd = new Random();
            int[][] SArray = new int[3][];
            SArray[0] = new int[2];
            SArray[1] = new int[3];
            SArray[2] = new int[4];

            for (int i = 0; i < SArray.Length; i++)
            {
                for (int j = 0; j < SArray[i].Length; j++)
                {
                    SArray[i][j] = j;
                    Console.Write(SArray[i][j] + " ");
                }
                Console.Write("\n\n");
            }

            var VarInt = new int[] { 1, 2, 3, 4, 5 };
            var VarStr = "Abcdefg";
#endif

            //Exercise 4///////////////////////////////////////////////////////////////////////////////////////////////////

#if Ex_4_a
            (int, string, char, string, ulong) Cortege = (18, "Данила", 'Д', "Козляковский", 2281337);

            Console.WriteLine(Cortege);

            Console.WriteLine("\n" + Cortege.Item1 + " " + Cortege.Item3 + " " + Cortege.Item4);

            (var a, var b) = (144, "156");
            (int c, string d) = (144, "156");

            var First = (a: 10, b: "20");
            var Second = (a: 10, b: "20");
            
            bool result = First != Second;

            var p = ("John", "Quincy", "Adams", "Boston");
            var (fName, _, city, _) = p;

#endif

            //Exercise 5///////////////////////////////////////////////////////////////////////////////////////////////////


#if Ex_5
            int Max(int[] arr)
            {
                int max = arr[0];

                for (int i = 1; i < arr.Length; i++)
                {
                    if (max < arr[i])
                    {
                        max = arr[i];
                    }
                }
   
                return max;
            }

            int Min(int[] arr)
            {
                int min = arr[0];

                for (int i = 1; i < arr.Length; i++)
                {
                    if (min > arr[i])
                    {
                        min = arr[i];
                    }
                }

                return min;
            }

            int Sum(int[] arr)
            {
                int sum=0;

                for (int i = 0; i < arr.Length; i++)
                {
                    sum += arr[i];
                }

                return sum;
            }

            dynamic FOO(int[] arr, string str)
            {
                return (Max(arr), Min(arr), Sum(arr), str[0]);
            }

            int[] arr_int = { 5, -70, 50 };
            string arr_str = "ABC";

            var T = FOO(arr_int, arr_str);

            

#endif

            //Exercise 6///////////////////////////////////////////////////////////////////////////////////////////////////

#if Ex_6
            void FirstFunc()
            {
                try
                {
                    checked
                    {
                        int x = int.MaxValue;
                        x++;
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e);
                }
            }

            void SecondFunc()
            {
                try
                {
                    unchecked // Не вызывает OverflowException
                    {
                        int x = int.MaxValue;
                        x++;
                    }
                }
                catch (OverflowException)
                {
                    Console.WriteLine("2) Произошло переполнение!");
                }
            }

            

            FirstFunc();
            SecondFunc();
#endif
            
            Console.ReadKey();
        }
    }
}