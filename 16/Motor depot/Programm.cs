using System.Runtime.CompilerServices;

namespace Motor_depot
{
    internal class Programm
    {

        static void Main(string[] args)
        {
            System testSystem = new System();
            Dispatcher testDispatcher = new Dispatcher();
            Driver testDriver = new Driver();


            testSystem.register("Nikita", 123456);
            testSystem.register("Artem", 228228);
            testSystem.register("Danila", 133713);

            testSystem.SignIn("Artem", 228228);
            testSystem.SignIn("Nikita", 123456);
            testSystem.SignIn("Danila", 133713);

            testSystem.ViewAvailCars("Artem");

            uint OrderID_1 = testSystem.MakeSentOrder("Artem", 10, 90);
            uint OrderID_2 = testSystem.MakeSentOrder("Danila", 50, 70);
            uint OrderID_3 = testSystem.MakeSentOrder("Nikita", 90, 50);

            testSystem.DeleteSentOrder("Danila", OrderID_2);


            ///////////////////////////////////////////////////////////////////////
            Console.WriteLine();
            Console.WriteLine();


            testDispatcher.ViewOrders();
            (string driverName, uint orderID) driverNameID = testDispatcher.FindDriver(Databases.OrderList[1]);

            //Попробуй переделать с событиями!!!
            //testDispatcher.DistOrderToDriver(driverNameID.orderID, driverNameID.driverName);

            Dispatcher.DistOrderToDriver(driverNameID.orderID, driverNameID.driverName);

            testDriver.FlightReport(driverNameID.driverName, driverNameID.orderID, true, true);

            foreach (var item in Databases.UsersUccounts)
            {

            }

            foreach (var item in Databases.CarsList)
            {

            }

            foreach (var item in Databases.OrderList)
            {

            }
        }
    }
}