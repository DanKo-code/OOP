using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Motor_depot.System;

namespace Motor_depot
{
    internal class Dispatcher
    {
        public dynamic FindDriver(System.Order userOrder)
        {
            int carIndex = Databases.CarsList.FindIndex(car => car._carCarring >= userOrder._carCarring &&
                                                car._carSpeed >= userOrder._carSpeed);

            if(carIndex != -1)
            {
                return (Databases.CarsList[carIndex]._driverName, userOrder._orderID);
            }

            Console.WriteLine("Ошибка! Подходящего водителя не найдено.");
            return ("UndefindDriverName", 0);
        }

        public static void DistOrderToDriver(uint orderID, string driverName)
        {
            int carIndex = Databases.CarsList.FindIndex(car => car._driverName == driverName);

            if (carIndex != -1)
            {
                Databases.CarsList[carIndex]._orderID = orderID;
                return;
            }

            Console.WriteLine("Ошибка! Водитель не найден.");
        }

        public static void removeOrder(uint orderID)
        {
            Databases.OrderList.RemoveAt(Databases.OrderList.FindIndex(order => order._orderID == orderID));
        }

        public void ViewOrders()
        {
            Console.WriteLine("Список заказов:");

            uint counter = 0;
            foreach (var orderInfo in Databases.OrderList)
            {
                Console.WriteLine($"{++counter}. ID заказа {orderInfo._orderID}, Грузоподъемность {orderInfo._carCarring}, Скорость {orderInfo._carSpeed}.");
            }
        }
    }
}
