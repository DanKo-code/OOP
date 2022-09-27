using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Lab_2
    {
       public partial class  Phone
       {
            //Constructors
            public Phone(string firstName, string secondName, string patronymic, int creditCardNumber, int CityTalkTime, int GetSetlongDistanceCallTime)
            {
                this.firstName = Check_str(ref firstName);
                this.secondName = Check_str(ref secondName);
                this.patronymic = Check_str(ref patronymic);
                this.creditCardNumber = Check_numb(ref creditCardNumber, 6);
                this.CityTalkTime = CityTalkTime;
                this.longDistanceCallTime = GetSetlongDistanceCallTime;

                this.id = this.GetHashCode();
                countOfUsers++;
            }
            public Phone()
            {
                this.firstName = "User_firstName";
                this.secondName = "User_secondName";
                this.patronymic = "User_patronymic";
                this.creditCardNumber = 123456789;

                this.id = this.GetHashCode();
                countOfUsers++;
            }
            public Phone(int credit, string firstName = "User_firstName", string secondName = "User_secondName", string patronymic = "User_patronymic", int creditCardNumber = 123456789)
            {
                this.credit = credit;

                this.id = this.GetHashCode();
                countOfUsers++;
            }

            //Static_Constructor
            static Phone()
            {
                countOfUsers = 0;
            }

            //Private constructor
            private Phone(int a)
            {
                a++;
            }
            public void TestPrivatePhone()
            {
                Phone test = new Phone(1);
            }

            //Get_Set
            public string GetSetFirstName
            {
                get { return firstName; }
                set { firstName = Check_str(ref value); }
            }

            public string GetSetSecondName
            {
                get { return secondName; }
                set { secondName = Check_str(ref value); }
               
            }

            public string GetSetPatronymic
            {
                get { return patronymic; }
                set{patronymic = Check_str(ref value);}
            }

            public int GetSetAddress
            {
                get { return address; }
                set { address = Check_numb(ref value, 6 ); }
            }

            public int GetSetCreditCardNumber
            {
                get { return creditCardNumber; }
                set { creditCardNumber = Check_numb(ref value, 16); ; }
            }

            public int GetSetdebit
            {
                get { return debit; }
                private set { debit = value; }
            }

            public int GetSetcredit
            {
                get { return credit; }
                private set { credit = value; }
            }

            public int GetSetCityTalkTime
            {
                get { return CityTalkTime; }
                private set { CityTalkTime = value; }
            }

            public int GetSetlongDistanceCallTime
            {
                get { return longDistanceCallTime; }
                private set { longDistanceCallTime = value; }
            }

            // ref, out + count of balance
            public void GetBalance(ref int credit, ref int debet, out int balance)
            {
                debet++;
                credit++;

                balance = debet - credit;
            }

            // static inf
            public static void GetInf(Phone temp)
            {
                Console.Write(temp.firstName, temp.secondName, temp.credit, temp.patronymic);
            }


            //partial
            //+

            public override bool Equals(object obj)
            {
                if (obj == null) return false;
                if (obj.GetType() != this.GetType()) return false;
                Phone test_equals = (Phone)obj;
                return (this.id == test_equals.id);
            }

            public override string ToString()
            {
                return "Id " + this.id + ", " + "FirstName " + this.firstName;
            }

            public override int GetHashCode()
            {
                return (int)(this.creditCardNumber - 456 * 10 / 20 + 9786 -3);
            }

            ///////////////////////////////////////////////////////////////////////

            private string Check_str(ref string str)
            {
                foreach( char symbol in str )
                {
                    if ( 48 < symbol && symbol < 57) return "";
                }

                return str;
            }

            private int Check_numb(ref int numb, int border)
            {
                if (numb == border) { return 0; }
                return numb;
            }

            ///////////////////////////////////////////////////////////////////////
            ///


            /////////////////////////////////ИНДЕКСАТОР//////////////////////////////////////

            //public void PhoneArray(int size)
            //{
            //    a = new int[size];
            //    length = size;
                
            //}

            //public int this[int i]
            //{
            //    get
            //    {
            //        if (i >= 0 && i < length) return a[i];
            //        else { error = true; return 0; }
            //    }

            //    set
            //    {
            //        if(i>=0 && i<length &&
            //        value >=0 && value <= 100) a[i] = value;
            //        else error = true;
            //    }

            //}

            //public bool error = false;
            //int[] a;
            //int length;

        }

        public partial class Phone
        {
            //Const
            private const string statmant = "Velcom";

            //////////////////////////////////////////////////////////////////////
            private readonly int id;

            private string firstName;
            private string secondName;
            private string patronymic;
            private int address;
            private int creditCardNumber;

            private int debit;
            private int credit = 100;

            private int CityTalkTime = 100;
            private int longDistanceCallTime;

            private const int limitTime = 100;

            static int countOfUsers;
        }

        static void Main()
        {
            Phone test_1 = new Phone("Nikita", "Iluin", "SerGeyevich",567098, 100, 100);
            Phone test_2 = new Phone();
            Phone test_3 = new Phone(100, "Nikita");

            ///////////////////////////////////////////////////////////////////////////////

            test_1.GetSetFirstName = "123";

            test_1.TestPrivatePhone();

            test_1.GetSetFirstName = "Danila";

            test_1.Equals(test_1);

            test_1.ToString();
            Console.Write(test_1.ToString());

            test_1.GetHashCode();

            var someType = new { firstName = "artem", secondName = "pshenko", patronymic = "fedor", creditCardNumber = 123456 };
            Console.Write(someType.GetType());

            ///////////////////////////////////////////////////////////////////////////////
            ///

            int count = 2;
            Phone[] phoneARR = new Phone[count];
            phoneARR[0] = new Phone("Nikita", "Iluin", "SerGeyevich", 567098, 101, 0);
            phoneARR[1] = new Phone("Danila", "Iluin", "SerGeyevich", 567098, 101, 100);


            //Console.Write("\n\n\n");

            //for (int i = 0; i < count; i++)
            //{
            //    if (phoneARR[i].GetSetCityTalkTime > 100) Console.Write($"{phoneARR[i].ToString()}\n\n");
            //}

            Console.Write("\n\n\n");

            for (int i = 0; i < count; i++)
            {
                if (phoneARR[i].GetSetlongDistanceCallTime > 0) Console.Write($"{phoneARR[i].ToString()}\n\n");
            }

        }
    }
}
