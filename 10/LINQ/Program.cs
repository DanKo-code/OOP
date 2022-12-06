using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;

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
                new Phone("Ilyin", "Filip", "Sergeevich", 654381, 20, 30, 0),
                new Phone("Kozak", "Oleg", "Victorovich", 655381, 10, 30, 0),
                new Phone("Victorovich", "Irina", "Nikitichna", 855381, 10, 30, 100),
                new Phone("Pshenko", "Artem", "Alekseevich", 100381, 50, 30, 280),
                new Phone("Sidorov", "Sidor", "Sidorovich", 178381, 20, 34, 0),
                new Phone("Artemov", "Artem", "Artemovich", 171381, 10, 34, 65),
                new Phone("Danilenko", "Andrey", "Danilovich", 271381, 0, 0, 0),
            };

            IEnumerable<Phone> list2 = from phone in list
                                       where phone.GetSetCityTalkTime > 50
                                       select phone;

            var list3 = list.Where(x => x.GetSetlongDistanceCallTime > 0);
            var list4 = list.Where(x => x.GetSetdebit > 0);
            var list5 = list.Max(x => x.GetSetCreditCardNumber);
            var list6 = list.OrderBy(x => x.GetSetFirstName);

            var list7 = list.Where(x => x.GetSetFirstName.Length > 5)
                            .Where(x => x.GetSetSecondName.Length > 5)
                            .Skip(1)
                            .OrderBy(x => x.GetSetCreditCardNumber)
                            .Select(x => new
                            {
                                FirstName = x.GetSetFirstName,
                                Card = x.GetSetCreditCardNumber
                            })
                            //.Any(x => x.GetSetCreditCardNumber > 0);
                            //.GroupBy(x => x.GetSetCityTalkTime);
                            .Max(x => x.Card);


            Console.WriteLine("\"------ сведения об абонентах, у которых время внутригородских разговоров превышает заданное ---------\"");

            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            Console.WriteLine("\"------ сведения об абонентах, которые пользовались междугородной связью ---------\"");

            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            Console.WriteLine("\"------ количество абонентов с заданным значением дебета ---------\"");

            foreach (var item in list4)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();


            Console.WriteLine("\"------ максимального абонента (по вашему критерию) ---------\"");

            Console.WriteLine(list5);
            Console.WriteLine();


            Console.WriteLine("\"------ упорядоченный список абонентов по фамилии ---------\"");

            foreach (var item in list6)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.WriteLine("------ свой запрос ---------");
            Console.WriteLine(list7);
            Console.WriteLine();
            Console.WriteLine();

            /////////////////////////////////////////////////////////////////////////////////
            Person[] people =
            {
                new Person("Tom", "Microsoft"), new Person("Sam", "Google"),
                new Person("Bob", "JetBrains"), new Person("Mike", "Microsoft"),
            };
            Company[] companies =
            {
                new Company("Microsoft", "C#"),
                new Company("Google", "Go"),
                new Company("Oracle", "Java")

            };

            var employees = from p in people
                            join c in companies on p.Company equals c.Title
                            select new { Name = p.Name, Company = c.Title, Language = c.Language };

            foreach (var emp in employees)
                Console.WriteLine($"{emp.Name} - {emp.Company} ({emp.Language})");

            ///////////////////////////////////////////////////////////////////////////////////

            Console.WriteLine("------ свой join ---------");
            MyPerson[] myPeople =
            {
                new MyPerson("Nikita", 668789),
                new MyPerson("Danila", 168978),
                new MyPerson("Artem", 068578),
            };

            Console.WriteLine();
            Console.WriteLine();

            var myJoin = from p1 in list
                         join p2 in myPeople on p1.GetSetSecondName equals p2.Name
                         select new { firstPersonCard = p1.GetSetCreditCardNumber, SecondPersonCard = p2.Card };


            foreach (var item in myJoin)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();

            var myJoin2 = list.Join(myPeople,
                p => p.GetSetSecondName,
                c => c.Name,
                (p, c) => new { firstPersonCard = p.GetSetCreditCardNumber, SecondPersonCard = c.Card });

            foreach (var item in myJoin2)
            {
                Console.WriteLine(item);
            }

        }

        class MyPerson
        {
            public MyPerson(string name, int card)
            {
                Name = name;
                Card = card;
            }

            public string Name { get; set; }
            public int Card { get; set; }
        }

        class Person
        {
            public Person(string name, string company)
            {
                this.Name = name;
                this.Company = company;
            }

            public string Name { get; set; }
            public string Company { get; set; }
        }

        class Company
        {
            public Company(string title, string language)
            {
                Title = title;
                Language = language;
            }

            public string Title { get; set; }
            public string Language { get; set; }
        }

    }
}