using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    partial class Phone
    {
        //Constructors
        public Phone(string firstName, string secondName, string patronymic, int creditCardNumber, int CityTalkTime, int longDistanceCallTime, int debet)
        {
            this.firstName = Check_str(ref firstName);
            this.secondName = Check_str(ref secondName);
            this.patronymic = Check_str(ref patronymic);
            this.creditCardNumber = Check_numb(ref creditCardNumber, 6);
            this.CityTalkTime = CityTalkTime;
            this.longDistanceCallTime = longDistanceCallTime;

            this.debit = debet;

            this.id = this.GetHashCode();
            countOfUsers++;
        }
        public Phone()
        {
            this.firstName = "User_firstName";
            this.secondName = "User_secondName";
            this.patronymic = "User_patronymic";
            this.creditCardNumber = 123456;

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
            set
            {
                Console.Write("!!!!!!!!!!");
                firstName = Check_str(ref value);
            }
        }

        public string GetSetSecondName
        {
            get { return secondName; }
            set { secondName = Check_str(ref value); }

        }

        public string GetSetPatronymic
        {
            get { return patronymic; }
            set { patronymic = Check_str(ref value); }
        }

        public int GetSetAddress
        {
            get { return address; }
            set { address = Check_numb(ref value, 6); }
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
            return (int)(this.creditCardNumber - 456 * 10 / 20 + 9786 - 3);
        }

        ///////////////////////////////////////////////////////////////////////

        private string Check_str(ref string str)
        {
            foreach (char symbol in str)
            {
                if (48 < symbol && symbol < 57) return "";


            }

            return str;
        }

        private int Check_numb(ref int numb, int border)
        {
            if (numb.ToString().Length != border) return 0;
            return numb;
        }

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
}

