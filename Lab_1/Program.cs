using System;
using System.Text;

namespace OOP
{


    class Lab_1
    {
        static void Main(string[] args)
        {
            //Exercise 1///////////////////////////////////////////////////////////////////////////////////////////////////

#if Primitive_Types
            bool Bool = true;

            byte Byte = 255;
            sbyte SByte = 127;

            char Char = '\0';

            decimal Decimal = 228.1337M;    // точность 28-29 знаков
            double Double = 1.23;           // точность 15-17 знаков
            float Float = 1.23f;            // точность 6-9 знаков

            short Int_16 = 1;
            ushort UInt_16 = 1;
            int Int_32 = 1;
            uint UInt_32 = 1;
            long Int_64 = -100L;
            ulong UInt_64 = 100UL;

            Console.WriteLine("bool = {0}, byte = {1}, sbyte = {2}, char = {3}" +
                "\ndecimal = {4}, double = {5}, float = {6}, short = {7}" + 
                "\nushort = {8},  int = {9}, uint = {10}, long = {11}, ulong = {12}",
               
                Bool, Byte, SByte, Char, Decimal,
                Double, Float, Int_16, UInt_16, Int_32, UInt_32,
                 Int_64, UInt_64);
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
            string str1 = "a";
            string str2 = "а";

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
            result = str1.Substring(0, 3);

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

            //Exercise 2///////////////////////////////////////////////////////////////////////////////////////////////////




            Console.ReadKey();
        }
    }
}