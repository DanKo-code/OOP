using System.Reflection;
using System.Text.RegularExpressions;

namespace Lab_8_Delegates_Events_LambdaExpressions
{
    internal class Test
    {


        // 8 example delegate as argument
        //static void DoOperation(int a, int b, Operation op)
        //{
        //    Console.WriteLine(op(a, b));
        //}
        //static int Add(int x, int y) => x + y;
        //static int Subtract(int x, int y) => x - y;
        //static int Multiply(int x, int y) => x * y;

        //delegate int Operation(int x, int y);

        // 9 example delegate as return value
        //delegate int Operation(int x, int y);

        //static Operation SelectOperation(OperationType opType)
        //{
        //    switch (opType)
        //    {
        //        case OperationType.Add: return Add;
        //        case OperationType.Subtract: return Subtract;
        //        default: return Multiply;
        //    }
        //}

        //static int Add(int x, int y) => x + y;
        //static int Subtract(int x, int y) => x - y;
        //static int Multiply(int x, int y) => x * y;

        //enum OperationType
        //{
        //    Add, Subtract, Multiply
        //}

        // 10 example
        //public delegate void AccountHandler(string message);
        //public class Account
        //{
        //    int sum;
        //    AccountHandler? taken;
        //    public Account(int sum) => this.sum = sum;
        //    // Регистрируем делегат
        //    public void RegisterHandler(AccountHandler del)
        //    {
        //        taken += del;
        //    }
        //    // Отмена регистрации делегата
        //    public void UnregisterHandler(AccountHandler del)
        //    {
        //        taken -= del; // удаляем делегат
        //    }
        //    public void Add(int sum) => this.sum += sum;
        //    public void Take(int sum)
        //    {
        //        if (this.sum >= sum)
        //        {
        //            this.sum -= sum;
        //            taken?.Invoke($"Со счета списано {sum} у.е.");
        //        }
        //        else
        //            taken?.Invoke($"Недостаточно средств. Баланс: {this.sum} у.е.");
        //    }
        //}

        // 11 example
        //class Message
        //{
        //    public string Text { get; }
        //    public Message(string text) => Text = text;
        //    public virtual void Print() => Console.WriteLine($"Message: {Text}");
        //}
        //class EmailMessage : Message
        //{
        //    public EmailMessage(string text) : base(text) { }
        //    public override void Print() => Console.WriteLine($"Email: {Text}");
        //}
        //class SmsMessage : Message
        //{
        //    public SmsMessage(string text) : base(text) { }
        //    public override void Print() => Console.WriteLine($"Sms: {Text}");
        //}
        //delegate Message MessageBuilder(string text);

        // 12 example
        //public class StockExchangeMonitor
        //{
        //    public delegate void PriceChange(int price);

        //    public PriceChange PriceChangeHandler { get; set; }

        //    public void Start()
        //    {
        //        while (true)
        //        {
        //            int bankOfAmericaPrice = (new Random()).Next(100);

        //            PriceChangeHandler(bankOfAmericaPrice);

        //            Thread.Sleep(2000);
        //        }
        //    }
        //}

        class Programmer
        {

            public delegate void LANG(List<string> list);
            public event LANG Delete;
            public event LANG Mutate;

            public void dele(List<string> list)
            {
                Console.Write("Ведите номер элемента, который хотите удалить(начиная с 0): ");
                int num = int.Parse(Console.ReadLine());
                list.RemoveAt(num);
                Delete?.Invoke(list);
            }

            public void Perenos(List<string> list)
            {
                Random random = new Random();
                List<string> NewList = list.OrderBy(item => random.Next()).ToList();
                list.Clear();
                list.AddRange(NewList);
                Mutate?.Invoke(list); 
            }
        }
        class StringEditor
        {
            public static string RemovePunctuation(string str)
            {
                return Regex.Replace(str, "[.,;:]", string.Empty);
            }

            public static string AddSymbol(string str)
            {
                return str += "Lab08";
            }

            public static string ToUpper(string str)
            {
                return str.ToUpper();
            }

            public static string ToLower(string str)
            {
                return str.ToLower();
            }

            public static string RemoveSpace(string str)
            {
                return str.Replace(" ", string.Empty);
            }
        }

        delegate void TEST();
        static event TEST? AAA;

        static void Foo() { Console.WriteLine("Foo"); }
        static void Foo1() { Console.WriteLine("Foo1"); }

        delegate void Message();

        static void Main(string[] args)
        {

            var hello = (int a, int b) => a+b ;

            Console.WriteLine(hello(1, 2)); 

            AAA = Foo;
            AAA += Foo1;

            AAA?.Invoke();

            //Programmer.LANG Language;
            //Programmer programmer = new Programmer();
            //List<string> LP = new List<string> { "Ruby", "C#", "Kotlin", "Pascal", "Python", "GoLang", "VisualBasic", "Dart", "JS", "Java" };

            //Console.Write("Список: ");
            //foreach (string item in LP)
            //{
            //    Console.Write(item + "   ");
            //}
            //Console.WriteLine();

            //programmer.Delete += list =>
            //{
            //    Console.Write("Измененный: ");
            //    foreach (string item in LP)
            //    {
            //        Console.Write(item + "   ");
            //    }
            //    Console.WriteLine();
            //};

            //programmer.Mutate += list =>
            //{
            //    Console.Write("Перестановка: ");
            //    foreach (string item in LP)
            //    {
            //        Console.Write(item + "   ");
            //    }
            //    Console.WriteLine();
            //};

            //Language = programmer.dele;
            //Language += programmer.Perenos;
            //Language += programmer.Perenos;
            //Language += programmer.Perenos;

            //Language(LP);

            //Func<string, string> A;
            //string str = "Nikita; Karebo. made, this; str";
            //Console.WriteLine($"\n\nСтрока: {str}");
            //A = StringEditor.RemovePunctuation;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");
            //A = StringEditor.AddSymbol;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");
            //A = StringEditor.ToUpper;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");
            //A = StringEditor.ToLower;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");
            //A = StringEditor.RemoveSpace;
            //Console.WriteLine($"{A.Method.Name}: {A(str)}");


            // 8 example delegate as argument
            //DoOperation(5, 4, Add);         // 9
            //DoOperation(5, 4, Subtract);    // 1
            //DoOperation(5, 4, Multiply);    // 20

            // 9 example delegate as return value
            //Operation operation = SelectOperation(OperationType.Add);
            //Console.WriteLine(operation(10, 4));    // 14

            //operation = SelectOperation(OperationType.Subtract);
            //Console.WriteLine(operation(10, 4));    // 6

            //operation = SelectOperation(OperationType.Multiply);
            //Console.WriteLine(operation(10, 4));

            // 10 example
            //Account account = new Account(200);
            //// Добавляем в делегат ссылку на методы
            //account.RegisterHandler(PrintSimpleMessage);
            //account.RegisterHandler(PrintColorMessage);
            //// Два раза подряд пытаемся снять деньги
            //account.Take(100);
            //account.Take(150);

            //// Удаляем делегат
            //account.UnregisterHandler(PrintColorMessage);
            //// снова пытаемся снять деньги
            //account.Take(50);

            //void PrintSimpleMessage(string message) => Console.WriteLine(message);
            //void PrintColorMessage(string message)
            //{
            //    // Устанавливаем красный цвет символов
            //    Console.ForegroundColor = ConsoleColor.Red;
            //    Console.WriteLine(message);
            //    // Сбрасываем настройки цвета
            //    Console.ResetColor();
            //}

            // 11 example
            //// делегату с базовым типом передаем метод с производным типом
            //MessageBuilder messageBuilder = WriteEmailMessage; // ковариантность
            //Message message = messageBuilder("Hello");
            //message.Print();    // Email: Hello

            //EmailMessage WriteEmailMessage(string text) => new EmailMessage(text);

            // 12 example
            /*
            StockExchangeMonitor stockExchangeMonitor = new StockExchangeMonitor();
            stockExchangeMonitor.PriceChangeHandler = ShowPrice;
            stockExchangeMonitor.PriceChangeHandler += ShowPrice2;
            stockExchangeMonitor.Start();
            */


        }

        //public static void ShowPrice(int price)
        //{
        //    Console.WriteLine($"New price is: {price}");
        //}
        //public static void ShowPrice2(int price)
        //{
        //    Console.ForegroundColor = ConsoleColor.Red;

        //    Console.WriteLine($"New price is: {price}");

        //    Console.ResetColor();
        //}


    }
}