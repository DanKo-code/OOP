using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Motor_depot.System;

namespace Motor_depot
{
    internal class System
    {
        public void register(string userName, uint userPassword)
        {
            //Проверка на совпадение имен
            foreach (var reservedUserAccount in Databases.UsersUccounts)
            {
                if(reservedUserAccount._userName == userName)
                {
                    Console.WriteLine("Ошибка! Пользователь с таким именем уже зарегистрирован.");
                    return;
                }
            }

            Databases.UsersUccounts.Add(new UserAccount(userName, userPassword));
        }

        public void SignIn(string userName, uint userPassword)
        {
            //Проверка на совпадение имени и пароля. В случае удачи флаг активности - true
            foreach (var reservedUserAccount in Databases.UsersUccounts)
            {
                if (reservedUserAccount._userName == userName &&
                    reservedUserAccount._userpassword == userPassword)
                {
                    reservedUserAccount._activityFlag = true;
                    return;
                }
            }

            Console.WriteLine("Ошибка! Не удалось авторизоваться.");
            return;
        }

        public void SignOut(string userName, uint userPassword)
        {
            //Проверка на совпадение имени и пароля. В случае удачи флаг активности - false
            foreach (var reservedUserAccount in Databases.UsersUccounts)
            {
                if (reservedUserAccount._userName == userName &&
                    reservedUserAccount._userpassword == userPassword)
                {
                    reservedUserAccount._activityFlag = false;
                    Console.WriteLine($"{reservedUserAccount._userName}, вы успешно вышли из своего аккаунта.") ;
                    return;
                }
            }
        }

        public void ViewAvailCars(string userName)
        {
            //Проверка на авторизацию пользователя
            if (CheсkUserAuthor(userName) == false) return;

     
            Console.WriteLine("Список авто:");

            uint counter = 0;
            foreach (var carInfo in Databases.CarsList)
            {
                Console.WriteLine($"{++counter}. Грузоподъемность {carInfo._carCarring}, Скорость {carInfo._carSpeed}.");
            } 
        }

        public uint MakeSentOrder(string userName, uint carCarring, uint carSpeed)
        {
            //Проверка на авторизацию пользователя
            if (CheсkUserAuthor(userName) == false) return 0;


            Random random = new Random();

            uint orderID = (uint)random.Next(100000, 500000);

            Databases.OrderList.Add(new Order(orderID, carCarring, carSpeed));

            return orderID;
        }

        public void ModificatSentOrder(string userName, uint orderID, uint carCarring, uint carSpeed)
        {
            //Проверка на авторизацию пользователя
            if (CheсkUserAuthor(userName) == false) return;


            foreach (var reservedOrder in Databases.OrderList)
            {
                if(reservedOrder._orderID == orderID)
                {
                    reservedOrder._carCarring = carCarring;
                    reservedOrder._carSpeed = carSpeed;

                    Console.WriteLine($"Заказ {reservedOrder._orderID} изменен успешно.");
                    return;
                }
            }

            Console.WriteLine("Ошибка! заказ не найден.");
        }

        public void DeleteSentOrder(string userName, uint orderID)
        {
            //Проверка на авторизацию пользователя
            if (CheсkUserAuthor(userName) == false) return;


            foreach (var reservedOrder in Databases.OrderList)
            {
                if (reservedOrder._orderID == orderID)
                {
                    Console.WriteLine($"Заказ {reservedOrder._orderID} успешно удален");

                    Databases.OrderList.Remove(reservedOrder);

                    return;
                }
            }

            Console.WriteLine("Ошибка! Заказ не найден.");
        }

        private bool CheсkUserAuthor(string userName)
        {
            int userIndex = Databases.UsersUccounts.FindIndex(user => user._userName == userName);

            if (userIndex != -1)
            {
                if (Databases.UsersUccounts[userIndex]._activityFlag == true)
                {

                    return true;
                }
                else
                {
                    Console.WriteLine("Ошибка! Пользователь не авторизован.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Пользователя с таким именем не найдено.");
                return false;
            }
        }

        public class UserAccount
        {
            public UserAccount(string userName, uint userPassword)
            {
                _userName = userName;
                _userpassword = userPassword;
            }

            public string _userName = "UndefindName";
            public uint _userpassword = 0;
            public bool _activityFlag = false;
        }

        public class CarInfo
        {
            public CarInfo(string driverName, uint carCarring, uint carSpeed, bool carCondition)
            {
                _driverName = driverName;
                _carCarring = carCarring;
                _carSpeed = carSpeed;
                _carCondition = carCondition;
            }

            public string _driverName = "UndefindDriverName";
            public uint _carCarring = 0;
            public uint _carSpeed = 0;
            public bool _carCondition = false;

            public uint _orderID = 0;
        }

        public class Order
        {

            public Order(uint orderID, uint carCarring, uint carSpeed)
            {
                _orderID = orderID;
                _carCarring = carCarring;
                _carSpeed = carSpeed;
            }

            public uint _orderID = 0;
            public uint _carCarring = 0;
            public uint _carSpeed = 0;
        }
    }
}
