using System.Reflection.Emit;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] months = {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            };
            Console.WriteLine("Введите длину месяца: ");
            int n = Convert.ToInt32(Console.ReadLine());
            IEnumerable<string> lengthN = from month in months
                                          where month.Length == n
                                          select month;
            var WinterSummer = months.Where((month, i) => i < 2 || i > 4 && i < 8 || i == 11);
            var alphabetOrder = months.OrderBy(month => month);
            var withU = months.Where(month => month.Contains("u") && month.Length > 3);

            foreach (string s in lengthN)
            { Console.WriteLine(s); }
            Console.WriteLine();

            foreach (string s in WinterSummer)
            { Console.WriteLine(s); }
            Console.WriteLine();

            foreach (string s in alphabetOrder)
            { Console.WriteLine(s); }
            Console.WriteLine();

            foreach (string s in withU)
            { Console.WriteLine(s); }
            Console.WriteLine();


            ////////////////////////////////////////////////////////
            ///



            List<Phone> list = new List<Phone>()
            {
                new Phone("Kareboo", "Nikita", "Sergeevich", 123456, 0, 0, 10),
                new Phone("Kozliakovsi", "Danila", "Aleksandrovich", 654321, 100, 100, 10),
                new Phone("Ilyin", "Nikita", "Sergeevich", 654381, 20, 30, 0),
                new Phone("Kozak", "Oleg", "Victorovich", 655381, 10, 30, 0),
                new Phone("Victorovich", "Irina", "Nikitichna", 855381, 10, 30, 100),
                new Phone("Pshenko", "Artem", "Alekseevich", 100381, 50, 30, 280),
                new Phone("Sidorov", "Sidor", "Sidorovich", 178381, 20, 34, 0),
                new Phone("Artemov", "Artem", "Artemovich", 171381, 10, 34, 65),
                new Phone("Danilenko", "Danila", "Danilovich", 271381, 16, 35, 64),
                new Phone("Danilenko", "Danila", "Danilovich", 271381, 16, 35, 64),
            };

            IEnumerable<Phone> list2 = from phone in list
                                       where phone.GetSetCityTalkTime > 50
                                       select phone;

            var list3 = list.Where(x => x.GetSetlongDistanceCallTime > 0);
            var list4 = list.Where(x => x.GetSetdebit > 0);
            var list5 = list.Max(x => x.GetSetCreditCardNumber);    
            var list6 = list.OrderBy(x => x.GetSetFirstName);    



        }


    }
}



            
            
            
