using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot
{
    internal class Driver
    {
        public void FlightReport(string driverName, uint orderID, bool flightRes, bool carCondition)
        {
            Console.WriteLine($"Имя водителя {driverName}, Номер заказа {orderID}, Результата {flightRes}, Состояние машины {carCondition}");

            //Диспетчер обнуляет заказ в водителе
            Dispatcher.DistOrderToDriver(0, driverName);

            //Диспетчер удаляет заказ из базы
            Dispatcher.removeOrder(orderID);
        }
    }

}